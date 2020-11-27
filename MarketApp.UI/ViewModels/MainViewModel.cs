using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Core;
using MarketApp.DataModel.Market;
using MarketApp.UI.ViewModels.VMBase;
using MarketApp.UI.Views;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels
{
	public sealed class MainViewModel : ListViewModel<DocsToDetails>
	{
		public override DocsToDetails SelectedItem
		{
			get {
				if (SelectedItems != null)				
					if (SelectedItems.Count != 0)					
						return SelectedItems.First();
				return null;
			}
		}
			
		public RelayCommand SetOriginalCommand => new RelayCommand( x => {
			foreach (var item in SelectedItems.Select(o => o.DocAmend))
			{
				item.HasOriginal = true;
				_context.Entry( item ).State = EntityState.Modified;
			}
			_context.SaveChanges();
		} );

		public RelayCommand UnsetOriginalCommand => new RelayCommand( x => {
			foreach (var item in SelectedItems.Select( o => o.DocAmend ))
			{
				item.HasOriginal = false;
				_context.Entry( item ).State = EntityState.Modified;
			}
			_context.SaveChanges();
		} );

		public RelayCommand TestCommand => new RelayCommand( x => {
			string text = "";
			text += SetMessage( "UserName=" + _cache.UserName );
			text += SetMessage( "UserFio=" + _cache.UserFio );
			text += SetMessage( "UserId=" + _cache.UserId );
			text += SetMessage( "SelectedItemsCount=" + SelectedItems?.Count ?? "" );
			text += SetMessage( "SelectedItemsDateCreate=" 
				+ SelectedItem?.CreatedDate.ToShortDateString() ?? ""
				+ " "+ SelectedItem?.CreatedDate.ToShortTimeString() ?? "" );

			MessageBox.Show( text, "test message", MessageBoxButton.OK);
		} );

		private string SetMessage(object y) => y.ToString() + "\r\n";
		



		public MainViewModel()
		{
			SelectedItems = new ObservableCollection<DocsToDetails>();
			OnCreated += CreateAction;
			OnEdited += EditAction;
			OnDeleted += DeleteAction;
			OnRefreshed += RefreshAction;
			RefreshCommand.Execute( null );
			if (_conf.DebugModeEnabled || _conf.TestModeEnabled) /* DEBUG */
			{
				//CreateCommand.Execute(null);
			}
			OnAllPropertyChanged();
		}
		public int Filter_Year { get; set; } = DateTime.Now.Year;

		public bool CanViewRegister => _cache.PermissionList.Any( x => x.PermName == "ViewRegister" );
		public bool CanCreateDocAmend => _cache.PermissionList.Any( x => x.PermName == "CreateDocAmend" );
		public bool CanEditDocAmend => _cache.PermissionList.Any( x => x.PermName == "EditDocAmend" );
		public bool CanDeleteDocAmend => _cache.PermissionList.Any( x => x.PermName == "DeleteDocAmend" );
		public bool CanViewWebUser => _cache.PermissionList.Any( x => x.PermName == "ViewWebUser" );
		public bool CanViewRole => _cache.PermissionList.Any( x => x.PermName == "ViewRole" );

		public bool CanMoveStatusNext => IsItemSelected &&
			 (((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 1 &&
			   _cache.PermissionList.Any( x => x.PermName == "StatusCreateBukh" )) || // если статус "Создан"  И  мы имеем право двигать дальше  ИЛИ ...
			 ((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 2 &&
			  _cache.PermissionList.Any( x => x.PermName == "StatusBukhWork" )) || // ... ИЛИ ...
			 ((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 3 &&
			  _cache.PermissionList.Any( x => x.PermName == "StatusWorkWait" )) || // думаю смысл понятен
			 ((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 4 &&
			  _cache.PermissionList.Any( x => x.PermName == "StatusWaitClose" ))); // дальше по этому принципу все

		public bool CanMoveStatusPrev => IsItemSelected &&
			(((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 2 &&
			  _cache.PermissionList.Any( x => x.PermName == "StatusBukhCreate" )) ||
			((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 3 &&
			 _cache.PermissionList.Any( x => x.PermName == "StatusWorkBukh" )) ||
			((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 4 &&
			 _cache.PermissionList.Any( x => x.PermName == "StatusWaitWork" )) ||
			((SelectedItem?.DocAmend?.DocStatus?.Order ?? -1) == 5 &&
			 _cache.PermissionList.Any( x => x.PermName == "StatusCloseWait" )));
		
		public RelayCommand OpenUserWindowCommand => new RelayCommand( x => {
			if (!CanViewWebUser)
				return;
			//var UserWindow = _wnd.CreateNewWindow<UserWindow>( "Пользователи" );
			//var UserWindowContext = new UserViewModel();
			//UserWindow.DataContext = UserWindowContext;
			//_wnd.AddNewWindow( UserWindow );
		} );

		public RelayCommand OpenRoleWindowCommand => new RelayCommand( x => {
			if (!CanViewRole)
				return;
			//var RoleWindow = _wnd.CreateNewWindow<RoleWindow>( "Роли" );
			//var RoleWindowContext = new RoleViewModel();
			//RoleWindow.DataContext = RoleWindowContext;
			//_wnd.AddNewWindow( RoleWindow );
		} );

		public RelayCommand PrevStatusCommand => new RelayCommand( x => {
			var i = SelectedItems.Select( c => c.DocAmend ).Distinct().Count() > 1;
			if (i)
				_log.UIShowMessage( "Смену статуса необходимо проводить в рамках одного документа. Выберите позиции одного докумена или одну позицию." );
			if (!CanMoveStatusPrev)
				_log.UIShowMessage( "У вас нет прав для изменения статуса" );
			if (!CanMoveStatusPrev || i)
				return;
			SelectedItem.DocAmend.DocStatus =
				_context.Statuses
					.FirstOrDefault( c => c.Order == SelectedItem.DocAmend.DocStatus.Order - 1 );
			_context.SaveChanges();
			RefreshCommand.Execute(null);
		} );

		public RelayCommand NextStatusCommand => new RelayCommand( x => {
			var i = SelectedItems.Select( c => c.DocAmend ).Distinct().Count() > 1;
			if (i)
				_log.UIShowMessage("Смену статуса необходимо проводить в рамках одного документа. Выберите позиции одного докумена или одну позицию.");
			if (!CanMoveStatusNext)
				_log.UIShowMessage("У вас нет прав для изменения статуса");
			if (!CanMoveStatusNext || i)
				return;
			SelectedItem.DocAmend.DocStatus =
				_context.Statuses
					.FirstOrDefault(c => c.Order == SelectedItem.DocAmend.DocStatus.Order + 1);
			_context.SaveChanges();
			RefreshCommand.Execute( null );
		} );

		
		private void DeleteAction(DocsToDetails deletingEntity )
		{
			if (DXMessageBox.Show( "Удаление",
					"Вы уверены, что хотите удалить?",
					MessageBoxButton.YesNo,
					MessageBoxImage.Question ) == MessageBoxResult.No)
				return;
			foreach(var item in SelectedItems)
			{
				item.DeletedDate = DateTime.Now;
				item.Detail.DeletedDate = DateTime.Now;
			}
			_context.SaveChanges();
			RefreshCommand.Execute( null );
		}

		private void EditAction(DocsToDetails e)
		{
			if (!CanEditDocAmend || SelectedItem == null)
				return;
			var NewWindow = _wnd
				.CreateNewWindow<DocAmendWindow>( $"Документ (Статус: {SelectedItem?.DocAmend.DocStatus.Name ?? "неизвестно"})" );
			var NewWindowContext = new DocAmendViewModel( SelectedItem.DocAmend );
			NewWindow.DataContext = NewWindowContext;
			NewWindowContext.OnCancel += delegate {NewWindow.Close();};
			NewWindowContext.OnSaved += delegate 
			{
				RefreshCommand.Execute(null);
			};
			_wnd.AddNewWindow( NewWindow );
		}

		private void CreateAction()
		{
			if (!CanCreateDocAmend)
				return;
			var NewWindow = _wnd
				.CreateNewWindow<DocAmendWindow>( $"Документ" );
			var NewWindowContext = new DocAmendViewModel( );
			NewWindow.DataContext = NewWindowContext;
			NewWindowContext.OnCancel += delegate { NewWindow.Close(); };
			NewWindowContext.OnSaved += delegate {
				RefreshCommand.Execute( null );
			};
			_wnd.AddNewWindow( NewWindow );
		}

		public RelayCommand CopyDocCommand => new RelayCommand( x => {
			if (!CanCreateDocAmend || SelectedItem == null)
				return;
			var NewWindow = _wnd.CreateNewWindow<DocAmendWindow>( "Документ" );
			DocAmendViewModel NewWindowContext;
			var Doc = _context.DocAmends.Create();
			Doc.Company = SelectedItem.DocAmend.Company;
			Doc.CompanyId = SelectedItem.DocAmend.CompanyId;
			Doc.Provider = SelectedItem.DocAmend.Provider;
			Doc.ProviderId = SelectedItem.DocAmend.ProviderId;
			Doc.PayMethod = SelectedItem.DocAmend.PayMethod;
			Doc.PayMethodId = SelectedItem.DocAmend.PayMethodId;
			Doc.DocStatus = _context.Statuses.Single(c=>c.Order == 1);
			//Doc.AccrualDate = DateTime.Now;
			Doc.RegDate = DateTime.Now;
			Doc.StatusId = Doc.DocStatus.Id;
			Doc.UserCreator = _context.Users.Single(c=>c.Id == _cache.UserId);
			Doc.IdUserCreator = Doc.UserCreator.Id;
			_context.DocAmends.Add(Doc);			
			//_context.Entry( Doc ).State = EntityState.Added;
			_context.SaveChanges();
			NewWindowContext = new DocAmendViewModel( Doc );
			NewWindowContext.OnAllPropertyChanged();
			NewWindow.DataContext = NewWindowContext;
			NewWindowContext.OnCancel += delegate { NewWindow.Close(); };
			NewWindowContext.OnSaved += delegate {
				RefreshCommand.Execute( null );
			};
			_wnd.AddNewWindow( NewWindow );
		} );

		private void RefreshAction()
		{
			ItemsList = _context.DocsToDetails
				//.AsNoTracking()
				.Where( c => c.Detail.AccrualDate.Year == Filter_Year && c.DeletedDate == null )
				.ToObservableCollection();
		}





	}
}
