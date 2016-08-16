using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.FiddlerPulgin
{
	public sealed class DbActionInfo
	{
		public static readonly string OpenConnectionFlag = "<open connection>";

		public TimeSpan Time { get; set; }

		public string SqlText { get; set; }

		public bool InTranscation { get; set; }

		public string ErrorMsg { get; set; }

		public List<CommandParameter> Parameters { get; set; }

		public static string Serialize(DbActionInfo info)
		{
			if( info == null )
				throw new ArgumentNullException("info");

			string json = Newtonsoft.Json.JsonConvert.SerializeObject(info);
			return CompressHelper.GzipCompress(json);
		}

		public static DbActionInfo Deserialize(string base64)
		{
			if( string.IsNullOrEmpty(base64) )
				throw new ArgumentNullException("base64");

			string json = CompressHelper.GzipDecompress(base64);
			return Newtonsoft.Json.JsonConvert.DeserializeObject<DbActionInfo>(json);
		}
				
	}


	public sealed class CommandParameter
	{
		public string Name { get; set; }

		public string DbType { get; set; }

		public string Value { get; set; }
	}
}
