using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.Log.PerformanceAnalyzer.Events
{
	internal class ReSendEventArgs : System.EventArgs
	{
		public string RequestRaw { get; set; }
	}
}
