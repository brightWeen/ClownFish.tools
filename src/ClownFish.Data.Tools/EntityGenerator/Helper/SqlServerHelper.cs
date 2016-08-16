using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Common;
using System.Text.RegularExpressions;
using ClownFish.Data.Xml;

namespace ClownFish.Data.Tools.EntityGenerator
{
	public static class SqlServerHelper
	{
		private static readonly string s_QueryTablesScript = @"
select name from ( SELECT obj.name AS [Name],  
	CAST( case when obj.is_ms_shipped = 1 then 1     
			when ( select major_id from sys.extended_properties          
					where major_id = obj.object_id and  minor_id = 0 and class = 1 and name = N'microsoft_database_tools_support')          
			is not null then 1  else 0 end  AS bit) AS [IsSystemObject] 
	FROM sys.all_objects AS obj where obj.type in (N'U') ) as tables 
	where [IsSystemObject] = 0 ORDER BY [Name] ASC";

		private static readonly string s_QueryViewsScript = @"
select name from ( SELECT obj.name AS [Name],  
	CAST( case when obj.is_ms_shipped = 1 then 1     
			when ( select major_id from sys.extended_properties          
					where major_id = obj.object_id and  minor_id = 0 and class = 1 and name = N'microsoft_database_tools_support')          
			is not null then 1  else 0 end  AS bit) AS [IsSystemObject] 
	FROM sys.all_objects AS obj where obj.type in (N'V') ) as tables 
	where [IsSystemObject] = 0 ORDER BY [Name] ASC";

		private static readonly string s_QueryFieldsScript = @"
SELECT clmns.name AS [Name], baset.name AS [DataType], 
		CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND clmns.max_length <> -1 
			THEN clmns.max_length/2 ELSE clmns.max_length END AS int) AS [Length], clmns.scale,
		CAST(clmns.precision AS int) AS [Precision], clmns.is_identity AS [Identity], 
		clmns.is_nullable AS [Nullable] ,clmns.is_computed as [Computed],cmc.is_persisted as [IsPersisted] ,
		defCst.definition as [DefaultValue], cmc.definition as [Formular],
		idc.seed_value as [SeedValue], idc.increment_value as [IncrementValue]
FROM sys.tables AS tbl 
INNER JOIN sys.all_columns AS clmns ON clmns.object_id=tbl.object_id 
LEFT OUTER JOIN sys.types AS baset ON baset.user_type_id = clmns.system_type_id and baset.user_type_id = baset.system_type_id 
LEFT OUTER JOIN sys.schemas AS sclmns ON sclmns.schema_id = baset.schema_id 
LEFT OUTER JOIN sys.identity_columns AS ic ON ic.object_id = clmns.object_id and ic.column_id = clmns.column_id 
left outer join sys.default_constraints defCst on defCst.parent_object_id = clmns.object_id and defCst.parent_column_id = clmns.column_id 
left outer join sys.computed_columns cmc on cmc.object_id = clmns.object_id and cmc.column_id = clmns.column_id 
left outer join sys.identity_columns idc on idc.object_id = clmns.object_id and idc.column_id = clmns.column_id 
WHERE (tbl.name= @TableName ) ORDER BY clmns.column_id ASC";

		private static readonly string s_QueryPrimaryKeyScript = @"
select col.name as column_nName 
from sys.indexes ind 
left outer join (sys.index_columns ind_col inner join sys.columns col on col.object_id = ind_col.object_id and col.column_id = ind_col.column_id )  on ind_col.object_id = ind.object_id and ind_col.index_id = ind.index_id 
where ind.object_id = object_id( @TableName )  and ind.index_id >= 0 and ind.type = 1 
and ind.is_hypothetical = 0   order by ind.index_id, ind_col.key_ordinal
";
		private static readonly string s_QueryDataBaseListScript = @"
SELECT dtb.name AS [Database_Name] FROM master.sys.databases AS dtb 
WHERE (CAST(case when dtb.name in ('master','model','msdb','tempdb') then 1 else dtb.is_distributor end AS bit)=0 
		and CAST(isnull(dtb.source_database_id, 0) AS bit)=0) 
ORDER BY [Database_Name] ASC";

