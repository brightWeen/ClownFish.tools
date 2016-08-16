using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClownFish.PreheatWebSite
{
	public class CompilerProxy : MarshalByRefObject
	{
		public object Execute(string code, object parameters)
		{
			CompilerParameters cp = new CompilerParameters();
			cp.GenerateExecutable = false;
			cp.GenerateInMemory = true;
			cp.ReferencedAssemblies.Add("System.dll");
			cp.ReferencedAssemblies.Add("System.Windows.Forms.dll");
			cp.ReferencedAssemblies.Add("System.Web.dll");
			cp.ReferencedAssemblies.Add("System.Drawing.dll");
			cp.ReferencedAssemblies.Add("System.Data.dll");
			cp.ReferencedAssemblies.Add("System.Xml.dll");
			cp.ReferencedAssemblies.Add("System.Core.dll");

			CompilerResults cr = CodeDomProvider.CreateProvider("CSharp").CompileAssemblyFromSource(cp, code);

			if( cr.Errors != null && cr.Errors.HasErrors ) {
				StringBuilder sb = new StringBuilder();

				foreach( CompilerError error in cr.Errors )
					sb.AppendLine(error.ErrorText);

				throw new Exception("不能执行的 C# 脚本代码。\r\n" + sb.ToString());
			}


			Type type = cr.CompiledAssembly.GetType("PreheatWebSite.Script.ParameterConvert");
			if( type == null )
				throw new InvalidProgramException("类型 PreheatWebSite.Script.ParameterConvert 不存在。");

			object instance = Activator.CreateInstance(type);

			MethodInfo method = instance.GetType().GetMethod("Execute");
			if( method == null )
				throw new InvalidProgramException("没有为类型 PreheatWebSite.Script.ParameterConvert 定义 Execute 方法。");

			return method.Invoke(instance, new object[] { parameters });
		}


		public static object ExecuteCsCode(string code, object parameters)
		{
			if( string.IsNullOrEmpty(code) )
				throw new ArgumentNullException("code");

			if( parameters == null )
				throw new ArgumentNullException("parameters");


			// 因为脚本可以重复执行，脚本会被重新编译，为了能正常卸载临时程序集，这里采用应用程序域来解决。
			AppDomain domain = AppDomain.CreateDomain("PreheatWebSite_ExecuteDomain");


			try {
				CompilerProxy server = (CompilerProxy)domain.CreateInstanceAndUnwrap(
								typeof(CompilerProxy).Assembly.FullName, typeof(CompilerProxy).FullName);

				// 执行脚本				
				return (Dictionary<string, string>)server.Execute(code, parameters);
			}
			finally {
				AppDomain.Unload(domain);
			}
		}

	}
}
