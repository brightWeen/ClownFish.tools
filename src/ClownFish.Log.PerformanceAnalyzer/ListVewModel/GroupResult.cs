using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClownFish.Log.Model;

namespace ClownFish.Log.PerformanceAnalyzer.ListVewModel
{
	internal class GroupResult
	{
		public string Url { get; set; }
		public int Count { get; set; }
		public TimeSpan AvgTime { get; set; }

		public List<PerformanceInfo> List { get; set; }
	}


	
}
