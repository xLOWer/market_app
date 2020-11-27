using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using MarketApp.DataModel.Market;
using Oracle.ManagedDataAccess.Client;
using Utilities.Logger;
using Utilities.Settings;

namespace MarketApp.DataModel
{
	public partial class MarketDbContext
	{
		public string SelectSingleValue(string Sql)
		{
			OracleDataReader reader;
			string retVal = "";
			try
			{
				using (OracleCommand command = new OracleCommand())
				{
					command.Connection = (OracleConnection) GetDefaultConnection();
					command.CommandType = CommandType.Text;
					command.CommandText = Sql;

					if (command.Connection.State != ConnectionState.Open)
						command.Connection.Open();

					reader = command.ExecuteReader();

					while (reader.Read())
					{
						retVal = reader[0].ToString();
					}
				}
			}
			catch (Exception ex)
			{
				UtilityLog.GetInstance().Error(ex);
			}

			return retVal;
		}

		public void ExecuteCommand(string Sql)
		{
			try
			{
				using (OracleCommand command = new OracleCommand())
				{
					command.Connection = (OracleConnection)GetDefaultConnection();
					command.CommandType = CommandType.Text;
					command.CommandText = Sql;
					if (command.Connection.State != ConnectionState.Open)
						command.Connection.Open();
					command.ExecuteNonQuery();
				}
			}
			catch (Exception ex)
			{
				UtilityLog.GetInstance().Error( ex );
			}
		}

		private static DbConnection GetDefaultConnection()
		{
			UtilityLog.GetInstance().Log( "GetDefaultConnection()" );
			DbConnection connection = null;
			try
			{
				connection = Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance.CreateConnection();
				//Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance.CreateConnection();
				var connStr = Config.GetInstance().MarketConnectionString;
				connection.ConnectionString = connStr;
			}
			catch(Exception ex)
			{
				UtilityLog.GetInstance().Error( ex );
			}
			return connection;
		}

		public User CreateNewUser(User user)
		{
			try
			{
				user.Id = decimal.Parse( SelectSingleValue( "SELECT MAX(ID_USER) FROM FIN.WEB_USERS" ) );
				ExecuteCommand( "INSERT INTO FIN.WEB_USERS(ID_USER,USER_NAME,FIO,PASSWORD)"
					+ $@"VALUES({user.Id},'{user.UserName}','{user.Fio}','{user.Password}')" );
			}
			catch(Exception ex)
			{
				UtilityLog.GetInstance().Error(ex);
			}

			return user;
		}

		public User Authenticate(string login, string password)
		{
			User user = Users
				.AsNoTracking()
				.SingleOrDefault( x => x.UserName == login && x.Password == password );
			return user;
		}


		public List<UsersToPermissons> Authorize(User user) => 
			UsersToPermissons
				.AsNoTracking()
				.Where( x => x.IdUser == user.Id )
				.ToList();
		


	}
}
