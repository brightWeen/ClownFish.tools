using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClownFish.Data.Xml;

namespace ClownFish.Data.Tools.EntityGenerator
{
	/// <summary>
	/// 用于缓存存储过程参数的工具类
	/// </summary>
	internal static class ParameterCache
	{
		private static Hashtable s_paramCache = new Hashtable(1024 * 3);

		/// <summary>
		/// 用指定的连接信息，获取一个存储过程的参数数组。
		/// </summary>
		/// <param name="dbConn">DbConnection对象</param>
		/// <param name="spName">存储过程名称</param>
		/// <returns></returns>
		public static DbParameter[] DiscoverSpParameters(DbConnection dbConn, string spName)
		{
			if( dbConn == null )
				throw new ArgumentNullException("dbConn");
			if( string.IsNullOrEmpty(spName) )
				throw new ArgumentNullException("spName");


			DbCommand command = null;
			using( DbConnection conn = (DbConnection)((ICloneable)dbConn).Clone() ) {
				command = conn.CreateCommand();
				command.CommandText = spName;
				command.CommandType = System.Data.CommandType.StoredProcedure;

				conn.Open();

				if( command is System.Data.SqlClient.SqlCommand )
					System.Data.SqlClient.SqlCommandBuilder.DeriveParameters((System.Data.SqlClient.SqlCommand)command);

				else if( command is System.Data.OleDb.OleDbCommand )
					System.Data.OleDb.OleDbCommandBuilder.DeriveParameters((System.Data.OleDb.OleDbCommand)command);
				else if( command is System.Data.Odbc.OdbcCommand )
					System.Data.Odbc.OdbcCommandBuilder.DeriveParameters((System.Data.Odbc.OdbcCommand)command);
				
				else
					throw new NotSupportedException();


				conn.Close();
			}

			// 对于SqlServer，返回值作为第一个参数
			if( command.Parameters.Count > 0 && command.Parameters[0].Direction == System.Data.ParameterDirection.ReturnValue )
				command.Parameters.RemoveAt(0);

			DbParameter[] parameters = new DbParameter[command.Parameters.Count];
			command.Parameters.CopyTo(parameters, 0);
			return parameters;
		}


		///// <summary>
		///// 清除所有缓存项。
		///// </summary>
		//public static void ClearCache()
		//{
		//    lock( s_paramCache.SyncRoot ) {
		//        s_paramCache.Clear();
		//    }
		//}



		public static DbParameter[] CloneParameters(DbParameter[] originalParameters)
		{
			int count = originalParameters.Length;
			DbParameter[] clonedParameters = new DbParameter[count];

			for( int i = 0; i < count; i++ )
				clonedParameters[i] = (DbParameter)((ICloneable)originalParameters[i]).Clone();


			return clonedParameters;
		}


		/// <summary>
		/// 根据一个数据库的连接，获取存储过程的参数数组
		/// </summary>
		/// <param name="dbConn">DbConnection对象</param>
		/// <param name="spName">存储过程名称</param>
		/// <returns>存储过程的参数数组</returns>
		public static DbParameter[] GetSpParameters(DbConnection dbConn, string spName)
		{
			if( dbConn == null )
				throw new ArgumentNullException("dbConn");
			if( string.IsNullOrEmpty(spName) )
				throw new ArgumentNullException("spName");


			string key = string.Concat(spName, "###", dbConn.ConnectionString, "###", dbConn.GetType().ToString());
			DbParameter[] parameters = (s_paramCache[key] as DbParameter[]);

			if( parameters == null ) {
				lock( s_paramCache.SyncRoot ) {
					parameters = (s_paramCache[key] as DbParameter[]);
					if( parameters == null ) {
						parameters = DiscoverSpParameters(dbConn, spName);
						s_paramCache[key] = parameters;
					}
				}
			}

			// 返回“克隆”后的对象，这样的返回结果可供后续调用直接使用，而不会影响缓存中的对象。
			return CloneParameters(parameters);
		}



		/// <summary>
		/// 将XmlCommand对象中参数数组转换成与指定DbCommand兼容的命令参数数组。
		/// </summary>
		/// <param name="xmlCommand">XmlCommand对象</param>
		/// <param name="dbCommand">DbCommand对象</param>
		/// <returns>返回与指定DbCommand兼容的命令参数数组</returns>
		public static DbParameter[] GetCommandParameters(this XmlCommandItem xmlCommand, DbCommand dbCommand)
		{
			if( xmlCommand == null )
				throw new ArgumentNullException("xmlCommand");
			if( dbCommand == null )
				throw new ArgumentNullException("dbCommand");

			if( xmlCommand.Parameters.Count == 0 )
				return new DbParameter[0];

			DbParameter[] array = new DbParameter[xmlCommand.Parameters.Count];

			for( int i = 0; i < xmlCommand.Parameters.Count; i++ ) {
				XmlCmdParameter p = xmlCommand.Parameters[i];

				DbParameter para = dbCommand.CreateParameter();
				para.ParameterName = p.Name;
				para.DbType = p.Type;
				para.Direction = p.Direction;
				//if( p.Size != 0 )
				para.Size = p.Size;

				array[i] = para;
			}

			return array;
		}

	}
}
