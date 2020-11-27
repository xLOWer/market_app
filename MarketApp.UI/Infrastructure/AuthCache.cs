using System;
using System.Collections.Generic;
using MarketApp.DataModel.Market;
using Utilities.Settings;

namespace MarketApp.UI.Infrastructure
{
	public class AuthCache : Configuration<AuthCache>
	{
		public DateTime TokenExpirationDate { get; set; }
		public string UserName { get; set; }
		public string UserFio { get; set; }
		public decimal UserId { get; set; }
		[NonSerialized] public List<Permission> PermissionList=new List<Permission>();

		public const string ConfFileName = "auth_cache";
		[NonSerialized]
		private static volatile AuthCache _instance;
		[NonSerialized]
		private static readonly object syncRoot = new object();
		private AuthCache() { }
		public static AuthCache GetInstance()
		{
			if (_instance == null)
				lock (syncRoot)
					if (_instance == null)
					{
						AuthCache cache = new AuthCache().Load(ConfFileName);
						if (cache == null)
						{
							cache = new AuthCache()
							{
								TokenExpirationDate = DateTime.UtcNow.AddDays(-356)
							};
						}
						_instance = cache;
					}

			return _instance;
		}
	}
}
