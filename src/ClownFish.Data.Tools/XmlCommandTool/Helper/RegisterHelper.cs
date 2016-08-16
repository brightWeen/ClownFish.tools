using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;


namespace ClownFish.Data.Tools.XmlCommandTool
{
	public static class RegisterHelper
	{
		private static readonly string RegPath = @"HKEY_CURRENT_USER\Software\Fish-li\XmlCommandTool";


		public static object SafeRead(string key, object defaultValue)
		{
			object result = null;
			try {
				result = Registry.GetValue(RegPath, key, defaultValue);
			}
			catch { }

			return (result ?? defaultValue);
		}


		public static void SafeWrite(string key, object value)
		{
			try{
				Registry.SetValue(RegPath, key, value);
			}
			catch{}
		}


	}
}
