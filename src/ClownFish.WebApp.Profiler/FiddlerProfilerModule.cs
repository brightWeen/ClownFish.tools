using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ClownFish.Base.TypeExtend;
using ClownFish.FiddlerPulgin;

namespace ClownFish.WebApp.Profiler
{
	public sealed class FiddlerProfilerModule : IHttpModule
	{
		internal static readonly string ContextItemKey = "9f5c9414-fdd5-4e40-ba18-e05d8296cfc1";

		private static readonly object s_lock = new object();
		private static bool s_inited = false;

		private static void Init()
		{
			if( s_inited == false ) {
				lock( s_lock ) {
					if( s_inited == false ) {
						// 订阅 ClownFish.Data.EventManager 的相关事件
						ExtenderManager.RegisterSubscriber(typeof(DataLayerEventSubscriber));
						s_inited = true;
					}
				}
			}
		}

		public void Init(HttpApplication app)
		{
			Init();

			app.PostResolveRequestCache += App_PostResolveRequestCache;
			app.PostRequestHandlerExecute += App_PostRequestHandlerExecute;
		}

		private void App_PostResolveRequestCache(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;
			string headerValue = app.Request.Headers["X-Fiddler-Profiler"];
			if( string.IsNullOrEmpty(headerValue) )
				return;


			// 如果Fiddler插件中的【数据库访问】 选项卡已启用
			if( headerValue.IndexOf("db") >= 0 ) {
				// 创建一个列表，用于存储当前请求过程中发生的数据访问操作
				app.Context.Items[ContextItemKey] = new List<DbActionInfo>(32);
			}
		}

		private void App_PostRequestHandlerExecute(object sender, EventArgs e)
		{
			HttpApplication app = (HttpApplication)sender;

			string headerValue = app.Request.Headers["X-Fiddler-Profiler"];
			if( string.IsNullOrEmpty(headerValue) )
				return;

			if( headerValue.IndexOf("ar") >= 0 )
				// 输入一个响应头，回应Fiddler插件，可用于分析不规范请求的响应头
				app.Response.Headers.Add("X-Fiddler-AnalyzeRequest", "OK");



			List<DbActionInfo> list = app.Context.Items[ContextItemKey] as List<DbActionInfo>;
			if( list == null || list.Count == 0 )
				return;


			// 计算数据库连接打开次数
			int connectionCount = 0;
			foreach( var info in list )
				if( info.SqlText == DbActionInfo.OpenConnectionFlag )
					connectionCount++;

			// 打开数据库的连接次数
			app.Response.Headers.Add("X-SQL-ConnectionCount", connectionCount.ToString());


			// 数据访问监控的响应头
			int index = 1;
			foreach( DbActionInfo info in list ) {
				string base64 = DbActionInfo.Serialize(info);
				string headerName = "X-SQL-Action-" + (index++).ToString();
				app.Response.Headers.Add(headerName, base64);
			}
		}

		public void Dispose()
		{
		}
	}
}
