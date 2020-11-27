using System;
using System.IO;
using Newtonsoft.Json;

namespace Helpers.Settings
{
	public abstract class Configuration<TConfig> where TConfig : class
	{
		private const string ConfigFolder = "conf";

		private string Path(string FileName) => ConfigFolder + "\\" + FileName;

		public TConfig Load(string FileName)
		{
			var path = Path( FileName );

			if (!File.Exists( path ))
			{
				return default( TConfig );
			}

			using (FileStream fs = new FileStream( path, FileMode.OpenOrCreate ))
			{
				using (StreamReader sr = new StreamReader( fs ))
				{
					return JsonConvert.DeserializeObject<TConfig>( sr.ReadToEnd() );
				}
			}
		}

		//public abstract string ValidateParameters(Action<string> errorCallback = null);

		public void Save(TConfig config, string FileName)
		{

			JsonSerializer serializer = new JsonSerializer();
			serializer.NullValueHandling = NullValueHandling.Ignore;

			using (StreamWriter sw = new StreamWriter( Path( FileName ) ))
			using (JsonWriter writer = new JsonTextWriter( sw ))
			{
				serializer.Serialize( writer, config );
			}

		}

	}
}
