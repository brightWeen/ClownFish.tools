using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.PreheatWebSite
{
	public class SiteInfo
	{
		public string UrlRoot { get; set; }

		public LoginInfo LoginInfo { get; set; }

		public List<string> Urls { get; set; }
	}


	public class LoginInfo
	{
		public string HttpMethod { get; set; }

		public string LoginUrl { get; set; }

		public string PostText { get; set; }
	}
}
