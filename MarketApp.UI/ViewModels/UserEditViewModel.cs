using MarketApp.UI.ViewModels.VMBase;

namespace MarketApp.UI.ViewModels
{
	public class UserEditViewModel : ViewModelBase
	{
		///// <summary>
		///// Список возможных прав
		///// </summary>
		//public List<Permission> AvailablePermissions { get; set; }
		///// <summary>
		///// Список имеющиеся прав
		///// </summary>
		//public List<Permission> UserPermissions { get; set; }
		///// <summary>
		///// Выбранное доступное право
		///// </summary>
		//public Permission SelectedAvailablePermission { get; set; }
		///// <summary>
		///// Выбранное имеющиеся право
		///// </summary>
		//public Permission SelectedUserPermission { get; set; }
		///// <summary>
		///// Редактируемый юзер
		///// </summary>
		//public User User { get; set; }
		///// <summary>
		///// Флаг наличия пароля.
		///// Если true То пароль у юзера установлен. нужно для создания пользователя с паролем
		///// </summary>
		//public bool IsPasswordSet { get; set; }

		///// <summary>
		///// Флаг режима редактирования.
		///// Если true, то редим редактирования пользователя
		///// </summary>
		//public bool IsEditMode { get; set; }

		//protected string pwd;
		//public RelayCommand SaveCommand => new RelayCommand( Save );
		//public RelayCommand ApplyRoleCommand => new RelayCommand( ApplyRole );
		//public RelayCommand ChangePasswordCommand => new RelayCommand( ChangePassword );
		//public RelayCommand AddPermCommand => new RelayCommand( AddPerm );
		//public RelayCommand RemovePermCommand => new RelayCommand( RemovePerm );

		//public ObservableCollection<Permission> UserPermissionSource
		//	=> new ObservableCollection<Permission>( UserPermissions ?? new List<Permission>() ); 
		
		//public ObservableCollection<Permission> AvailablePermissionSource
		// => new ObservableCollection<Permission>( AvailablePermissions ?? new List<Permission>() );
		

		//private void Save(object o = null)
		//{
		//	if (!IsPasswordSet) // если не установлен пароль то шлём его устанавливать
		//	{
		//		_log.Error( "Чтобы продолжить, необходимо задать пользователю пароль" );
		//		return;
		//	}  

		//	if (IsEditMode) // если режим редактирования
		//	{
		//		DbOperations.Update(User);// просто обновим юзера при изменении его данных
		//		DXMessageBox.Show( "Успешно сохранено", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information );
		//	}
		//	else // иначе
		//	{
		//		DbOperations.Insert(User); // сохраняем юзера
		//		var userId = User.Id;
		//		foreach (var perm in UserPermissions) // его новые права
		//		{
		//			DbOperations.Insert( new UserPermissionAssign() {
		//				Del = null,
		//				PermissionId = perm.Id,
		//				UserId = userId,
		//			} );
		//		}
		//		ChangePassword( pwd, userId ); // даём ему пароль
		//		IsEditMode = true; // переходим их режима создания в режим редактирования
		//		DXMessageBox.Show( "Успешно сохранено", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information );
		//	}

		//	if (User.Id == _cache.User.Id) // в случае, когда редактируемый пользователь - текущий
		//	{
		//		_cache.User = User; // обновим его
		//	}
		//}

		//private void ApplyRole(object o = null)
		//{

		//}

		//private void AddPerm(object o = null)
		//{
		//	if (SelectedAvailablePermission != null)
		//	{
		//		if(IsEditMode)
		//			DbOperations.Insert(new UserPermissionAssign()
		//			{
		//				Del = null,
		//				PermissionId = SelectedAvailablePermission.Id,
		//				UserId = User.Id,
		//			} );

		//		AvailablePermissions.Remove(SelectedAvailablePermission);
		//		UserPermissions.Add( SelectedAvailablePermission );
		//		if(User.Id == _cache.User.Id)
		//		{
		//			_cache.UserPermissions = UserPermissions;
		//		}
		//		OnAllPropertyChanged();
		//	}
		//}

