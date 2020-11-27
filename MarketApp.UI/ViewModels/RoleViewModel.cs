using MarketApp.DataModel.Market;
using MarketApp.UI.ViewModels.VMBase;

namespace MarketApp.UI.ViewModels
{
	public class RoleViewModel : ListViewModel<Role>
	{
		//public bool CanDeleteRole => _cache.UserPermissions.Any( x => x.PermName == "DeleteRole" );
		//public bool CanViewRole => _cache.UserPermissions.Any( x => x.PermName == "ViewRole" );
		//public bool CanEditRole => _cache.UserPermissions.Any( x => x.PermName == "EditRole" );
		//public bool CanCreateRole => _cache.UserPermissions.Any( x => x.PermName == "CreateRole" );

		//public RoleViewModel()
		//{
		//	CreateAction = (o) => OnCreate();
		//	EditAction = (o) => OnEdit( SelectedItem );

		//	if (_conf.DebugModeEnabled) /* DEBUG */
		//	{
		//		//OnEdit( ItemsList.Where(x =>x.Id == 1).FirstOrDefault() );
		//		//RefreshCommand.Execute(null);
		//	}
		//}

		//private void OnEdit(Role editedItem)
		//{
		//	if (!CanEditRole)
		//		return;
		//	try
		//	{
		//		var NewWindow = _wnd.CreateNewWindow<RoleEditWindow>( "Роль" );
		//		var NewWindowContext = RoleEditViewModel.EditModeViewModel( editedItem );
		//		NewWindow.DataContext = NewWindowContext;
		//		_wnd.AddNewWindow( NewWindow );
		//		NewWindowContext.OnAllPropertyChanged();
		//	}
		//	catch (Exception ex)
		//	{
		//		_log.Error( ex );

		//	}
		//}

		//private void OnCreate()
		//{
		//	if (!CanCreateRole)
		//		return;
		//	try
		//	{
		//		var NewWindow = _wnd.CreateNewWindow<RoleEditWindow>( "Новая роль" );
		//		var NewWindowContext = RoleEditViewModel.CreateModeViewModel();
		//		NewWindow.DataContext = NewWindowContext;
		//		_wnd.AddNewWindow( NewWindow );
		//		NewWindowContext.OnAllPropertyChanged();
		//	}
		//	catch (Exception ex)
		//	{
		//		_log.Error( ex );

		//	}
		//}

		//public string GetConsumetItem()
		//{
		//	return "";
		//}

	}
}
