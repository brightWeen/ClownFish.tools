using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.FiddlerPulgin
{
	public class NotReasonableItem
	{
		/// <summary>
		/// 不规范的原因
		/// </summary>
		public string Reason { get; set; }

		/// <summary>
		/// 不规范请求的URL
		/// </summary>
		public string Url { get; set; }

		/// <summary>
		/// 不规范请求的 Header + Body ，以BASE64方式存储
		/// </summary>
		public string Request { get; set; }

		/// <summary>
		/// 转成BASE64格式并给Request赋值
		/// </summary>
		/// <param name="text"></param>
		public void SetRequestText(string text)
		{
			byte[] b = Encoding.UTF8.GetBytes(text);
			this.Request = Convert.ToBase64String(b);
		}

		/// <summary>
		/// 从Request解码
		/// </summary>
		public string GetRequestText()
		{
			if( string.IsNullOrEmpty(this.Request) )
				return string.Empty;

			try {
				byte[] b = Convert.FromBase64String(this.Request);
				return Encoding.UTF8.GetString(b);
			}
			catch {
				return string.Empty;
			}
		}
	}
}
