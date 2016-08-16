using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.PreheatWebSite
{
	internal class ExecuteInfo
	{
		public string FilePath { get; set; }
		public string FileContext { get; set; }

		public List<RequestInfo> List { get; set; }

		public string TargetSite { get; set; }

		public string CsCode { get; set; }

		public Dictionary<string, string> Parameters { get; set; }

		public string GetParameter(string name)
		{
			if( this.Parameters == null )
				return null;

			string value = null;
			this.Parameters.TryGetValue(name, out value);
			return value;
		}

	}

	internal class ResultSummary
	{
		public int ErrorCount { get; set; }

		public string Message { get; set; }
		
	}


	internal class RequestInfo
	{
		public string SiteRoot { get; set; }

		public string RelativeUrl { get; set; }

		/// <summary>
		/// 实际的请求地址： 用户指定的网站根地址 + URL中的相对路径
		/// </summary>
		public string RealUrl { get; set; }

		public string Text { get; set; }


		public ExecuteResult Result { get; set; }

		public string GettLogText()
		{
			StringBuilder message = new StringBuilder();
			//ScriptExecutor.AppendLog(message, "实际请求地址：", this.RealUrl);
			ScriptExecutor.AppendLog(message, "实际请求：", this.Result.RequestText);
			ScriptExecutor.AppendLog(message, "脚本内容：", this.Text);


			if( this.Result != null ) {

				if( this.Result.Exception == null ) {
					if( this.Result.Response == null )
						ScriptExecutor.AppendLog(message, "执行结果：", "正在发起请求。");
					else
						ScriptExecutor.AppendLog(message, "执行结果：", "请求成功。");
				}
				else
					ScriptExecutor.AppendLog(message, "异常信息：", this.Result.Exception.ToString());


				if( string.IsNullOrEmpty(this.Result.Response) == false )
					ScriptExecutor.AppendLog(message, "服务端返回结果：", this.Result.Response);
			
			}

			return message.ToString();
		}
	}


	internal class ExecuteResult
	{
		public string RequestText { get; set; }
		public Exception Exception { get; set; }

		public string Response { get; set; }

		public TimeSpan? Time { get; set; }
	}
}
