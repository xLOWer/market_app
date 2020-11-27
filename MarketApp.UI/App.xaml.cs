using System.Globalization;
using System.Threading;
using System.Windows;
using MarketApp.UI.Infrastructure;
using MarketApp.UI.ViewModels;
using MarketApp.UI.Views;
using Utilities.Logger;

namespace MarketApp.UI
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		WindowsService _wnd;
		public App()
		{
			CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-RU");
			Thread.CurrentThread.Name = "MainThread";
			Thread.CurrentThread.CurrentUICulture = culture;
			Thread.CurrentThread.CurrentCulture = culture;

			_wnd = WindowsService.GetInstance();
			var AuthWindow = _wnd.CreateNewWindow<AuthWindow>("Вход");
			var AuthWindowContext = new AuthViewModel();
			AuthWindow.DataContext = AuthWindowContext;
			AuthWindowContext.LogInSuccess += delegate // если форма ответила позитивно на проверку логина и пароля
			{
				LoginSuccess();
				AuthWindow.Close();
			};
			_wnd.AddNewWindow(AuthWindow);
			AuthWindow.InitializeComponent();

		}

		private void LoginSuccess()
		{
			var MainWindow = _wnd.CreateNewWindow<MainWindow>( "Реестр" );
			var MainWindowContext = new MainViewModel();
			MainWindow.DataContext = MainWindowContext;
			_wnd.AddNewWindow( MainWindow );
		}

		private void Application_Exit(object sender, ExitEventArgs e)
		{

			UtilityLog.GetInstance().Log( "Application_Exit" );
		}
	}
}
