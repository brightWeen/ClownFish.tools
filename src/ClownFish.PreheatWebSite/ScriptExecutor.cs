using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClownFish.Base;
using ClownFish.Base.WebClient;

namespace ClownFish.PreheatWebSite
{
	internal class ScriptExecutor
	{
		private ExecuteInfo _currentExecuteInfo = null;
		private int _errorCount = 0;
		//private string _loginCookie;

		// 服务端产生的新COOKIE	
		private List<NameValue> _setCookies = new List<NameValue>();

		public event EventHandler<ScriptExecuteEventArgs> BeforeExecute;

		public event EventHandler<ScriptExecuteEventArgs> AfterExecute;

		public event EventHandler<ScriptExecuteErrorEventArgs> ExecuteError;

		/// <summary>
		/// 用于提取请求脚本中的参数占位符
		/// 例如：aa{@loginPostData}bbb{@xxxx}
		/// </summary>
		private static readonly Regex s_parameterRegex
			= new Regex(@"\{@(?<name>\w+)\}", RegexOptions.IgnoreCase | RegexOptions.Compiled);


		public static StringBuilder AppendLog(StringBuilder sb, string title, string message)
		{
			return sb
					.AppendLine("============================================")
					.AppendLine(title)
					.AppendLine("============================================")
					.AppendLine(message)
					.AppendLine("\r\n\r\n\r\n");
		}

