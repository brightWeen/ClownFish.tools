using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.Log.PerformanceAnalyzer.Events
{
	internal class SaveSettingsEventArgs : EventArgs
	{
		public RunTimeSettings NewSettings { get; set; }
	}
}
