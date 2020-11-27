using System;
using System.Collections.ObjectModel;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels.VMBase
{
	public abstract class ListViewModel<TEntity> : ViewModelBase where TEntity : class, new()
	{
		public virtual ObservableCollection<TEntity> ItemsList { get; set; }
		public virtual ObservableCollection<TEntity> SelectedItems { get; set; }
		public virtual TEntity SelectedItem { get; set; }
		public virtual bool IsItemSelected => SelectedItem != null || ItemsCount == 0;
		public virtual int ItemsCount => ItemsList?.Count ?? 0;

		public Action<TEntity> OnEdited = delegate { };
		public Action<TEntity> OnDeleted = delegate { };
		public virtual event Action OnCreated = delegate { };
		public virtual event Action OnRefreshed = delegate { };
		public virtual event Action OnLoaded = delegate { };

		public virtual RelayCommand CreateCommand => new RelayCommand( Create );
		public virtual RelayCommand EditCommand => new RelayCommand( Edit );
		public virtual RelayCommand DeleteCommand => new RelayCommand( Delete );
		public virtual RelayCommand RefreshCommand => new RelayCommand( Refresh );
		
		public void Create(object o = null)
		{
			SafeInvoke( OnCreated );
		}

		public void Edit(object o = null)
		{
			SafeInvoke( OnEdited, SelectedItem );
		}

		public void Delete(object o = null)
		{			
			SafeInvoke( OnDeleted, SelectedItem );
		}

		public void Refresh(object o = null)
		{
			SafeInvoke( OnRefreshed );
		}

		private void SafeInvoke(Action action)
		{
			try
			{
				if (action != null)
					action();
				OnAllPropertyChanged();
			}
			catch (Exception ex)
			{
				_log.Error( ex );
			}
		}

		private void SafeInvoke(Action<TEntity> action, TEntity arg)
		{
			try
			{
				if (action != null)
					action( arg );
				OnAllPropertyChanged();
			}
			catch (Exception ex)
			{
				_log.Error( ex );
			}
		}
	}
}
