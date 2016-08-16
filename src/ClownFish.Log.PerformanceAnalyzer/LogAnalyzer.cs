using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ClownFish.Log.Model;
using ClownFish.Log.PerformanceAnalyzer.ListVewModel;
using ClownFish.Log.Serializer;

namespace ClownFish.Log.PerformanceAnalyzer
{
	internal class LogAnalyzer
	{
		public TimeSpan LastQueryTime { get; set; }

		public List<GroupResult> Search(string connectionString, DateTime start, DateTime end)
		{
			MongoDbWriter mongo = new MongoDbWriter();
			mongo.SetConnectionString(connectionString);

			Stopwatch watch = Stopwatch.StartNew();

			// 从数据库中查询数据
			List<PerformanceInfo> list = mongo.GetList<PerformanceInfo>(x => x.Time >= start && x.Time < end);

			// 记录查询时间
			watch.Stop();
			this.LastQueryTime = watch.Elapsed;


			// 先准备一个字典，用于汇总分析结果
			Dictionary<string, GroupResult> dict = new Dictionary<string, GroupResult>(list.Count);

			foreach(var info in list ) {
				string key = GetGroupKey(info);

				GroupResult g = null;
				if( dict.TryGetValue(key, out g) ) {
					g.Count++;
					g.List.Add(info);
				}
				else {
					g = new GroupResult();
					g.Count = 1;
					g.List = new List<PerformanceInfo>();
					g.List.Add(info);

					if( key.Length > 100 && info.HttpInfo == null ) {
						// 此时KEY是根据SQL来生成的，但是SQL有可能很长，这里就取短一点
						key = key.Substring(0, 100) + "...";
					}

					g.Url = key;
					dict[key] = g;
				}
			}


			// 计算平均时间
			foreach(var kvp in dict ) {
				long sumTime = 0;
				foreach(var info in kvp.Value.List ) 
					sumTime += info.ExecuteTime.Ticks;

				kvp.Value.AvgTime = TimeSpan.FromTicks(sumTime / kvp.Value.List.Count);
			}

			return (from x in dict
					//where x.Value.Count > 5 && x.Value.Url.StartsWith("http://developers.mysoft.com.cn:9090/")
					select x.Value
					).ToList();
		}

		
		private string GetGroupKey(PerformanceInfo info)
		{
			if( info.HttpInfo != null ) {
				string url = info.HttpInfo.Url;
				int p = url.IndexOf('?');
				if( p > 0 )
					return url.Substring(0, p);
				else
					return url;
			}

			return info.SqlInfo.SqlText;
		}
	}
}
