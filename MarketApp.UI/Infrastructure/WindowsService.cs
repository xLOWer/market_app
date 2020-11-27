using System;
using System.Collections.Generic;
using System.Windows;
using Utilities.Settings;

namespace MarketApp.UI.Infrastructure
{
	public class WindowsService
	{
		private Config _conf = Config.GetInstance();
		private UILogger _log = UILogger.GetInstance();
		public List<Window> Windows { get; set; } = new List<Window>();
		
		public void AddNewWindow(Window window)
		{
			Windows.Add( window );
			window.Show();
			window.Activate();
		}

		public TWindow CreateNewWindow<TWindow>(string title) where TWindow : Window, new()
		{
			if (Windows.Count >= _conf.MaxOpenedWindowsCount)
				throw new Exception( $"Вы не можете открыть больше {_conf.MaxOpenedWindowsCount} окон одновременно!" );

			var Window = new TWindow {
				Title = title
			};
			Window.Closed += Window_Closed;
			return Window;
		}

		public TWindow CreateNewWindow<TWindow>(string title, object context) where TWindow : Window, new()
		{
			if (Windows.Count >= _conf.MaxOpenedWindowsCount)
				throw new Exception( $"Вы не можете открыть больше {_conf.MaxOpenedWindowsCount} окон одновременно!" );

			var Window = new TWindow {
				Title = title
			};
			Window.DataContext = context;
			Window.Closed += Window_Closed;

			Windows.Add( Window );
			Window.Show();
			Window.Activate(); 

			return Window;
		}

		public void Window_Closed(object sender, EventArgs e)
		{
			var window = sender as Window;
			if (Windows.Contains( window ))
			{
				Windows.Remove( window );
			}
		}
		
		public void Stop()
		{
			foreach (var wnd in Windows)
			{
				try
				{
					wnd.Close();
				}
				catch (Exception ex)
				{

				}
			}
		}




		[NonSerialized]
		private static volatile WindowsService _instance;
		[NonSerialized]
		private static readonly object syncRoot = new object();
		private WindowsService() { }
		public static WindowsService GetInstance()
		{
			if (_instance == null)
				lock (syncRoot)
					if (_instance == null)
						_instance = new WindowsService();
			return _instance;
		}


	}
}
