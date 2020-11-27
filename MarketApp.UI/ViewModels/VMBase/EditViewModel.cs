using System;
using Utilities.MVVM;

namespace MarketApp.UI.ViewModels.VMBase
{
	abstract public class EditViewModel<TEntity> : ViewModelBase where TEntity : class, new()
	{
		public TEntity Item { get; set; }

		public virtual RelayCommand AbortCommand { get; set; }
		public virtual RelayCommand CancelCommand => new RelayCommand( OnCancel );
		public virtual RelayCommand CreateCommand => new RelayCommand( Create );
		public virtual RelayCommand SaveCommand => new RelayCommand( Save );
		public virtual RelayCommand SaveAndExitCommand => new RelayCommand( SaveAndExit );
		
		public event Action<object> OnCancel = delegate { };
		public event Action OnDeleted = delegate { };
		public event Action OnCreated = delegate { };
		public event Action OnSaved = delegate { };
		
		public void Delete(object o = null)
		{
			SafeInvoke( OnDeleted );
		}

		public void Save(object o = null)
		{
			SafeInvoke( OnSaved );
		}

		public void SaveAndExit(object o = null)
		{
			SaveCommand.Execute( o );
			CancelCommand.Execute( o );
		}

		public void Create(object o = null)
		{
			SafeInvoke(OnCreated);
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
		
	}
}
