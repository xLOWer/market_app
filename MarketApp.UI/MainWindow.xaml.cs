using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Ribbon;
using MarketApp.DataModel.Market;
using MarketApp.UI.ViewModels;

namespace MarketApp.UI
{
	public partial class MainWindow : DXRibbonWindow
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		
		private void DocumentsDataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
		{
			var ischecked = (bool?)FullDocSelector.EditValue;
			if (ischecked.HasValue && e.ControllerRow > 0)
			{
				if (ischecked.Value)
				{
					var s = sender as GridControl;
					var itemSource = s.ItemsSource as ObservableCollection<DocsToDetails>;
					var item = itemSource.ElementAt( e.ControllerRow );
					var __docId = item.IdDoc;
					var forChange = itemSource.Where( x => x.IdDoc == __docId && x.Id != item.Id ).ToList();
					if (e.Action == System.ComponentModel.CollectionChangeAction.Add)
					{
						foreach (var itm in forChange)
							s.SelectedItems.Add( itm );
					}
					if (e.Action == System.ComponentModel.CollectionChangeAction.Remove)
					{
						foreach (var itm in forChange)
							s.SelectedItems.Remove( itm );
					}

				}
			}
			(DataContext as MainViewModel).OnAllPropertyChanged();

			//if ((DataContext as MainViewModel).OnRefreshed != null){ view1.BestFitColumns(); }

		}

		const string fileName = "gridlayout.xml";
		private void DXRibbonWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
			if(File.Exists( fileName ))
				DocumentsDataGrid.RestoreLayoutFromXml( fileName );
		}

		private void DXRibbonWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			DocumentsDataGrid.SaveLayoutToXml( fileName );
		}
	}
}