		private static readonly string s_QueryStoreProcedureListScript = "SELECT name FROM sys.sql_modules JOIN sys.objects ON sys.sql_modules.object_id = sys.objects.object_id AND type = 'P' where name not like 'sp_%' order by name";

		private static readonly string s_GetProcedureDefinitionScript = "select definition from sys.sql_modules JOIN sys.objects ON sys.sql_modules.object_id = sys.objects.object_id where name = @ObjectName";

		private static readonly string s_GetViewDefinitionScript = "SELECT definition FROM sys.sql_modules JOIN sys.objects ON sys.sql_modules.object_id = sys.objects.object_id AND type = N'V' and name = @ObjectName";


		private static DbContext CreateDbContext(string connectionString, string database)
		{
			if( string.IsNullOrEmpty(database) )
				return DbContext.Create(connectionString, "System.Data.SqlClient");


			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
			builder.InitialCatalog = database;

			return DbContext.Create(builder.ToString(), "System.Data.SqlClient");
		}

		public static List<Field> GetFieldsFromTable(string connectionString, string database, string tablename)
		{
			using( DbContext dbContext = CreateDbContext(connectionString, database) ) {
				var parameter = new { TableName = tablename };
				return dbContext.CPQuery.Create(s_QueryFieldsScript, parameter).ToList<Field>();
			}
		}

		public static int GetSqlServerVersion(string connectionString)
		{
			using( DbContext dbContext = CreateDbContext(connectionString, null) ) {
				string query = "select (@@microsoftversion / 0x01000000);";
				return dbContext.CPQuery.Create(query).ExecuteScalar<int>();
			}
		}


		public static List<Field> GetFieldsFromQuery(string connectionString, string database, string query)
		{
			List<Field> list = new List<Field>();

			using( DbContext dbContext = CreateDbContext(connectionString, database) ) {
				CPQuery cpquery = dbContext.CPQuery.Create(query);

				using( SqlDataReader reader = (SqlDataReader)cpquery.ExecuteReader() ) {
					for( int i = 0; i < reader.FieldCount; i++ ) {
						list.Add(new Field {
							Name = reader.GetName(i),
							DataType = reader.GetFieldType(i).ToString(),
							Nullable = false
						});
					}
				}
			}

			foreach( Field f in list )
				if( string.IsNullOrEmpty(f.Name) )
					f.Name = "无名列";

			return list;
		}


		public static List<string> ExecuteQueryToStringList(string script, string connectionString, string database)
		{
			using( DbContext dbContext = CreateDbContext(connectionString, database) ) {
				return dbContext.CPQuery.Create(script).ToScalarList<string>();
			}
		}

		public static List<string> GetDataBaseNames(string connectionString)
		{
			return ExecuteQueryToStringList(s_QueryDataBaseListScript, connectionString, null);
		}


		public static List<string> GetTableNames(string connectionString, string database)
		{
			return ExecuteQueryToStringList(s_QueryTablesScript, connectionString, database);
		}

		public static List<string> GetViewNames(string connectionString, string database)
		{
			return ExecuteQueryToStringList(s_QueryViewsScript, connectionString, database);
		}

		public static List<string> GetSpNames(string connectionString, string database)
		{
			return ExecuteQueryToStringList(s_QueryStoreProcedureListScript, connectionString, database);
		}


		public static string ExecuteQueryToString(string script, string connectionString, string database, string objectName)
		{
			using( DbContext dbContext = CreateDbContext(connectionString, database) ) {
				var parameter = new { ObjectName = objectName };
				return dbContext.CPQuery.Create(script, parameter).ExecuteScalar<string>();
			}
		}

		public static string GetProcedureCode(string connectionString, string database, string name)
		{
			return ExecuteQueryToString(s_GetProcedureDefinitionScript, connectionString, database, name);
		}

		public static string GetViewCode(string connectionString, string database, string name)
		{
			return ExecuteQueryToString(s_GetViewDefinitionScript, connectionString, database, name);
		}


