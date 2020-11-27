using System;
using System.Collections.Generic;
using System.Linq;
using MarketApp.DataModel.Market;
using MarketApp.UI.Infrastructure;
using MarketApp.UI.ViewModels.VMBase;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels
{
	public class AuthViewModel : ViewModelBase
	{
		public RelayCommand LogInCommand => new RelayCommand(  x=>LogIn() );
		public event Action LogInSuccess = delegate { };
		public event Action LogInFailed = delegate { };

		public string UserLogin { get; set; }
		public string UserPassword { get; set; }

		public AuthViewModel()
		{
			//LogInCommand.Execute( null );
			if (_conf.DebugModeEnabled || _conf.TestModeEnabled) /* DEBUG | TEST */
			{
				UserLogin = "DEVELOPER";
				UserPassword = "lytdybr";
				LogInCommand.Execute( null );
				//OnAllPropertyChanged();
			}
		}

		private void LogIn()
		{
			User user;
			//if (IsTokenValid)// чекаем валидный ли токен
			//{
			//	_cache.PermissionList = _context.UsersToPermissons
			//		.AsNoTracking()
			//		.Where( x => x.IdUser == _cache.UserId )
			//		.Select(x=>x.Permission)
			//		.ToList();				
			//}

			user = Authenticate(UserLogin, UserPassword);
			user = Authorize( user );
			if (user == null)
			{
				LogInFailed();
				return;
			}
			CreateNewToken(user);
			_cache.PermissionList = _context.UsersToPermissons
				.Where( x => x.IdUser == _cache.UserId )
				.Select( x => x.Permission )
				.ToList();			
			LogInSuccess();
		}		

		private User Authenticate(string login, string password)
		{
			User user = null;
			user = SafeExecute( () => _context.Authenticate( login, password ), true );
			if (user == null)
			{
				_log.Error( "В базе отсутствует пользователь с такой парой логин/пароль" );
				return null;
			}
			return user;
		}

		private User Authorize(User user)
		{
			if(user == null) return null;
			if(!user.UserToPerms.Any()) return null;
			if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty( user.Password ))
				return null;
			List<UsersToPermissons> permissionList = new List<UsersToPermissons>();
			permissionList = SafeExecute(() => _context.Authorize(user), true );
			if (!permissionList.Any())
			{
				_log.Error("У пользователя отсутствуют какие-либо привелегии");
				return null;
			}
			user.UserToPerms = permissionList;
			return user;
		}
		
		private bool CreateNewToken(User user)
		{
			_cache.TokenExpirationDate = DateTime.Now.AddHours( _conf.TokenExpirationHours );
			_cache.UserId = user.Id;
			_cache.UserName = user.UserName;
			_cache.UserFio = user.Fio;
			_cache.PermissionList = user.UserToPerms.Select(x => x.Permission).ToList();
			_cache.Save( _cache, AuthCache.ConfFileName );

			return true;
		}
		
		
	}
}
