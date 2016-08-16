using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClownFish.PreheatWebSite
{
	static class Program
	{
		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main()
		{
			CreateLogDirectory();

			string[] args = System.Environment.GetCommandLineArgs();

			if( args.Length > 1 ) {
				try {
					RunCommandLine(args);
				}
				catch( Exception ex ) {
					ScriptExecutor.SafeWriteLogFile(ex.ToString());
				}

				return;
			}


			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new MainForm());
		}


		private static void CreateLogDirectory()
		{
			string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
			if( Directory.Exists(logDirectory) == false )
				Directory.CreateDirectory(logDirectory);
		}

		private static void RunCommandLine(string[] args)
		{
			// 命令行格式：  ClownFish.PreheatWebSite.exe  "x:\xxxx\test1.preheat.script"

			string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, args[1]);

			ScriptParser parser = new ScriptParser();
			ExecuteInfo execInfo = parser.Parse(filePath);

			if( execInfo.List.Count == 0 )
				throw new InvalidOperationException("没有需要执行的任务。");

			ScriptExecutor executor = new ScriptExecutor();
			executor.Execute(execInfo);	
		}
	}
}
