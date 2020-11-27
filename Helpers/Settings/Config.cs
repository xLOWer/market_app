using System;

namespace Helpers.Settings
{
	public class Config : Configuration<Config>
	{
		public bool DebugModeEnabled { get; set; }
		public bool TestModeEnabled { get; set; }
		public int MaxOpenedWindowsCount { get; set; }
		public int TokenExpirationHours { get; set; }

		public string MarketConnectionString { get; set; }

		public bool ProxyEnabled { get; set; }
		public string ProxyAddress { get; set; }
		public string ProxyUserName { get; set; }
		public string ProxyUserPassword { get; set; }

		public string MailSmtpServerAddress { get; set; }
		public string MailUserLogin { get; set; }
		public string MailUserPassword { get; set; }
		public string MailUserEmailAddress { get; set; }
		public string MailErrorSubject { get; set; }

		//public override string ValidateParameters(Action<string> errorCallback = null)
		//{
		//	string parametersErrorList = "\r\nВ конфигурационном файле обранужены ошибки. Рекомендации по устранению:\r\n";
		//	bool hasErrors = false;

		//	if (string.IsNullOrEmpty(MarketConnectionString))
		//	{
		//		parametersErrorList += $"- обязательный параметр {nameof( MarketConnectionString )} должен быть валидной строкой подключения к БД\r\n";
		//		hasErrors = true;
		//	}

		//	if (MaxOpenedWindowsCount <= 4)
		//	{
		//		parametersErrorList += $"- обязательный параметр {nameof( MaxOpenedWindowsCount )} должен быть >= 4\r\n";
		//		hasErrors = true;
		//	}

		//	if (TokenExpirationHours <= 2)
		//	{
		//		parametersErrorList += $"- обязательный параметр {nameof( TokenExpirationHours )} должен быть >= 2\r\n";
		//		hasErrors = true;
		//	} 
		//	if(hasErrors)
		//		if (errorCallback != null)
		//			errorCallback.Invoke( parametersErrorList );

		//	return parametersErrorList;
		//}

		private Config()
		{
			DebugModeEnabled = false;
			TestModeEnabled = false;
			MarketConnectionString = "";
			ProxyEnabled = false;
			ProxyAddress = "";
			ProxyUserName = "";
			ProxyUserPassword = "";
			MailSmtpServerAddress = "";
			MailUserLogin = "";
			MailUserPassword = "";
			MailUserEmailAddress = "";
			MailErrorSubject = "";
			MaxOpenedWindowsCount = 8;
			TokenExpirationHours = 4;
		}
		[NonSerialized]
		public const string ConfFileName = "config.json";
		[NonSerialized]
		private static volatile Config _instance;
		[NonSerialized]
		private static readonly object syncRoot = new object();
		public static Config GetInstance()
		{
			if (_instance == null)
				lock (syncRoot)
					if (_instance == null)
						_instance = new Config().Load( ConfFileName );
			return _instance;
		}
	}
}
