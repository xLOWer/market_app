using MarketApp.UI.ViewModels.VMBase;

namespace MarketApp.UI.ViewModels
{
	class RoleEditViewModel : ViewModelBase
	{
		///// <summary>
		///// Список возможных прав
		///// </summary>
		//public List<Permission> AvailablePermissions { get; set; }
		///// <summary>
		///// Список имеющиеся прав
		///// </summary>
		//public List<Permission> RolePermissions { get; set; }
		///// <summary>
		///// Выбранное доступное право
		///// </summary>
		//public Permission SelectedAvailablePermission { get; set; }
		///// <summary>
		///// Выбранное имеющиеся право
		///// </summary>
		//public Permission SelectedRolePermission { get; set; }
		///// <summary>
		///// Редактируемая роль
		///// </summary>
		//public Role Role { get; set; }

		///// <summary>
		///// Флаг режима редактирования.
		///// Если true, то режим редактирования роли
		///// </summary>
		//public bool IsEditMode { get; set; }

		//protected string pwd;
		//public RelayCommand SaveCommand => new RelayCommand( Save );
		//public RelayCommand AddPermCommand => new RelayCommand( AddPerm );
		//public RelayCommand RemovePermCommand => new RelayCommand( RemovePerm );

		//public ObservableCollection<Permission> RolePermissionSource
		//	=> new ObservableCollection<Permission>( RolePermissions ?? new List<Permission>() );

		//public ObservableCollection<Permission> AvailablePermissionSource
		// => new ObservableCollection<Permission>( AvailablePermissions ?? new List<Permission>() );


		//private void Save(object o = null)
		//{
		//	if (IsEditMode) // если режим редактирования
		//	{
		//		DbOperations.Update( Role );// просто обновим роль при изменении его данных
		//		DXMessageBox.Show("Успешно сохранено", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information);
		//	}
		//	else // иначе
		//	{
		//		DbOperations.Insert( Role ); // сохраняем роль
		//		var roleId = Role.Id;
		//		foreach (var perm in RolePermissions) // его новые права
		//		{
		//			DbOperations.Insert( new RolePermissionAssign() {
		//				Del = null,
		//				PermissionId = perm.Id,
		//				RoleId = roleId,
		//			} );
		//		}
		//		IsEditMode = true; // переходим их режима создания в режим редактирования
		//		DXMessageBox.Show( "Успешно сохранено", "Сохранение", MessageBoxButton.OK, MessageBoxImage.Information );
		//	}

		//}
		
		//private void AddPerm(object o = null)
		//{
		//	if (SelectedAvailablePermission != null)
		//	{
		//		if (IsEditMode)
		//			DbOperations.Insert( new RolePermissionAssign() {
		//				Del = null,
		//				PermissionId = SelectedAvailablePermission.Id,
		//				RoleId = Role.Id,
		//			} );

		//		AvailablePermissions.Remove( SelectedAvailablePermission );
		//		RolePermissions.Add( SelectedAvailablePermission );
		//		OnAllPropertyChanged();
		//	}
		//}

		//private void RemovePerm(object o = null)
		//{
		//	if (SelectedRolePermission != null)
		//	{
		//		if (IsEditMode)
		//			DeleteRelations( new RolePermissionAssign() {
		//				PermissionId = SelectedRolePermission.Id,
		//				RoleId = Role.Id
		//			} );

		//		RolePermissions.Remove( SelectedRolePermission );
		//		AvailablePermissions.Add( SelectedRolePermission );

		//		OnAllPropertyChanged();
		//	}
		//}
		
		//public static List<Permission> LoadAvailablePermissions()
		//	=> DbOperations.Select<Permission>();

		//public static List<Permission> LoadRolePermission(int roleId)
		//	=> LoadRelations<Permission, Role, RolePermissionAssign>( roleId );

		//public static RoleEditViewModel EditModeViewModel(Role role)
		//{
		//	var rolePerms = LoadRolePermission( role.Id ); // подгружаем права роли
		//	var availPerms = LoadAvailablePermissions() // подгружаем список прав
		//		.Where( x => !rolePerms.Any( x2 => x2.Id == x.Id ) ).ToList(); // убираем лишнее


		//	var newVM = new RoleEditViewModel() {
		//		Role = role,
		//		IsEditMode = true,
		//		AvailablePermissions = availPerms,
		//		RolePermissions = rolePerms,
		//	};
		//	return newVM;
		//}

		//public static RoleEditViewModel CreateModeViewModel()
		//{
		//	var newVM = new RoleEditViewModel() {
		//		Role = new Role() {
		//			Id = SetNewId<Role>()
		//		},
		//		IsEditMode = false,
		//		AvailablePermissions = LoadAvailablePermissions(),
		//		RolePermissions = new List<Permission>(),
		//	};
		//	return newVM;
		//}
		

	}
}
