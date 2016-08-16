using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.FiddlerPulgin
{
	/// <summary>
	/// 一个简单的HTTP客户端
	/// 说明：ClownFish.Web.Client.HttpClient 实现了更完整的HTTP客户端功能。
	/// </summary>
	public sealed class SimpleHttpClient : IDisposable
	{
		static SimpleHttpClient()
		{
			ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
		}

		/// <summary>
		/// 访问https请求时，验证证书回调操作，默认总是接受
		/// </summary>
		/// <param name="sender">事件发送对象</param>
		/// <param name="certificate">X509格式证书文件</param>
		/// <param name="chain">X509证书链</param>
		/// <param name="errors"></param>
		/// <returns></returns>
		private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
		{
			return true;
		}

		/// <summary>
		/// 默认的UserAgent请求头
		/// </summary>
		public static string DefaultUserAgent = "Fish/C# Tool/SimpleHttpClient/1.0";

		private HttpWebRequest _request;
		private HttpWebResponse _response;

		/// <summary>
		/// HttpWebRequest的实例
		/// </summary>
		public HttpWebRequest Request { get { return _request; } }


		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="url"></param>
		public SimpleHttpClient(string url)
		{
			if( string.IsNullOrEmpty(url) )
				throw new ArgumentNullException("url");

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
			request.UserAgent = DefaultUserAgent;
			request.Method = "GET";

			// 默认数据的提交格式：表单，UTF-8
			request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
			_request = request;
		}


		/// <summary>
		/// 写入要提交的数据到请求体中（同步版本）
		/// </summary>
		/// <param name="postData"></param>
		public void SetRequestData(string postData)
		{
			if( string.IsNullOrEmpty(postData) )
				return;


			using( BinaryWriter bw = new BinaryWriter(_request.GetRequestStream()) ) {
				// 默认就用UTF-8编码发送数据
				bw.Write(Encoding.UTF8.GetBytes(postData));
			}
		}

		/// <summary>
		/// 写入要提交的数据到请求体中（异步版本）
		/// </summary>
		/// <param name="postData"></param>
		public async Task SetRequestDataAsync(string postData)
		{
			if( string.IsNullOrEmpty(postData) )
				return;


			using( BinaryWriter bw = new BinaryWriter(await _request.GetRequestStreamAsync()) ) {
				// 默认就用UTF-8编码发送数据
				bw.Write(Encoding.UTF8.GetBytes(postData));
			}
		}

		/// <summary>
		/// 获取服务端的响应（同步版本），
		/// 注意：这个方法并不读取响应流，仅仅只是获取响应，请在调用该方法后再调用ReadResponse方法
		/// </summary>
		/// <returns></returns>
		public HttpWebResponse GetResponse()
		{
			if( _response != null )
				throw new InvalidOperationException("不允许重复调用GetResponse()方法");

			try {
				_response = (HttpWebResponse)_request.GetResponse();
			}
			catch( WebException wex ) {
				throw CreateHttpException(wex);
			}
			return _response;
		}

		/// <summary>
		/// 获取服务端的响应（异步版本），
		/// 注意：这个方法并不读取响应流，仅仅只是获取响应，请在调用该方法后再调用ReadResponse方法
		/// </summary>
		/// <returns></returns>
		public async Task<HttpWebResponse> GetResponseAsync()
		{
			if( _response != null )
				throw new InvalidOperationException("不允许重复调用GetResponse()方法");

			try {
				_response = (HttpWebResponse)await _request.GetResponseAsync();
			}
			catch( WebException wex ) {
				throw CreateHttpException(wex);
			}
			return _response;
		}


		/// <summary>
		/// 读取响应流内容，并转换成指定的数据类型（仅支持 string, byte[]）
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetResult<T>()
		{
			if( _response == null )
				throw new InvalidOperationException("请先调用GetResponse()方法");

			using( Stream stream = _response.GetResponseStream() ) {

				Stream responseStream = stream;
				try {
					if( _response.Headers["Content-Encoding"] == "gzip" )
						responseStream = new GZipStream(stream, CompressionMode.Decompress);


					if( typeof(T) == typeof(string) )
						return (T)(object)GetText(responseStream);

					else if( typeof(T) == typeof(byte[]) )
						return (T)(object)GetBytes(responseStream);

					else
						throw new NotSupportedException("不支持的参数类型：" + typeof(T).FullName);
				}
				finally {
					if( responseStream != null && responseStream is GZipStream )
						responseStream.Dispose();
				}
			}
		}

		/// <summary>
		/// 获取服务端响应的文本内容
		/// </summary>
		/// <returns></returns>
		private string GetText(Stream stream)
		{
			using( StreamReader reader = new StreamReader(stream, GetResponseEncoding()) ) {
				return reader.ReadToEnd();
			}
		}

		private Encoding GetResponseEncoding()
		{
			string encoding = _response.CharacterSet;

			if( encoding == "ISO-8859-1" )
				// 如果在响应头中没有指定编码方式，.NET默认会返回"ISO-8859-1"，
				// 然而这个编码几乎是没人使用的，反而默认都会使用UTF8

				// 最可靠的方法还是读取响应流的内容，但那种方法会比较复杂，具体可参考ClownFish.Web.Client.ResponseReader
				return Encoding.UTF8;
			else
				return Encoding.GetEncoding(encoding);
		}


		/// <summary>
		/// 获取服务端返回的二进制内容
		/// </summary>
		/// <returns></returns>
		private byte[] GetBytes(Stream stream)
		{
			using( MemoryStream ms = new MemoryStream() ) {

				byte[] buffer = new byte[1024];
				int length = 0;

				while( (length = stream.Read(buffer, 0, 1024)) > 0 )
					ms.Write(buffer, 0, length);

				ms.Position = 0;
				return ms.ToArray();
			}
		}


		private HttpInvokeException CreateHttpException(WebException wex)
		{
			if( wex.Response == null )
				return new HttpInvokeException(wex.Message, wex,
										string.Empty, _request.RequestUri.ToString());


			HttpWebResponse response = (HttpWebResponse)wex.Response;

			using( response ) {
				Stream strem = response.GetResponseStream();
				using( StreamReader reader = new StreamReader(strem, Encoding.GetEncoding(response.CharacterSet)) ) {
					string errorHtml = reader.ReadToEnd();
					string title = GetHtmlTitle(errorHtml) ?? wex.Message;

					return new HttpInvokeException(title, wex, errorHtml, _request.RequestUri.ToString());
				}
			}
		}




		/// <summary>
		/// 尝试从一段HTML代码中读取文档标题部分
		/// </summary>
		/// <param name="text">HTML代码</param>
		/// <returns>文档标题</returns>
		private string GetHtmlTitle(string text)
		{
			if( string.IsNullOrEmpty(text) )
				return null;

			int p1 = text.IndexOf("<title>", StringComparison.OrdinalIgnoreCase);
			int p2 = text.IndexOf("</title>", StringComparison.OrdinalIgnoreCase);

			if( p2 > p1 && p1 > 0 ) {
				p1 += "<title>".Length;
				return text.Substring(p1, p2 - p1);
			}

			return null;
		}

		/// <summary>
		/// 实现IDisposable接口
		/// </summary>
		public void Dispose()
		{
			if( _response != null ) {
				_response.Dispose();
				_response = null;
			}
		}
	}


	/// <summary>
	/// 表示一个网络调用异常
	/// </summary>
	public sealed class HttpInvokeException : System.Exception
	{
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="message"></param>
		/// <param name="innerException"></param>
		/// <param name="responseText"></param>
		/// <param name="url"></param>
		internal HttpInvokeException(string message, Exception innerException, string responseText, string url)
			: base(message, innerException)
		{
			this.ResponseText = responseText;
			this.Url = url;
		}

		/// <summary>
		/// 异常发生时，服务端返回的响应内容
		/// </summary>
		public string ResponseText { get; set; }

		/// <summary>
		/// 异常发生时，请求的URL
		/// </summary>
		public string Url { get; set; }
	}

}
