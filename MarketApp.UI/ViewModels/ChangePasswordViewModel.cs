using System;
using MarketApp.UI.ViewModels.VMBase;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels
{
	public class ChangePasswordViewModel : ViewModelBase
	{
		public bool SetMode { get; set; }
		public string OldPassword { get; set; }
		public string NewPassword { get; set; }
		public string NewPasswordConfirm { get; set; }
		public string UserLogin { get; set; }
		public event Action<string> OnPasswordChanged = delegate { };
		public event Action<string> OnPasswordSetted = delegate { };
		public bool UnusedBoxesIsEnabled { get; set; } = true;

		public RelayCommand SetPasswordCommand => new RelayCommand(x => SetPassword() );

		public void SetPassword()
		{
			if (!String.IsNullOrEmpty( NewPassword ) && !String.IsNullOrEmpty( NewPasswordConfirm ))
				if (NewPassword == NewPasswordConfirm) // проверим совпадают ли введённые новые пароли
					if (SetMode) // если режим установки пароля новому пользователю
					{
						// просто отдадим введённый новый пароль
						if (!String.IsNullOrEmpty( NewPassword ))
							OnPasswordSetted( NewPassword );
					}
					else // если режим смены пароля
					{
						var pwd = ChangePassword( UserLogin, OldPassword, NewPassword );
						OnPasswordChanged( pwd );
					}
		}

		public string ChangePassword(string userLogin, string oldPassword, string newPassword)
		{
			//var user = AuthViewModel.Authenticate( userLogin, oldPassword );
			//if (user != null)
			//{
			//	return newPassword;
			//}
			//else
			//{
			//	_log.Error(new NullReferenceException( "Введён не верный текущий пароль" ));
			//}
			return null;
		}


		public ChangePasswordViewModel ChangeViewModel(string userLogin)
		{
			return new ChangePasswordViewModel {
				UserLogin = userLogin,
				SetMode = false,
			};

		}

		public ChangePasswordViewModel SetViewModel(string userLogin)
		{
			return new ChangePasswordViewModel {
				UserLogin = userLogin,
				SetMode = true,
			};
		}

	}
}
