using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownFish.Base;
using ClownFish.Base.WebClient;

namespace ClownFish.PreheatWebSite
{
	internal static class HttpOptionExtensions
	{
		public static string ToRawText(this HttpOption option)
		{
			if( option == null )
				throw new ArgumentNullException("option");

			StringBuilder sb = new StringBuilder();
			sb.Append(option.Method).Append(" ")
				.Append(option.Url)
				.AppendLine(" HTTP/1.1");

			foreach(var h in option.Headers ) 
				sb.Append(h.Name).Append(": ").AppendLine(h.Value);


			if( string.IsNullOrEmpty(option.ContentType) == false )
				sb.Append("Content-Type").Append(": ")
					.Append(option.ContentType).AppendLine("; charset=utf-8");


			if( option.Data != null ) {
				if( option.Data.GetType() == typeof(string) )
					sb.AppendLine(option.Data.ToString());
				else
					sb.AppendLine(option.Data.ToJson());
			}

			return sb.ToString();
		}
	}
}
