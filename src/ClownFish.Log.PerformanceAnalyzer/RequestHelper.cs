using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClownFish.Base;
using ClownFish.Base.WebClient;

namespace ClownFish.Log.PerformanceAnalyzer
{
	/// <summary>
	/// 请求重发的执行结果
	/// </summary>
	internal class ResendResult
	{
		/// <summary>
		/// 执行时间
		/// </summary>
		public TimeSpan ExecuteTime { get; set; }

		/// <summary>
		/// 可用于显示的消息
		/// </summary>
		public string Message { get; set; }
	}

	internal class RequestHelper
	{
		private string _loginRequestRaw;
		private string _loginCookieName;

		/// <summary>
		/// 匹配URL的正则表示式
		/// </summary>
		private Regex _regex = new Regex(@"^(?<host>http(s)?://[^/]+)(?<path>/.*)?", RegexOptions.IgnoreCase | RegexOptions.Compiled);


		public RequestHelper(string loginRequestRaw, string loginCookieName)
		{
			if( string.IsNullOrEmpty(loginRequestRaw) )
				throw new ArgumentNullException("loginRequestRaw");
			if( string.IsNullOrEmpty(loginCookieName) )
				throw new ArgumentNullException("loginCookieName");

			_loginRequestRaw = loginRequestRaw;
			_loginCookieName = loginCookieName;
		}

		public List<ResendResult> BatchSendRequest(string currentRequestRaw, int count)
		{
			HttpOption option = GetSendOption(currentRequestRaw);
			option.Timeout = 3000;

			bool stop = false;
			List<ResendResult> list = new List<ResendResult>();

			for( int i = 0; i < count; i++ ) {
				Stopwatch watch = Stopwatch.StartNew();
				string message = null;

				try {
					option.Send();
				}
				catch( Exception ex ) {
					message = ex.Message;

					// 如果有异常，就不需要再发请求了
					stop = true;
				}

				watch.Stop();
				ResendResult result = new ResendResult { ExecuteTime = watch.Elapsed, Message = message ?? "OK" };
				list.Add(result);

				if( stop )
					break;
			}

			return list;
		}


		/// <summary>
		/// 获取一个可用于多次发送的请求参数对象
		/// </summary>
		/// <param name="currentRequestRaw"></param>
		/// <returns></returns>
		private HttpOption GetSendOption(string currentRequestRaw)
		{
			HttpOption option = HttpOption.FromRawText(currentRequestRaw);

			Cookie cookie = Login(option.Url);

			ReplaceLoginCookie(option, cookie);

			return option;
		}

		/// <summary>
		/// 替换请求中的登录凭证
		/// </summary>
		/// <param name="option"></param>
		/// <param name="loginCookie"></param>
		private void ReplaceLoginCookie(HttpOption option, Cookie loginCookie)
		{
			StringBuilder cookieBuilder = new StringBuilder();

			// 填充登录凭证
			cookieBuilder.Append(_loginCookieName).Append("=").Append(loginCookie.Value).Append("; ");

			string currentCookie = option.Headers["Cookie"];
			if( string.IsNullOrEmpty(currentCookie) == false ) {

				// 拆分当前请求的Cookie头字符串
				List<NameValue> c2 = StringExtensions.SplitString(currentCookie, ';', '=');

				foreach( var c in c2 ) {
					// 排除原登录凭证
					if( c.Name.Equals(_loginCookieName, StringComparison.OrdinalIgnoreCase) == false )
						cookieBuilder.Append(c.Name).Append("=").Append(c.Value).Append("; ");
				}

				// 移除原请求头
				option.Headers.Remove("Cookie");
			}

			cookieBuilder.Remove(cookieBuilder.Length - 2, 2);

			// 重新设置请求头
			option.Headers.Add("Cookie", cookieBuilder.ToString());
		}

		/// <summary>
		/// 用新的URL登录
		/// </summary>
		/// <param name="currentUrl"></param>
		/// <returns></returns>
		private Cookie Login(string currentUrl)
		{
			HttpOption option = HttpOption.FromRawText(_loginRequestRaw);

			Match m = _regex.Match(option.Url);
			if( m.Success == false )
				throw new ArgumentException("登录请求中的URL格式不正确。");

			Match m2 = _regex.Match(currentUrl);
			if( m2.Success == false )
				throw new ArgumentException("当前待发送请求中的URL格式不正确。");

			option.Url = m2.Groups["host"].Value + m.Groups["path"].Value;
			option.Cookie = new CookieContainer();

			option.Send();

			var cookies = option.Cookie.GetCookies(new Uri(m2.Groups["host"].Value));
			Cookie cookie =  cookies[_loginCookieName];

			if( cookie == null )
				throw new InvalidOperationException("服务端没有返回指定名称的登录Cookie");

			return cookie;
		}

	}
}