		public ResultSummary Execute(ExecuteInfo execInfo)
		{
			_currentExecuteInfo = execInfo;
			
			Exception exception = null;

			StringBuilder sb = new StringBuilder();
			AppendLog(sb, "启动时间：", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

			AppendLog(sb, "启动参数：", ("脚本文件：" + execInfo.FilePath));
			
			try {
				ExecuteCsCode();

				InternalExecute();
			}
			catch( Exception ex ) {
				exception = ex;
			}

			ResultSummary summary = new ResultSummary{
				ErrorCount = _errorCount
			};

			summary.Message = (_errorCount == 0)
				? string.Format("{0} 个任务都已成功执行。", execInfo.List.Count)
				: string.Format("{0} 个任务执行结束，有 {1} 个执行失败。", execInfo.List.Count, _errorCount);

			if( exception == null )
				AppendLog(sb, "执行结果：", summary.Message);
			else
				AppendLog(sb, "执行失败：", exception.ToString());


			AppendLog(sb, "脚本内容：", execInfo.FileContext);

			//SafeWriteLogFile(sb.ToString());

			if( exception != null )
				throw exception;

			return summary;
		}

		
		private void InternalExecute()
		{
			bool supportWindowsAuth = _currentExecuteInfo.GetParameter("supportWindowsAuth") == "1";
			string userAgent = _currentExecuteInfo.GetParameter("User-Agent");
			
			int index = -1;
			foreach( RequestInfo request in _currentExecuteInfo.List ) {
				// 检查脚本中的参数占位符，如果有，就给它们赋值。
				SetParameters(request);

				// 创建请求参数
				HttpOption option = CreateHttpOption(request, supportWindowsAuth, userAgent);
				//option.SetRequestAction = x => x.Proxy = new WebProxy("127.0.0.1", 8888);


				SetCookie(option);

				index++;

				// 发送请求
				ExecuteReqest(request, option, index);
			}
		}


		private HttpOption CreateHttpOption(RequestInfo request, bool supportWindowsAuth, string userAgent)
		{
			HttpOption option = HttpOption.FromRawText(request.Text);
			option.Headers.Remove("X-Mysoft-Profiler");     // 移队Fiddler插件中增加的监控头，避免返回无用信息
			option.Headers.Remove("Host");                  // 这个头没什么用，反而可能与网址参数不一样

			if( string.IsNullOrEmpty(userAgent) == false ) {
				option.Headers.Remove("User-Agent");
				option.Headers.Add("User-Agent", userAgent);
			}

			if( supportWindowsAuth )        // 支持Windows身份认证
				option.Credentials = CredentialCache.DefaultCredentials;

			// 重新计算请求地址
			if( string.IsNullOrEmpty(_currentExecuteInfo.TargetSite) == false ) {
				option.Url
					= request.RealUrl
					= _currentExecuteInfo.TargetSite + request.RelativeUrl;


				string referer = option.Headers["Referer"];
				if( string.IsNullOrEmpty(referer) == false ) {
					referer = referer.Replace(request.SiteRoot, _currentExecuteInfo.TargetSite);
					option.Headers.Remove("Referer");
					option.Headers.Add("Referer", referer);
				}
			}
			else
				request.RealUrl = request.SiteRoot + request.RelativeUrl;


			return option;
		}

		
		private void SetCookie(HttpOption option)
		{
			// 如果接收到COOKIE，就记录下来
			option.ReadResponseAction = SaveNewCookie;

			if( _setCookies.Count == 0 )
				return;

			StringBuilder cookieBuilder = new StringBuilder();

			// 取出脚本上指定的COOKIE
			string currentCookie = option.Headers["Cookie"];
			if( string.IsNullOrEmpty(currentCookie) == false ) {
				// 移除原请求头
				option.Headers.Remove("Cookie");


				// 拆分当前请求的COOKIE头字符串
				List<NameValue> c2 = StringExtensions.SplitString(currentCookie, ';', '=');

				// 始终以服务端创建的COOKIE为准
				foreach( var c in c2 ) {
					var x = _setCookies.FirstOrDefault(a => a.Name.EqualsIgnoreCase(c.Name));
					if( x == null )
						cookieBuilder.Append(c.Name).Append("=").Append(c.Value).Append("; ");
				}
			}

			foreach(var c in _setCookies)
				cookieBuilder.Append(c.Name).Append("=").Append(c.Value).Append("; ");

			if( cookieBuilder.Length > 0 )
				cookieBuilder.Remove(cookieBuilder.Length - 2, 2);

			// 重新设置请求头
			option.Headers.Add("Cookie", cookieBuilder.ToString());
		}

		private void SaveNewCookie(HttpWebResponse webResponse)
		{
			//string[] cc = webResponse.Headers.GetValues("Set-Cookie");		// 这行代码有BUG
			string[] cc = GetHeaderValues(webResponse.Headers, "Set-Cookie");
			if( cc != null && cc.Length > 0 ) {
				foreach( string cookie in cc ) {
					NameValue nv = ReadCookie(cookie);
					if( nv != null ) {

						if( nv.Value == null )	// 删除COOKIE
							_setCookies = (from x in _setCookies
										   where x.Name.EqualsIgnoreCase(nv.Name) == false
										   select x
										   ).ToList();
						else {
							// 保存服务端创建的COOKIE，这里不分析 domain，expires，path，path，HttpOnly 这些参数
							NameValue c = _setCookies.FirstOrDefault(x => x.Name.EqualsIgnoreCase(nv.Name));
							if( c == null )
								_setCookies.Add(nv);
							else
								c.Value = nv.Value;
						}
					}
				}
			}
		}

		private string[] GetHeaderValues(WebHeaderCollection headers, string name)
		{
			// .NET 的 webResponse.Headers.GetValues("Set-Cookie") 这个方法有BUG

			// 例如，服务端写一个COOKIE，响应头应该是：
			// Set-Cookie: keeplastname=; expires=Tue, 12-Jul-2016 01:54:42 GMT; path=/

			// 调用 webResponse.Headers.GetValues("Set-Cookie") 会返回二行的结果：
			// keeplastname=; expires=Tue
			// 12-Jul-2016 01:54:42 GMT; path=/

			// 然而，内部的集合存储的原始值是正确的，
			// 所以，只能重新实现这个方法。

			var innerList = headers.GetType().InvokeMember("InnerCollection",
						BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetProperty,
						null, headers, null) as NameObjectCollectionBase;

			var table = typeof(NameObjectCollectionBase).InvokeMember("_entriesTable",
						BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField,
						null, innerList, null) as Hashtable;

			if( table == null )
				return null;

			var entry = table[name];
			if( entry == null )
				return null;

			var value = entry.GetType().InvokeMember("Value",
						BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.GetField,
						null, entry, null) as ArrayList;

			if( value == null )
				return null;

			string[] array = new string[value.Count];
			value.CopyTo(array);
			return array;
		}

		private NameValue ReadCookie(string cookieLine)
		{
			int a = cookieLine.IndexOf('=');
			if( a > 0 ) {
				string name = cookieLine.Substring(0, a);

				cookieLine = cookieLine.Substring(a + 1);
				int b = cookieLine.IndexOf(';');
				if( b == 0)
					return new NameValue { Name = name, Value = null };

				else if( b > 0 ) {
					string value = cookieLine.Substring(0, b);
					return new NameValue { Name = name, Value = value };
				}
				else
					return new NameValue { Name = name, Value = cookieLine };
			}

			return null;
		}

		private void ExecuteReqest(RequestInfo request, HttpOption option, int index)
		{
			request.Result = new ExecuteResult();

			ScriptExecuteEventArgs e1 = new ScriptExecuteEventArgs {
				Index = index,
				Option = option,
				Request = request
			};
			if( this.BeforeExecute != null )
				this.BeforeExecute(this, e1);

			Stopwatch watch = Stopwatch.StartNew();
			try {
				string result = option.Send<string>();
				watch.Stop();

				request.Result.Response = result;
				request.Result.Time = watch.Elapsed;

				if( this.AfterExecute != null )
					this.AfterExecute(this, e1);

			}
			catch( Exception ex ) {
				watch.Stop();
				_errorCount++;

				ScriptExecuteErrorEventArgs e2 = new ScriptExecuteErrorEventArgs {
					Index = index,
					Option = option,
					Request = request,
					Exception = ex
				};
				ProcessException(ex, request, e2);
			}
			finally {
				request.Result.RequestText = option.ToRawText();
			}
		}

		/// <summary>
		/// 检查脚本中的参数占位符，如果有，就给它们赋值
		/// </summary>
		/// <param name="request"></param>
		private void SetParameters(RequestInfo request)
		{
			MatchCollection parametersMatch = s_parameterRegex.Matches(request.Text);
			if( parametersMatch.Count > 0 ) {

				StringBuilder requestText = new StringBuilder(request.Text);
				foreach( Match m in parametersMatch ) {
					if( m.Success ) {
						string varName = m.Groups["name"].Value;

						string value = _currentExecuteInfo.GetParameter(varName);
						if( value == null )
							throw new InvalidProgramException("脚本中没有为变量赋值，变量名：" + varName);

						requestText.Replace(string.Format("{{@{0}}}", varName), value);
					}
				}

				request.Text = requestText.ToString();
			}
		}

		private void ExecuteCsCode()
		{
			if( string.IsNullOrEmpty(_currentExecuteInfo.CsCode) )
				return;

			object result = CompilerProxy.ExecuteCsCode(_currentExecuteInfo.CsCode, _currentExecuteInfo.Parameters);
			_currentExecuteInfo.Parameters = (Dictionary<string, string>)result;
		}




		private void ProcessException(Exception ex, RequestInfo request, ScriptExecuteErrorEventArgs e2)
		{
			request.Result.Exception = ex;

			WebException wex = ex as WebException;
			if( wex != null ) {
				RemoteWebException remoteWebException = new RemoteWebException(wex);
				request.Result.Response = remoteWebException.ResponseText;
			}

			if( this.ExecuteError != null )
				this.ExecuteError(this, e2);
		}


		public static void SafeWriteLogFile(string text)
		{
			string logFilePtah = Path.Combine(
									AppDomain.CurrentDomain.BaseDirectory,
									"Log\\PreheatLog_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".txt");


			try {
				File.WriteAllText(logFilePtah, text, Encoding.UTF8);
			}
			catch { /* 写日志失败，只能吃掉异常了。  */ }
		}





	}
}
