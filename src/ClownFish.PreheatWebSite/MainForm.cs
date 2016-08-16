using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClownFish.PreheatWebSite
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();			
		}

		#region 变量定义

		/// <summary>
		/// UI 线程的同步上下文，用于后台线程刷新UI
		/// </summary>
		private SynchronizationContext _syncContext = null;
		/// <summary>
		/// 脚本执行器
		/// </summary>
		private ScriptExecutor _executor = null;

		private ExecuteInfo _currentExecuteInfo = null;


		private static readonly int ICON_ITEM = 0;
		private static readonly int ICON_CURRENT = 1;
		//private static readonly int ICON_OK = 2;
		//private static readonly int ICON_ERROR = 3;

		#endregion

		private void MainForm_Load(object sender, EventArgs e)
		{
			imageList1.Images.Add(Properties.Resources.msg);
			imageList1.Images.Add(Properties.Resources.right3);
			imageList1.Images.Add(Properties.Resources.ok);
			imageList1.Images.Add(Properties.Resources.Class2);

			_syncContext = SynchronizationContext.Current;

			_executor = new ScriptExecutor();
			_executor.BeforeExecute += _executor_BeforeExecute;
			_executor.AfterExecute += _executor_AfterExecute;
			_executor.ExecuteError += _executor_ExecuteError;

			FileVersionInfo verInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
			this.Text += "  V" + verInfo.FileVersion;
		}
			


		private void MainForm_Shown(object sender, EventArgs e)
		{
			TryLoadDefaultFile();
		}

		private void TryLoadDefaultFile()
		{
			// 如果程序目录只有一个脚本文件，就自动加载了
			string binDirectory = Path.GetDirectoryName(Application.ExecutablePath);
			string[] files = Directory.GetFiles(binDirectory, "*.preheat.script", SearchOption.TopDirectoryOnly);
			if( files.Length == 1 )
				LoadScriptFile(files[0]);
		}


		private void linkOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.CheckFileExists = true;
			dialog.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath);
			dialog.Filter = "站点预热脚本文件(*.Preheat.script)|*.preheat.script";
			if( dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK ) {
				LoadScriptFile(dialog.FileName);
			}
		}


		private ExecuteInfo LoadScriptFile(string filePath)
		{
			ExecuteInfo execInfo = null;
			try {
				ScriptParser parser = new ScriptParser();
				execInfo = parser.Parse(filePath);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return null;
			}

			_currentExecuteInfo = execInfo;

			// 恢复控件状态
			txtScript.Text = execInfo.FileContext;
			progressBar.Value = 0;
			linkOpenFile.Text = filePath;
			labMessage.Text = "Ready.";


			listView1.BeginUpdate();
			listView1.Items.Clear();

			foreach( RequestInfo request in execInfo.List ) {
				ListViewItem item = new ListViewItem(request.RelativeUrl);
				item.ImageIndex = ICON_ITEM;
				item.SubItems.Add(string.Empty);
				listView1.Items.Add(item);
			}
			listView1.EndUpdate();
			

			return execInfo;
		}



		private void btnRun_Click(object sender, EventArgs e)
		{
			if( _currentExecuteInfo == null || txtScript.Text.Length == 0 ) {
				MessageBox.Show("请打开要执行的站点预热脚本。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			if( _currentExecuteInfo.List.Count == 0 ) {
				MessageBox.Show("没有需要执行的请求。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}


			linkOpenFile.Enabled = false;
			btnRun.Enabled = false;
			tabControl1.SelectedIndex = 1;
			progressBar.Maximum = _currentExecuteInfo.List.Count;


			if( _currentExecuteInfo.List[0].Result != null ) {
				// 脚本已执行过，此时要刷新界面图标以及上次的结果对象

				foreach( RequestInfo request in _currentExecuteInfo.List )
					request.Result = null;

				//foreach( ListViewItem item in listView1.Items )
				//	item.ImageIndex = ICON_ITEM;
			}
			
			backgroundWorker1.RunWorkerAsync();
		}

		

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = _executor.Execute(_currentExecuteInfo);
		}

		void _executor_ExecuteError(object sender, ScriptExecuteErrorEventArgs e)
		{
			_syncContext.Post(x => {
				ListViewItem item = listView1.Items[e.Index];
				item.ImageIndex = ICON_ITEM;	//ICON_ERROR;
				//item.BackColor = System.Drawing.Color.Pink;
				item.SubItems[1].Text = "-------";
				progressBar.Value = e.Index + 1;
			}, e);
		}

		void _executor_AfterExecute(object sender, ScriptExecuteEventArgs e)
		{
			_syncContext.Post(x => {
				ListViewItem item = listView1.Items[e.Index];
				item.ImageIndex = ICON_ITEM;	//ICON_OK;
				item.SubItems[1].Text = e.Request.Result.Time.ToString();
				progressBar.Value = e.Index + 1;
			}, e);
		}

		void _executor_BeforeExecute(object sender, ScriptExecuteEventArgs e)
		{
			_syncContext.Post(x => {
				ListViewItem item = listView1.Items[e.Index];
				item.ImageIndex = ICON_CURRENT;
				labMessage.Text = "正在请求：" + e.Option.Url;
			}, e);
		}
		


		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			linkOpenFile.Enabled = true;
			btnRun.Enabled = true;
			progressBar.Value = 0;

			if( e.Error != null ) {
				labMessage.Text = e.Error.Message;
				MessageBox.Show(e.Error.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else {
				labMessage.Text = ((ResultSummary)e.Result).Message;
			}
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if( this.listView1.SelectedIndices.Count == 0 ) {
				txtExecuteResult.Text = string.Empty;
				return;
			}

			if( listView1.Items.Count != _currentExecuteInfo.List.Count )
				return;

			int index = this.listView1.SelectedIndices[0];
			RequestInfo request = _currentExecuteInfo.List[index];

			if( request.Result == null ) {
				txtExecuteResult.Text = request.Text;
			}
			else {
				txtExecuteResult.Text = request.GettLogText();
			}
		}



		private void MainForm_Resize(object sender, EventArgs e)
		{
			try {
				this.columnHeader1.Width =
					this.Width - this.columnHeader2.Width
							- SystemInformation.VerticalScrollBarWidth * 4 
							- SystemInformation.BorderSize.Width * 6;
			}
			catch {
				// 防止窗口太小，导致宽度计算的结果无效。
			}
		}
	

		

		
		

		
	}
}
