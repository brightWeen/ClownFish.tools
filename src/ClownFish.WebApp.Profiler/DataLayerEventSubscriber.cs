using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ClownFish.Base;
using ClownFish.Base.TypeExtend;
using ClownFish.Data;
using ClownFish.FiddlerPulgin;

namespace ClownFish.WebApp.Profiler
{
	/// <summary>
	/// 订阅 ClownFish.Data.EventManager 的相关事件
	/// </summary>
	public sealed class DataLayerEventSubscriber : EventSubscriber<EventManager>
	{
		private DateTime? _startTime;
		public override void SubscribeEvent(EventManager instance)
		{
			List<DbActionInfo> list = GetDbActionInfoList();
			if( list == null )
				return;

			instance.ConnectionOpened += Instance_ConnectionOpened;
			instance.BeforeExecute += Instance_BeforeExecute;
			instance.AfterExecute += Instance_AfterExecute;
			instance.OnException += Instance_OnException;
		}

		/// <summary>
		/// 尝试从当前请求中获取DbActionInfo列表，返回值有2上用途：
		/// 1、判断当前请求是不是需要开启数据访问监控，如果返回值为NULL就是不启用。
		/// 2、返回值用于存储请求过程中发生的所有数据访问操作
		/// </summary>
		/// <returns></returns>
		private List<DbActionInfo> GetDbActionInfoList()
		{
			HttpContext context = HttpContext.Current;
			if( context == null )
				return null;

			// 集合在FiddlerProfilerModule.App_PostResolveRequestCache方法中创建
			return context.Items[FiddlerProfilerModule.ContextItemKey] as List<DbActionInfo>;
		}

		private void Instance_ConnectionOpened(object sender, ConnectionEventArgs e)
		{
			List<DbActionInfo> list = GetDbActionInfoList();
			if( list == null )
				return;

			DbActionInfo info = new DbActionInfo();
			// 一个特殊的字符串，标记是一个打开连接的操作，后面会在FiddlerPulgin中判断它
			info.SqlText = DbActionInfo.OpenConnectionFlag;	
			list.Add(info);
		}

		private void Instance_BeforeExecute(object sender, CommandEventArgs e)
		{
			List<DbActionInfo> list = GetDbActionInfoList();
			if( list == null )
				return;

			// 在开始执行数据库操作时，只记下当时的时间，
			// 供ConvertToDbActionInfo方法中计算当前操作花了多长时间。
			_startTime = DateTime.Now;
		}

		private void Instance_AfterExecute(object sender, CommandEventArgs e)
		{
			List<DbActionInfo> list = GetDbActionInfoList();
			if( list == null )
				return;

			DbActionInfo info = ConvertToDbActionInfo(e.DbCommand);
			if( info != null )
				list.Add(info);
		}
		private void Instance_OnException(object sender, ExceptionEventArgs e)
		{
			List<DbActionInfo> list = GetDbActionInfoList();
			if( list == null )
				return;


			DbActionInfo info = ConvertToDbActionInfo(e.DbCommand);
			if( info != null ) {
				info.ErrorMsg = e.Exception.GetBaseException().Message;
				list.Add(info);
			}
		}

		private DbActionInfo ConvertToDbActionInfo(DbCommand command)
		{
			if( _startTime.HasValue == false )
				return null;

			// 注意：这里会对SQL语句做截断处理，因为有些场景下某些开发人员能拼接出好几M的SQL，
			// 影响网络传输和界面展示。

			DbActionInfo info = new DbActionInfo();
			info.Time = DateTime.Now - _startTime.Value;	// 计算执行时间
			info.SqlText = command.CommandText.KeepLength(1024 * 1024 * 2);
			info.InTranscation = command.Transaction != null;	// 判断是否在事务中
			info.Parameters = new List<CommandParameter>();

			// 提取命令参数
			for( int i = 0; i < command.Parameters.Count; i++ ) {
				if( i < 64 ) {	// 只提取64个参数
					DbParameter parameter = command.Parameters[i];

					CommandParameter p = new CommandParameter();
					p.Name = parameter.ParameterName;
					p.DbType = parameter.DbType.ToString();
					if( parameter.Value != null )
						p.Value = parameter.Value.ToString().KeepLength(128); // 也做截断处理
					else
						p.Value = "NULL";

					info.Parameters.Add(p);
				}
				else {
					// 防止在拼接IN条件，出现上千个参数！
					CommandParameter p = new CommandParameter();
					p.Name = "#####";
					p.DbType = "#####";
					p.Value = "参数太多，已被截断...，参数数量：" + command.Parameters.Count.ToString();
					info.Parameters.Add(p);
					break;
				}
			}

			return info;
		}




	}
}