		public static List<XmlCommandItem> ImportCommandFormSP(string connectionString, string database, string spName)
		{
			DbParameter[] parameters = GetSpParameters(connectionString, database, spName);

			string spCode = GetProcedureCode(connectionString, database, spName);

			XmlCommandItem command = new XmlCommandItem();
			command.CommandName = spName;
			command.CommandText = GetSpCode(spCode);
			command.Database = database;

			foreach( DbParameter para in parameters ) {
				XmlCmdParameter myParam = new XmlCmdParameter();
				myParam.Name = para.ParameterName;
				myParam.Type = para.DbType;
				myParam.Direction = para.Direction;
				myParam.Size = para.Size;
				command.Parameters.Add(myParam);
			}

			List<XmlCommandItem> list = new List<XmlCommandItem>(1);
			list.Add(command);
			return list;
		}

		private static string GetSpCode(string text)
		{
			if( string.IsNullOrEmpty(text) )
				return text;

			string pattern = @"\s+as\s+";
			Match m = Regex.Match(text, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase);

			if( m.Success )
				return "\r\n" + text.Substring(m.Index + m.Length).Trim() + "\r\n";

			return text;
		}


		public static string GenerateTableCreateScript(List<Field> list, string name)
		{
			if( list == null || list.Count == 0 || string.IsNullOrEmpty(name) )
				return string.Empty;

			StringBuilder sb = new StringBuilder();
			sb.AppendFormat("create table [{0}] (\r\n", name);

			int count = 0;
			foreach( Field field in list ) {
				count++;
				if( string.IsNullOrEmpty(field.Formular) )
					sb.AppendFormat("\t[{0}] {1}{2}{3}{4}{5}\r\n",
							field.Name, field.GetSqlDataType(),
							(field.Identity ? string.Format(" identity({0},{1})", field.SeedValue, field.IncrementValue): ""),
							(field.Nullable ? "" : " not null"),
							(string.IsNullOrEmpty(field.DefaultValue) ? "" : " default " + field.DefaultValue),
							(count < list.Count ? "," : ""));
				else
					sb.AppendFormat("\t[{0}] as {1}{2}{3}\r\n",
						field.Name, field.Formular,
						(field.IsPersisted ? " Persisted" : ""),
						(count < list.Count ? "," : ""));
			}

			sb.AppendLine(")");
			return sb.ToString();
		}


		public static DbParameter[] GetSpParameters(string connectionString, string database, string spName)
		{
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
			builder.InitialCatalog = database;

			using( SqlConnection connection = new SqlConnection(builder.ToString()) ) {
				return ParameterCache.DiscoverSpParameters(connection, spName);
			}
		}


