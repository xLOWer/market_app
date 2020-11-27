using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using MarketApp.UI.Infrastructure;
using Utilities.Settings;
using MarketDbContext = MarketApp.DataModel.MarketDbContext;

namespace MarketApp.UI.ViewModels.VMBase
{
	abstract public class ViewModelBase : INotifyPropertyChanged, IDisposable
	{
		public virtual event Action Loaded = null;
		public virtual event Action Unloaded = null;
		public delegate void ErrorHandler(string errorMsg);
		public virtual event ErrorHandler OnError = delegate { };
		internal readonly Config _conf;
		internal readonly UILogger _log;
		internal readonly AuthCache _cache;
		internal readonly WindowsService _wnd;
		internal MarketDbContext _context = MarketDbContext.GetInstance();
		
		public bool IsTokenValid
		{
			get {
/* a.CompareTo(b);   //a,b===DateTime
-1	a раньше b
0	a равен b
1	a позже b */
				// если дата истечения токена позже текущей
				if ((_cache?.TokenExpirationDate.CompareTo( DateTime.Now ) ?? -1) >= 0) 
				{
					// и имя пользователя не пустое
					if(!string.IsNullOrEmpty( _cache?.UserName ?? "" ))
					{
						return true;
					}
				}
				return false;
			}
		}
		
		public void ShowError(string errorText)
		{
			OnError( errorText );
		}

		public ViewModelBase()
		{
			_conf = Config.GetInstance();
			_log = UILogger.GetInstance();
			_cache = AuthCache.GetInstance();
			_wnd = WindowsService.GetInstance();
		}
		
		internal TOut SafeExecute<TOut>(Func<TOut> ecex, bool DisableTokenCheck = false) where TOut : class, new()
		{
			if(!DisableTokenCheck)
				if (!IsTokenValid)
				{
					// to do some login actions
				}
			try
			{
				return ecex.Invoke();
			}
			catch (Exception ex)
			{
				_log.Error(ex);
			}

			return new TOut();
		}

		/// <summary>Событие для извещения об изменения свойства</summary>
		public event PropertyChangedEventHandler PropertyChanged;

		/// <summary>Метод для вызова события извещения об изменении свойства</summary>
		/// <param name="prop">Изменившееся свойство или список свойств через разделители "\\/\r \n()\"\'-"</param>
		public void RaiseNotifyPropertyChanged([CallerMemberName] string prop = "")
		{
			string[] names = prop.Split( "\\/\r \n()\"\'-".ToArray(), StringSplitOptions.RemoveEmptyEntries );
			if (names.Length != 0)
				foreach (string _prp in names)
					PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( _prp ) );
		}

		/// <summary>Метод для вызова события извещения об изменении списка свойств</summary>
		/// <param name="propList">Последовательность имён свойств</param>
		public void OnPropertyChanged(IEnumerable<string> propList)
		{
			foreach (string _prp in propList.Where( name => !string.IsNullOrWhiteSpace( name ) ))
				PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( _prp ) );
		}

		/// <summary>Метод для вызова события извещения об изменении списка свойств</summary>
		/// <param name="propList">Последовательность свойств</param>
		public void OnPropertyChanged(IEnumerable<PropertyInfo> propList)
		{
			foreach (PropertyInfo _prp in propList)
				PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( _prp.Name ) );
		}
		
		/// <summary>Метод для вызова события извещения об изменении всех свойств</summary>
		public void OnAllPropertyChanged() => OnPropertyChanged( GetType().GetProperties() );

		protected virtual void OnDispose() { }

		public void Dispose()
		{
			OnDispose();
		}
	}
}
