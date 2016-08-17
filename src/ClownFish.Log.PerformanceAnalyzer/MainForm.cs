using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClownFish.Log.PerformanceAnalyzer.Events;


namespace ClownFish.Log.PerformanceAnalyzer
{
	public partial class MainForm : Form
	{

		private RunTimeSettings _runTimeSettings;
		

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Shown(object sender, EventArgs e)
		{
			SetIcon();

			// 加载参数
			_runTimeSettings = RunTimeSettings.LoadSettings();

			logSearchControl1.GetRunTimeSettings = () => _runTimeSettings;
			logSearchControl1.ReSendButtonClick += LogSearchControl1_ReSendButtonClick;

			sendRequestControl1.GetRunTimeSettings = () => _runTimeSettings;
					

			// 将参数显示到设置界面
			settingsControl1.ShowSettings(_runTimeSettings);
			settingsControl1.CancelSettingButtonClick += SettingsControl1_CancelSettingButtonClick;
			settingsControl1.SaveSettingButtonClick += SettingsControl1_SaveSettingButtonClick;

			foreach(var page in tabControl1.Controls ) 
				((page as TabPage).Controls[0] as BaseUserControl).OnFormLoad();
		}

		private void SetIcon()
		{
			this.imageList1.Images.Add(Properties.Resources.grid7);
			this.imageList1.Images.Add(Properties.Resources.right3);
			this.imageList1.Images.Add(Properties.Resources.set5);

			this.tabControl1.ImageList = this.imageList1;
			this.tabPage1.ImageIndex = 0;
			this.tabPage2.ImageIndex = 1;
			this.tabPage3.ImageIndex = 2;

		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			foreach( var page in tabControl1.Controls )
				((page as TabPage).Controls[0] as BaseUserControl).OnFormClose();
		}

		private void SettingsControl1_SaveSettingButtonClick(object sender, SaveSettingsEventArgs e)
		{
			_runTimeSettings = e.NewSettings;
		}

		private void SettingsControl1_CancelSettingButtonClick(object sender, EventArgs e)
		{
			settingsControl1.ShowSettings(_runTimeSettings);
		}

		private void LogSearchControl1_ReSendButtonClick(object sender, ReSendEventArgs e)
		{
			tabControl1.SelectedTab = this.tabPage2;
			sendRequestControl1.SetRequestRaw(e.RequestRaw);
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.KeyCode == Keys.F4 ) {
				if( tabControl1.SelectedTab == this.tabPage1 ) {
					logSearchControl1.LinkResendToButtonClick();
				}
			}
			else if( e.KeyCode == Keys.F5 ) {
				if( tabControl1.SelectedTab == this.tabPage2 ) {
					sendRequestControl1.ResendExecuteButtonClick();
				}
			}
		}

		
	}
}