		public static List<XmlCommandItem> GetCUDCommandByTableName(string connectionString, string database, string tableName)
		{
			List<XmlCommandItem> commands = new List<XmlCommandItem>(3);

			List<Field> fields = GetFieldsFromTable(connectionString, database, tableName);

			List<string> primaryKeys = null;
			using( DbContext dbContext = CreateDbContext(connectionString, database) ) {
				var parameter = new { TableName = tableName };
				primaryKeys = dbContext.CPQuery.Create(s_QueryPrimaryKeyScript, parameter).ToScalarList<string>();
			}

			if( primaryKeys.Count == 0 ) {
				string idFieldName = (from f in fields where f.Identity select f.Name).FirstOrDefault();
				if( idFieldName != null )
					primaryKeys.Add(idFieldName);
			}

			if( primaryKeys.Count == 0 ) {
				string idFieldName = (from f in fields 
									  where string.Compare(f.DataType, "timestamp", StringComparison.OrdinalIgnoreCase) == 0 
									  select f.Name).FirstOrDefault();
				if( idFieldName != null )
					primaryKeys.Add(idFieldName);
			}

			if( primaryKeys.Count == 0 ) {
				string idFieldName = (from f in fields
									  where (f.DefaultValue != null && f.DefaultValue.IndexOf("newsequentialid()", StringComparison.OrdinalIgnoreCase) >= 0)
									  select f.Name).FirstOrDefault();
				if( idFieldName != null )
					primaryKeys.Add(idFieldName);
			}

			//if( primaryKeys.Count == 0 ) {		// 不能启用这段代码！
			//    string idFieldName = (from f in fields
			//                          where (f.DefaultValue != null && f.DefaultValue.IndexOf("newid()", StringComparison.OrdinalIgnoreCase) >= 0)
			//                          select f.Name).FirstOrDefault();
			//    if( idFieldName != null )
			//        primaryKeys.Add(idFieldName);
			//}


			XmlCommandItem insertCommand = new XmlCommandItem();
			insertCommand.CommandName = "Insert" + tableName.TrimPunctuation();
			insertCommand.CommandType = System.Data.CommandType.Text;

			StringBuilder sbInsert1 = new StringBuilder();
			StringBuilder sbInsert2 = new StringBuilder();
			sbInsert1.AppendFormat("\r\ninsert into [{0}] (", tableName);
			sbInsert2.Append("values (");

			foreach( Field f in fields ) {
				if( f.Identity || f.Computed ||
					string.Compare(f.DataType, "timestamp", StringComparison.OrdinalIgnoreCase) == 0 ||
					(f.DefaultValue != null && f.DefaultValue.IndexOf("newsequentialid()", StringComparison.OrdinalIgnoreCase) >= 0) )
					continue;

				sbInsert1.AppendFormat("[{0}],", f.Name);
				sbInsert2.AppendFormat("@{0},", f.Name);
				insertCommand.Parameters.Add(ConvertToXmlCmdParameter(f));
			}
			sbInsert1.Remove(sbInsert1.Length - 1, 1).AppendLine(")");
			sbInsert2.Remove(sbInsert2.Length - 1, 1).AppendLine(");");			
			insertCommand.CommandText = sbInsert1.ToString() + sbInsert2.ToString();

			commands.Add(insertCommand);




			if( primaryKeys.Count > 0 ) {
				XmlCommandItem updateCommand = new XmlCommandItem();
				updateCommand.CommandName = "Update" + tableName.TrimPunctuation();
				updateCommand.CommandType = System.Data.CommandType.Text;

				StringBuilder sbUpdate = new StringBuilder();
				sbUpdate.AppendFormat("\r\nupdate [{0}] set \r\n", tableName);

				foreach( Field f in fields ) {
					if( f.Identity || f.Computed ||
						string.Compare(f.DataType, "timestamp", StringComparison.OrdinalIgnoreCase) == 0 ||
						(f.DefaultValue != null && f.DefaultValue.IndexOf("newsequentialid()", StringComparison.OrdinalIgnoreCase) >= 0) )
						continue;

					if( DataExtensions.FindIndex(primaryKeys, f.Name) >= 0 )
						continue;

					sbUpdate.AppendFormat("[{0}] = @{0}, ", f.Name);
					updateCommand.Parameters.Add(ConvertToXmlCmdParameter(f));
				}
				sbUpdate.Remove(sbUpdate.Length - 2, 2).Append("\r\nWhere ");

				foreach( Field f in fields ) {
					if( DataExtensions.FindIndex(primaryKeys, f.Name) < 0 )
						continue;

					sbUpdate.AppendFormat(" [{0}] = @{0} and", f.Name);
					updateCommand.Parameters.Add(ConvertToXmlCmdParameter(f));
				}
				sbUpdate.Remove(sbUpdate.Length - 4, 4).AppendLine();
				updateCommand.CommandText = sbUpdate.ToString();

				commands.Add(updateCommand);




				XmlCommandItem deleteCommand = new XmlCommandItem();
				deleteCommand.CommandName = "Delete" + tableName.TrimPunctuation();
				deleteCommand.CommandType = System.Data.CommandType.Text;

				StringBuilder sbDelete = new StringBuilder();
				sbDelete.AppendFormat("\r\ndelete from [{0}] where \r\n", tableName);

				foreach( Field f in fields ) {
					if( DataExtensions.FindIndex(primaryKeys, f.Name) < 0 )
						continue;

					sbDelete.AppendFormat(" [{0}] = @{0} and", f.Name);
					deleteCommand.Parameters.Add(ConvertToXmlCmdParameter(f));
				}
				sbDelete.Remove(sbDelete.Length - 4, 4).AppendLine();
				deleteCommand.CommandText = sbDelete.ToString();

				commands.Add(deleteCommand);
			}

			return commands;
		}


		private static XmlCmdParameter ConvertToXmlCmdParameter(Field f)
		{
			XmlCmdParameter para = new XmlCmdParameter {
				Name = "@" + f.Name,
				Type = f.GetDbType()
			};
			if( para.Type == System.Data.DbType.String && f.Length > 0 )
				para.Size = f.Length;

			return para;
		}



	}
}
