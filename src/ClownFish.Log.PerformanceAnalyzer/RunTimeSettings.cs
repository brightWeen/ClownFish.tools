using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.Log.PerformanceAnalyzer
{
	public class RunTimeSettings
	{
		/// <summary>
		/// MongoDb数据库的连接字符串（它应该是日志库）
		/// </summary>
		public string MongoDbConnectionString { get; set; }

		/// <summary>
		/// 登录Cookie名称
		/// </summary>
		public string LoginCookieName { get; set; }

		/// <summary>
		/// 登录请求的原始文本
		/// </summary>
		public ClownFish.Base.Xml.XmlCdata LoginRequestRaw { get; set; }


		internal static RunTimeSettings LoadSettings()
		{
			string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RunTimeSettings.config");
			return ClownFish.Base.Xml.XmlHelper.XmlDeserializeFromFile<RunTimeSettings>(configFilePath);
		}


		internal void SaveSettings()
		{

		}

	}
}
