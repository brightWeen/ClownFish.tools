using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.FiddlerPulgin
{
	public static class SomeExtenstions
	{
		public static string SubstringN(this string text, int keepLength)
		{
			if( string.IsNullOrEmpty(text) )
				return text;

			if( text.Length <= keepLength )
				return text;

			return text.Substring(0, keepLength) + "..." + text.Length.ToString();
		}

	}
}
