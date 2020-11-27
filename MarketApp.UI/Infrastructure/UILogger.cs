using System;
using System.Windows;
using DevExpress.Xpf.Core;
using Utilities.Logger;

namespace MarketApp.UI.Infrastructure
{
	public class UILogger
	{
		private UtilityLog _log = UtilityLog.GetInstance();

		public void Log(string Message)
		{
			var msg = _log.Log( Message );
			UIShowMessage( msg );
		}

		public void Log(Exception Exception)
		{
			var msg = _log.Log( Exception );
			UIShowMessage( msg );
		}

		public void Error(Exception Exception)
		{
			var msg = _log.Error( Exception );
			UIShowError( msg );
		}

		public void Error(string errorText)
		{
			var msg = _log.Log( errorText );
			UIShowError(msg);
		}
		
		public void Mail(Exception exception)
		{
			var msg = _log.Mail( exception );
			UIShowMessage( msg );
		}

		public void Mail(string message)
		{
			var msg = _log.Mail( message );
		}

		public void UIShowMessage(string Msg)
		{
			MessageBox.Show( Msg, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information );
		}

		public void UIShowError(string Err)
		{
			DXMessageBox.Show( Err, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error );
		}




		[NonSerialized]
		private static volatile UILogger _instance;
		[NonSerialized]
		private static readonly object syncRoot = new object();
		private UILogger() { }
		public static UILogger GetInstance()
		{
			if (_instance == null)
			{
				lock (syncRoot)
				{
					if (_instance == null)
					{
						_instance = new UILogger();
					}
				}
			}

			return _instance;
		}

	}
}
