using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownFish.Base.WebClient;

namespace ClownFish.PreheatWebSite
{
	class ScriptExecuteEventArgs : EventArgs
	{
		/// <summary>
		/// 当前执行第 N 个任务
		/// </summary>
		public int Index { get; set; }

		/// <summary>
		/// HTTP 请求参数
		/// </summary>
		public HttpOption Option { get; set; }

		/// <summary>
		/// 解析出来的请求信息
		/// </summary>
		public RequestInfo Request { get; set; }
	}


	class ScriptExecuteErrorEventArgs : ScriptExecuteEventArgs
	{
		public Exception Exception { get; set; }
	}
}
