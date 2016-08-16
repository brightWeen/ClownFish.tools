using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClownFish.Data.Tools.EntityGenerator
{
	public static class DataTypeHelper
	{
		/// <summary>
		/// 从一个SQLSERVER的对象名称中删除一些标点符号，用来生成一个C#类的名称
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static string TrimPunctuation(this string name)
		{
			return name.Replace(" ", "").Replace("[", "").Replace("]", "").Replace("'", "").Replace("\"", "").Replace("_", "");
		}


		public static string SqlTypeToCsType(string dataType)
		{
			if( dataType.StartsWith("System.") ) {
				switch( dataType ) {
					case "System.Int32":
						return "int";
					case "System.Int64":
						return "long";
					case "System.String":
						return "string";
					case "System.Decimal":
						return "decimal";
					case "System.Boolean":
						return "bool";
					case "System.Int16":
						return "short";
					case "System.Single":
						return "float";
					case "System.Double":
						return "double";
					default:
						return dataType.Substring(7);
				}
			}

			// SQL Server 数据类型映射 (ADO.NET) 
			// ms-help://MS.MSDNQTR.v90.chs/wd_adonet/html/fafdc31a-f435-4cd3-883f-1dfadd971277.htm
			switch( dataType ) {
				case "bigint":
					return "long";

				case "binary":
				case "varbinary":
				case "image":
				case "timestamp":
					return "byte[]";

				case "bit":
					return "bool";

				case "char":
				case "varchar":
				case "nchar":
				case "nvarchar":
				case "text":
				case "ntext":
				case "xml":
					return "string";

				// SQL Server 2008 中的日期和时间数据 (ADO.NET) 
				// ms-help://MS.MSDNQTR.v90.chs/wd_adonet/html/6f5ff56a-a57e-49d7-8ae9-bbed697e42e3.htm
				case "date":
				case "datetime":
				case "datetime2":
				case "smalldatetime":				
					return "DateTime";
				case "datetimeoffset":
					return "DateTimeOffset";
				case "time":
					return "TimeSpan";

				case "int":
					return "int";
				case "smallint":
					return "short";
				case "tinyint":
					return "byte";

				case "real":
					return "float";
				case "float":
					return "double";

				case "numeric":
				case "decimal":
				case "money":
				case "smallmoney":
					return "decimal";

				case "uniqueidentifier":
					return "Guid";

				default:
					return "object";
			}
		}


		public static bool IsCsNullableType(string dataType)
		{
			switch( dataType ) {
				case "bigint":
				case "bit":
				case "date":
				case "time":
				case "datetime":
				case "datetime2":
				case "smalldatetime":
				case "datetimeoffset":
				case "int":
				case "smallint":
				case "tinyint":
				case "float":
				case "real":
				case "numeric":
				case "decimal":
				case "money":
				case "smallmoney":
				case "uniqueidentifier":
				
					return true;

				default:
					return false;
			}
		}


		public static string GetSqlDataType(this Field field)
		{
			switch( field.DataType ) {
				case "bigint":
					return "bigint";
				case "binary":
					return string.Format("binary({0})", field.Length == -1 ? "max" : field.Length.ToString());
				case "varbinary":
					return string.Format("varbinary({0})", field.Length == -1 ? "max" : field.Length.ToString());
				case "image":
					return "image";
				case "bit":
					return "bit";

				case "char":
					return string.Format("char({0})", field.Length == -1 ? "max" : field.Length.ToString());
				case "varchar":
					return string.Format("varchar({0})", field.Length == -1 ? "max" : field.Length.ToString());
				case "nchar":
					return string.Format("nchar({0})", field.Length == -1 ? "max" : field.Length.ToString());
				case "nvarchar":
					return string.Format("nvarchar({0})", field.Length == -1 ? "max" : field.Length.ToString());
				case "text":
					return "text";
				case "ntext":
					return "ntext";
				case "xml":
					return "xml";

				case "date":
					return "date";
				case "time":
					return "time";
				case "datetime":
					return "datetime";
				case "datetime2":
					return "datetime2";
				case "smalldatetime":
					return "smalldatetime";
				case "timestamp":
					return "timestamp";
				case "datetimeoffset":
					return "datetimeoffset";

				case "int":
					return "int";
				case "smallint":
					return "smallint";
				case "tinyint":
					return "tinyint";
				case "float":
					return "float";
				case "real":
					return "real";

				case "numeric":
					return string.Format("numeric({0}, {1})", field.Precision, field.scale);
				case "decimal":
					return string.Format("decimal({0}, {1})", field.Precision, field.scale);
				case "money":
					return "money";
				case "smallmoney":
					return "smallmoney";

				case "uniqueidentifier":
					return "uniqueidentifier";

				default:
					return "object";
			}
		}

		public static DbType GetDbType(this Field field)
		{
			switch( field.DataType ) {
				case "bigint":
					return DbType.Int64;

				case "binary":					
				case "varbinary":
				case "image":
				case "timestamp":
					return DbType.Binary;

				case "bit":
					return DbType.Boolean;

				case "char":
				case "varchar":
				case "text":
					return DbType.AnsiString;

				case "nchar":
				case "nvarchar":				
				case "ntext":
					return DbType.String;

				case "xml":
					return DbType.Xml;

				case "date":
					return DbType.Date;
				
				case "datetime2":
					return DbType.DateTime2;

				case "time":
					return DbType.Time;

				case "datetime":
				case "smalldatetime":
					return DbType.DateTime;

				case "int":
					return DbType.Int32;

				case "smallint":
					return DbType.Int16;

				case "tinyint":
					return DbType.Byte;

				case "real":
					return DbType.Single;

				case "float":
				case "numeric":
					return DbType.Double;

				case "decimal":
					return DbType.Decimal;

				case "money":					
				case "smallmoney":
					return DbType.Currency;

				case "uniqueidentifier":
					return DbType.Guid;

				default:
					return DbType.Object;
			}
		}


		public static string DbTypeToCsType(DbType type)
		{
			switch( type ) {
				case DbType.AnsiString:
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
				case DbType.Xml:
					return "string";

				case DbType.Binary:
					return "byte[]";

				case DbType.Boolean:
					return "bool";

				case DbType.Byte:
					return "byte";


				case DbType.Date:
				case DbType.DateTime:
				case DbType.DateTime2:				
					return "DateTime";

				case DbType.DateTimeOffset:
					return "DateTimeOffset";
				case DbType.Time:
					return "TimeSpan";

				case DbType.Currency:
				case DbType.Decimal:
					return "decimal";

				case DbType.Double:
				case DbType.VarNumeric:
					return "double";

				case DbType.Guid:
					return "Guid";

				case DbType.Int16:
					return "short";

				case DbType.Int32:
					return "int";

				case DbType.Int64:
					return "long";

				case DbType.Object:
					return "object";

				case DbType.SByte:
					return "sbyte";

				case DbType.Single:
					return "float";
				
				
				case DbType.UInt16:
					return "ushort";

				case DbType.UInt32:
					return "uint";

				case DbType.UInt64:
					return "ulong";

				default:
					return "object";
			}
		}

	}
}
