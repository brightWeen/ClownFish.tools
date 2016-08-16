using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using System.Data;
using ClownFish.Data.Xml;
using ClownFish.Base;

namespace ClownFish.Data.Tools.EntityGenerator
{

	public static class Generator
	{
		public static string NounPluralToOdd(this string name)
		{
			if(name.Length > 3 && name.EndsWith("ies") )
				return name.Substring(0, name.Length - 3) + "y";

			if( name.Length > 1 && name.EndsWith("s") )
				return name.Substring(0, name.Length - 1);

			return name;
		}


		public static string GenerateCode(string tableName, List<Field> list, CsClassStyle style)
		{
			if( string.IsNullOrEmpty(tableName) || list == null || list.Count == 0 )
				return string.Empty;

			//if( style.MemberStyle == CsClassMemberStyle.Field)
			//	return GenerateFieldCode(list, tableName, style.SupportWCF);

			//if( style.MemberStyle == CsClassMemberStyle.AutoProperty )
				return GenerateAutoPropertyCode(list, tableName, style.SupportWCF);

			//return GeneratePropertyCode(list, tableName, style.SupportWCF);
		}



		private static string GenerateAutoPropertyCode(List<Field> list, string tableName, bool enabledWcf)
		{
			StringBuilder sb = new StringBuilder();

			if( enabledWcf )
				sb.AppendLine("[DataContract]");
			sb.Append("public class ").Append(tableName.NounPluralToOdd()).AppendLine(" : Entity")
				.AppendLine("{");

			foreach( Field f in list ) {
				if( enabledWcf )
					sb.AppendLine("\t[DataMember]");
				sb.AppendFormat("\tpublic virtual {0} {1} {{ get; set; }}\r\n",	f.GetCsDataType(), f.Name.TrimPunctuation());
			}

			sb.AppendLine("}");
			return sb.ToString();
		}


		public static string GenerateSpCallCode(DbParameter[] parameters, string spname, int prefixLen, bool namedType)
		{
			if( string.IsNullOrEmpty(spname) )
				throw new ArgumentNullException("spname");

			if( parameters == null || parameters.Length == 0 ) {
				if( spname.StartsWithIgnoreCase("get")
				|| spname.StartsWithIgnoreCase("query")
				|| spname.StartsWithIgnoreCase("search") ) {
					if( spname.EndsWithIgnoreCase("ById") || spname.EndsWithIgnoreCase("ByGuid") )
						return string.Format("TModel item = StoreProcedure.Create(\"{0}\").ToSingle<TModel>();\r\n", spname);
					else
						string.Format("List<TModel> list = StoreProcedure.Create(\"{0}\").ToList<TModel>();\r\n", spname);
				}
				else
					return string.Format("StoreProcedure.Create(\"{0}\").ExecuteNonQuery();", spname);
			}

			bool existOutParameter = false;

			foreach( DbParameter para in parameters ) {
				if( para.Direction == ParameterDirection.Output || para.Direction == ParameterDirection.InputOutput ) 
					existOutParameter = true;
			}

			// 需要生成一个C#类型
			string className = ((namedType || existOutParameter) ? spname.TrimPunctuation() + "Parameters" :  string.Empty);
			StringBuilder sb = new StringBuilder();

			if( string.IsNullOrEmpty(className) == false ) {
				sb.Append("public class ").Append(className).AppendLine(" {");

				foreach( DbParameter para in parameters ) {
					sb.AppendFormat("\tpublic {0} {1} {{ get; set; }}\r\n",
						DataTypeHelper.DbTypeToCsType(para.DbType), para.ParameterName.Substring(prefixLen));
				}

				sb.AppendLine("}\r\n");
			}


			sb.AppendFormat("var parameters = new {0}{{\r\n", className);

			int i = 1;
			foreach( DbParameter para in parameters )
				sb.AppendFormat("\t{0} = xxxxxxx{1}{2}\r\n", 
					para.ParameterName.Substring(prefixLen),
					(i++ < parameters.Length ? "," : ""),
					(para.Direction == ParameterDirection.Output || para.Direction == ParameterDirection.InputOutput ? "\t\t// output" : "")
					);

			//sb.Remove(sb.Length - 3, 3);
			sb.AppendLine("};");
			
			if( spname.StartsWithIgnoreCase("get")
					|| spname.StartsWithIgnoreCase("query")
					|| spname.StartsWithIgnoreCase("search") ) {
				if( spname.EndsWithIgnoreCase("ById") || spname.EndsWithIgnoreCase("ByGuid") )
					sb.AppendFormat("TModel item = StoreProcedure.Create(\"{0}\", parameters).ToSingle<TModel>();\r\n", spname);
				else
					sb.AppendFormat("List<TModel> list = StoreProcedure.Create(\"{0}\", parameters).ToList<TModel>();\r\n", spname);
			}
			else
				sb.AppendFormat("StoreProcedure.Create(\"{0}\", parameters).ExecuteNonQuery();", spname);

			return sb.ToString();
		}

		public static string GenerateXmlCommandCallCode(XmlCommandItem xmlCommand, string spname, int prefixLen, bool namedType)
		{
			DbCommand dbCommand = new System.Data.SqlClient.SqlCommand();
			DbParameter[] parameters = xmlCommand.GetCommandParameters(dbCommand);

			string code = GenerateSpCallCode(parameters, spname, prefixLen, namedType);

			// 二者的调用方式完全一样，只是名称不一样而已。
			return code.Replace("StoreProcedure", "XmlCommand");		
		}


		internal static int GuessParameterNamePrefixLen(XmlCommandItem xmlCommand)
		{
			if( xmlCommand.Parameters.Count == 0 )
				return 0;

			XmlCmdParameter param = xmlCommand.Parameters[0];

			int index = 0;

			for( ; index < param.Name.Length; index++ ) 
				if( Char.IsLetter(param.Name[index]) )
					break;

			if( index < param.Name.Length )
				return index;
			else
				return 0;
		}
	}
}
