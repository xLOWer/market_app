using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using DevExpress.Mvvm.Native;
using MarketApp.DataModel.Market;
using MarketApp.UI.ViewModels.VMBase;
using MarketApp.UI.Views;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels
{
	public class DocAmendViewModel : EditViewModel<DocAmend>
	{
		public DocAmendViewModel(DocAmend doc = null)
		{ 
			IsEditMode = doc != null;
			if (IsEditMode)
			{
				RefreshAction(doc.Id);
				DetailList = Item.DocToDetails.Select( x => x.Detail ).ToObservableCollection();
			}
			else
			{
				Item = _context.DocAmends.Create();
				Item.UserCreator = _context.Users.Single( x => x.Id == _cache.UserId );
				Item.IdUserCreator = _cache.UserId;
				Item.DocStatus = _context.Statuses.Single( x => x.Order == 1 );
				Item.StatusId = _context.Statuses.Single( x => x.Order == 1 ).Id;
				DetailList = Item.DocToDetails.Select( x => x.Detail ).ToObservableCollection();
			}
			Init();
			OnAllPropertyChanged();
		}

		private void Init()
		{			
			OnSaved += SaveAction;
			CompanyList = _context.Companies.ToObservableCollection();
			ProviderList = _context.Providers.ToObservableCollection();
			PayMethodList = _context.PayMethods.ToObservableCollection();
			CommentList = _context.Comments.ToObservableCollection();
			//RefreshAction();
		}

		private void RefreshAction(string Guid = null)
		{
			if (string.IsNullOrEmpty( Guid ))
				Guid = Item.Id;
			Item = _context.DocAmends.Single( x => x.Id == Guid );
			RefreshDetailsAction();
			OnAllPropertyChanged();
		}

		private void RefreshDetailsAction()
		{
			DetailList = Item.DocToDetails.Select( x => x.Detail ).ToObservableCollection();			
			OnAllPropertyChanged();
		}

		public ObservableCollection<Detail> DetailList { get; set; }
		public ObservableCollection<Company> CompanyList { get; set; }
		public ObservableCollection<Provider> ProviderList { get; set; }
		public ObservableCollection<PayMethod> PayMethodList { get; set; }
		public ObservableCollection<Comment> CommentList { get; set; }
		public bool IsEditMode { get; set; }
		private Detail _selectedDetail = new Detail();
		public Detail SelectedDetail
		{
			get => _selectedDetail;
			set {
				_selectedDetail = value;
				RaiseNotifyPropertyChanged( nameof( SelectedDetail ) );
			}
		}

		private void SaveAction()
		{
			if (IsEditMode)
			{
				if (Item.DocToDetails.Count > 1)
				{
					if (Item.DocToDetails.Any( x => x.IdDetail == null ))
					{
						_context.DocsToDetails.Remove( Item.DocToDetails.Single( x => x.IdDetail == null ) );
					}
				}
				_context.Entry( Item ).State = EntityState.Modified;
			}
			else
			{
				if (Item.DocToDetails.Count < 1)
				{
					_context.DocAmends.Add( Item );
					var link = new DocsToDetails() {
						IdDoc = Item.Id
					};

					//link.UserCreator = _context.Users.Single( x => x.Id == _cache.UserId );
					//link.IdUserCreator = _cache.UserId;
					_context.DocsToDetails.Add( link );
				}
			}

			_context.SaveChanges();
			RefreshDetailsAction();
		}
		
		/* DETAIL WORKING */

		public bool CanCreateDocAmendDetail => _cache.PermissionList.Any( x => x.PermName == "CreateDocAmendDetail" );
		public bool CanEditDocAmendDetail => _cache.PermissionList.Any( x => x.PermName == "EditDocAmendDetail" ) && SelectedDetail != null;
		public bool CanDeleteDocAmendDetail => _cache.PermissionList.Any( x => x.PermName == "DeleteDocAmendDetail" ) && SelectedDetail != null;

		public RelayCommand AddDetailCommand => new RelayCommand( AddDetailAction );
		public RelayCommand DeleteDetailCommand => new RelayCommand( DeleteDetailAction );
		public RelayCommand EditDetailCommand => new RelayCommand( EditDetailAction );
		
		private void AddDetailAction(object o = null)
		{
			if (!CanCreateDocAmendDetail)
				return;
			try
			{
				var NewWindow = _wnd.CreateNewWindow<DetailWindow>("Новый расход");
				var NewWindowContext = new DetailViewModel(Item);
				NewWindow.DataContext = NewWindowContext;
				NewWindowContext.OnCancel += delegate { NewWindow.Close(); };
				NewWindowContext.OnSaved += delegate
				{
					NewWindow.Close();
					RefreshDetailsAction();
					OnAllPropertyChanged();
				};
				_wnd.AddNewWindow(NewWindow);
				NewWindow.InitializeComponent();
			}
			catch (Exception ex)
			{
				_log.Error( ex ); 
			}
		}

		private void DeleteDetailAction(object o = null)
		{
			if (!CanDeleteDocAmendDetail)
			{
				DocsToDetails link = Item.DocToDetails.FirstOrDefault(x => x.IdDetail == SelectedDetail.Id);
				if(link != null)
				{
					link.IdDoc = null;
					SelectedDetail.DeletedDate = DateTime.Now;
					link.DeletedDate = DateTime.Now;
				}
				_context.SaveChanges();
				RefreshAction();
			}
		}

		private void EditDetailAction(object o = null)
		{
			if (!CanEditDocAmendDetail)
				return;

			if (SelectedDetail == null)
				return;
			try
			{
				var NewWindow = _wnd.CreateNewWindow<DetailWindow>("Редактирование расхода");
				var NewWindowContext = new DetailViewModel( Item, SelectedDetail );
				NewWindow.DataContext = NewWindowContext;
				NewWindowContext.OnCancel += delegate { NewWindow.Close(); };
				NewWindowContext.OnSaved += delegate
				{
					NewWindow.Close();
					RefreshDetailsAction();
					OnAllPropertyChanged();
				};
				_wnd.AddNewWindow(NewWindow);
			}
			catch (Exception ex)
			{
				_log.Error( ex ); 
			}
		}
		
	}
}
