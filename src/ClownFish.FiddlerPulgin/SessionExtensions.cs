using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fiddler;

namespace ClownFish.FiddlerPulgin
{
	internal static class SessionExtensions
	{
		internal static T GetRequestHeader<T>(this Session oSession, string headerName)
		{
			try {
				string text = oSession.oRequest.headers[headerName];

				return (T)Convert.ChangeType(text, typeof(T));
			}
			catch {
				return default(T);
			}
		}


		internal static T GetResponseHeader<T>(this Session oSession, string headerName)
		{
			try {
				string text = oSession.oResponse.headers[headerName];

				return (T)Convert.ChangeType(text, typeof(T));
			}
			catch {
				return default(T);
			}
		}
	}
}
