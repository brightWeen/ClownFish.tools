using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClownFish.PreheatWebSite
{
	/// <summary>
	/// 预热脚本解析器
	/// </summary>
	internal class ScriptParser
	{
		/// <summary>
		/// C#代码块的分隔行标记，要求成对出现
		/// </summary>
		private static readonly string s_csCodeSeparatorLine = "#################### C# script ####################";

		/// <summary>
		/// 匹配HTTP请求第一行的正则表达式
		/// 例如： GET http://10.5.10.82:9000/PubPlatform/Nav/Login/Login.aspx?ReturnUrl=%2f HTTP/1.1
		/// </summary>
		private static readonly Regex s_httpRegex
				= new Regex(@"^\w+ (?<root>http(s)?://[^/]+)(?<url>/[\w|\W]*) HTTP/1.\d$", RegexOptions.IgnoreCase | RegexOptions.Compiled);


		/// <summary>
		/// 匹配是不是一个网站根地址，
		/// 例如：http://10.5.10.82:9000 , http://www.abc.com/
		/// </summary>
		private static readonly Regex s_urlRootRegex
			= new Regex(@"^http(s)?://[a-z\d\.]+(:\d+)?$", RegexOptions.IgnoreCase | RegexOptions.Compiled);

		/// <summary>
		/// 用于提取变量名和变量值
		/// 例如：@websiteAddress=http://10.5.10.82:8411
		/// </summary>
		private static readonly Regex s_varRegex
			= new Regex(@"^@(?<name>[\w-]+)\s*=\s*(?<value>\S*)$", RegexOptions.IgnoreCase | RegexOptions.Compiled);



		public static bool SiteAddressIsOK(string url)
		{
			return s_urlRootRegex.IsMatch(url);
		}

		/// <summary>
		/// 解析指定的脚本文件
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public ExecuteInfo Parse(string filePath)
		{
			if( string.IsNullOrEmpty(filePath) )
				throw new ArgumentNullException("filePath");

			if( File.Exists(filePath) == false )
				throw new FileNotFoundException("文件 " + filePath + " 不存在，或者没有权限访问。");


			ExecuteInfo execInfo = new ExecuteInfo();
			execInfo.List = new List<RequestInfo>();
			execInfo.FileContext = File.ReadAllText(filePath, Encoding.UTF8);
			execInfo.FilePath = filePath;
			execInfo.Parameters = new Dictionary<string, string>();


			// 检查有没有包含 C# 代码
			int csP1 = execInfo.FileContext.IndexOf(s_csCodeSeparatorLine);
			if( csP1 > 0 ) {
				csP1 += s_csCodeSeparatorLine.Length + 1;
				int csP2 = execInfo.FileContext.IndexOf(s_csCodeSeparatorLine, csP1);
				if( csP2 > csP1 ) {
					// 找到 C# 代码块
					execInfo.CsCode = execInfo.FileContext.Substring(csP1, csP2 - csP1).Trim();
				}
			}



			string block = null;
			Match lastMatch = null;
			StringBuilder sb = new StringBuilder();

			using( StringReader reader = new StringReader(execInfo.FileContext) ) {

				string line = null;
				while( (line = reader.ReadLine()) != null ) {

					if( line.StartsWith("#") )      // 忽略注释行
						continue;

					Match varMatch = s_varRegex.Match(line);
					if( varMatch.Success ) {
						string name = varMatch.Groups["name"].Value;
						string value = varMatch.Groups["value"].Value;
						// 将读取到的变量保存起来。
						execInfo.Parameters[name] = value;

						// 如果是变量行定义，就跳过下面的解析过程。
						continue;
					}


					Match match = s_httpRegex.Match(line);
					if( match.Success ) {       // 找到一个HTTP请求的开头

						if( lastMatch != null ) {   // 用当前行之前的内容构造一个RequestInfo对象

							block = sb.ToString().Trim();
							if( string.IsNullOrEmpty(block) == false ) {
								RequestInfo request = CreateRequestInfo(block, lastMatch);
								execInfo.List.Add(request);
							}
						}
						lastMatch = match;
						sb.Clear();
					}

					sb.AppendLine(line);
				}
			}

			// 处理剩余部分
			if( lastMatch != null ) {
				block = sb.ToString().Trim();
				if( string.IsNullOrEmpty(block) == false ) {
					RequestInfo request = CreateRequestInfo(block, lastMatch);
					execInfo.List.Add(request);
				}
			}

			SetTargetSite(execInfo);
			return execInfo;
		}


		private void SetTargetSite(ExecuteInfo execInfo)
		{
			string websiteAddress = execInfo.GetParameter("websiteAddress");

			if( string.IsNullOrEmpty(websiteAddress) == false ) {
				if( websiteAddress.EndsWith("/"))
					websiteAddress = websiteAddress.Trim('/');

				execInfo.TargetSite = websiteAddress;
			}

			// 如果没有指定网址参数，执行时就不替换URL
		}


		private RequestInfo CreateRequestInfo(string block, Match lastMatch)
		{
			return new RequestInfo {
				SiteRoot = lastMatch.Groups["root"].Value,
				RelativeUrl = lastMatch.Groups["url"].Value,
				Text = block
			};
		}

	}
}
