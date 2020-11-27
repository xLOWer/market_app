using MarketApp.DataModel.Market;
using MarketApp.UI.ViewModels.VMBase;

namespace MarketApp.UI.ViewModels
{
	public class UserViewModel : ListViewModel<User>
	{
		//public bool CanDeleteWebUser => _cache.UserPermissions.Any(x => x.PermName == "DeleteWebUser");
		//public bool CanViewWebUser => _cache.UserPermissions.Any( x => x.PermName == "ViewWebUser" );
		//public bool CanEditWebUser => _cache.UserPermissions.Any( x => x.PermName == "EditWebUser" );
		//public bool CanCreateWebUser => _cache.UserPermissions.Any( x => x.PermName == "CreateWebUser" );

		//public UserViewModel()
		//{
		//	CreateAction = (o) => OnCreate();
		//	EditAction = (o) => OnEdit( SelectedItem );

		//	if (_conf.DebugModeEnabled) /* DEBUG */
		//	{
		//		//OnEdit( ItemsList.Where(x =>x.Id == 1).FirstOrDefault() );
		//	}
		//}

		//private void OnEdit(User editedItem)
		//{
		//	if (!CanEditWebUser) return;
		//	try
		//	{
		//		var NewWindow = _wnd
		//			.CreateNewWindow<UserEditWindow>("Пользователь");
		//		var NewWindowContext = UserEditViewModel.EditModeViewModel( editedItem );
		//		NewWindow.DataContext = NewWindowContext;
		//		_wnd.AddNewWindow(NewWindow);
		//		NewWindowContext.OnAllPropertyChanged();
		//	}
		//	catch (Exception ex)
		//	{
		//		_log.Error( ex ); 

		//	}
		//}

		//private void OnCreate()
		//{
		//	if (!CanCreateWebUser)
		//		return;
		//	try
		//	{
		//		var NewWindow = _wnd
		//			.CreateNewWindow<UserEditWindow>("Новый пользователь");
		//		var NewWindowContext = UserEditViewModel.CreateModeViewModel();
		//		NewWindow.DataContext = NewWindowContext;
		//		_wnd.AddNewWindow(NewWindow);
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
