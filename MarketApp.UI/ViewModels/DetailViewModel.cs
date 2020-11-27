using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MarketApp.DataModel.Market;
using MarketApp.UI.ViewModels.VMBase;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels
{
	public class DetailViewModel : EditViewModel<Detail>
	{
		public DocsToDetails Link { get; set; }
		public List<BudgetItem> BudgetItemList { get; set; }
		public bool IsEditMode { get; set; } = true;

		private void OnCreate(DocAmend doc)
		{			
			Item = _context.Details.Create();
			Link = _context.DocsToDetails.Create();
			Link.IdDoc = doc.Id;
			Link.IdDetail = Item.Id;
			Link.DocAmend = doc;
			Link.Detail = Item;
		}

		private void OnEdit(DocAmend doc, Detail detail)
		{
			Link = _context.DocsToDetails.Single( x => x.IdDoc == doc.Id && x.IdDetail == detail.Id );
			Item = _context.Details.Single( x => x.Id == detail.Id );
		}

		public DetailViewModel(DocAmend doc, Detail detail = null) : this()
		{
			IsEditMode = detail != null;
			if (!IsEditMode)
				OnCreate(doc);
			else
				OnEdit( doc, detail );			
			OnAllPropertyChanged();
		}

		public DetailViewModel()
		{
			OnSaved += SaveAction;
			BudgetItemList = _context.BudgetItems.AsNoTracking().ToList();
		}

		private void SaveAction()
		{
			if (!IsEditMode)// если создаём
			{
				if (Item.IdBudget != null)
					Item.BudgetItem = _context.BudgetItems.Single(x=>x.Id == Item.IdBudget);
				_context.Details.Add( Item );
				_context.DocsToDetails.Add(Link);
			}
			else// если редактируем
			{
				if (Item.IdBudget != null)
					Item.BudgetItem = _context.BudgetItems.Single( x => x.Id == Item.IdBudget );
				_context.Entry( Item ).State = EntityState.Modified;
				_context.Entry( Link ).State = EntityState.Modified;
			}
			_context.SaveChanges();
			OnAllPropertyChanged();
		}

		public RelayCommand FillCommand => new RelayCommand( x => 
		{
			Item.BudgetItem = BudgetItemList.FirstOrDefault();
			Item.IdBudget = Item.BudgetItem.Id;
			Item.PlanSum = 334;
			Item.Coment = "some comment";
			OnAllPropertyChanged();
		} );


	}
}