		//private void RemovePerm(object o = null)
		//{
		//	if (SelectedUserPermission != null)
		//	{
		//		if (IsEditMode)
		//			DeleteRelations(new UserPermissionAssign()
		//			{
		//				PermissionId = SelectedUserPermission.Id,
		//				UserId = User.Id
		//			});
					
		//		UserPermissions.Remove( SelectedUserPermission );
		//		AvailablePermissions.Add( SelectedUserPermission );
		//		if (User.Id == _cache.User.Id)
		//		{
		//			_cache.UserPermissions = UserPermissions;
		//		}
		//		OnAllPropertyChanged();
		//	}
		//}

		//private void ChangePassword(object o = null)
		//{
		//	try
		//	{
		//		string title;
		//		ChangePasswordViewModel NewWindowContext;
		//		Window wnd = new Window();
		//		if (IsEditMode) // если пользователя редактируем
		//		{
		//			title = $"Изменить пароль для '{User.Login}'";
		//			NewWindowContext = ChangePasswordViewModel.ChangeViewModel(User.Login);
		//		}
		//		else // если пользователя создаём
		//		{
		//			title = $"Задать пароль для '{User.Login}'";
		//			NewWindowContext = ChangePasswordViewModel.SetViewModel(User.Login);
		//			NewWindowContext.UnusedBoxesIsEnabled = false;

		//		}
		//		NewWindowContext.OnPasswordSetted += (pwd) =>
		//		{
		//			IsPasswordSet = true;
		//			this.pwd = pwd;
		//			wnd.Close();
		//			DXMessageBox.Show( "Пароль установлен", "Пароль", MessageBoxButton.OK, MessageBoxImage.Information );
		//		};
		//		wnd = _wnd.CreateNewWindow<ChangePasswordWindow>( title, NewWindowContext );
		//	}
		//	catch (Exception ex)
		//	{
		//		_log.Error(ex);
		//	}
		//}

		//public static List<Permission> LoadAvailablePermissions()
		//	=> DbOperations.Select<Permission>();

		//public static List<Permission> LoadUserPermission(int userId)
		//	=> LoadRelations<Permission, User, UserPermissionAssign>(userId);

		//public static UserEditViewModel EditModeViewModel(User user)
		//{
		//	var userPerms  = LoadUserPermission(user.Id); // подгружаем пправа юзера
		//	var availPerms = LoadAvailablePermissions() // подгружаем список прав
		//		.Where(x => !userPerms.Any(x2 => x2.Id == x.Id)).ToList(); // убираем лишнее

			
		//	var newVM = new UserEditViewModel() {
		//		User = user,
		//		IsPasswordSet = true,
		//		IsEditMode = true,
		//		AvailablePermissions = availPerms,
		//		UserPermissions = userPerms,
		//	};
		//	return newVM;
		//}

		//public UserEditViewModel CreateModeViewModel()
		//{
		//	var newVM = new UserEditViewModel() {
		//		User = new User()
		//		{
		//			Id = SetNewId<User>()
		//		},
		//		IsPasswordSet = false,
		//		IsEditMode = false,
		//		AvailablePermissions = LoadAvailablePermissions(),
		//		UserPermissions = new List<Permission>(),
		//	};
		//	return newVM;
		//}
		
		//public void ChangePassword(string password, int userId)
		//{
		//	//var table = DbOperations.GetPropAttribut<User, DTOTableAttribute>().tableName;
		//	//var idProp = DbOperations.GetProps<User>( DTOPropFlags.Id ).FirstOrDefault();
		//	//var id = (DTOPropAttribute)idProp.GetCustomAttributes(typeof(DTOPropAttribute), false).FirstOrDefault();

		//	//var where1 = DbOperations.GetProps<User>( DTOPropFlags.Id ).FirstOrDefault().Name;
		//	//var set = $"PASSWORD='{password}'";
		//	//var where = $"\"{id.dbColumnName}\"={userId}";

		//	//string select = OracleCodeGenerator.Update( table, set, where );

		//	//var req = AppManager.Service.Web
		//	//	.ExecQuery<String>( select );

		//}

	}
}
