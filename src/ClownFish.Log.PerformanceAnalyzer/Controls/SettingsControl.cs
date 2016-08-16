using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClownFish.Log.PerformanceAnalyzer.Events;
using ClownFish.Base.Xml;
using ClownFish.Base.WebClient;

namespace ClownFish.Log.PerformanceAnalyzer
{
	public partial class SettingsControl : BaseUserControl
	{
		internal event EventHandler CancelSettingButtonClick;
		internal event EventHandler<SaveSettingsEventArgs> SaveSettingButtonClick;

		public SettingsControl()
		{
			InitializeComponent();
		}

		internal void ShowSettings(RunTimeSettings settings)
		{
			txtMongoDbConnectionString.Text = settings.MongoDbConnectionString;
			txtLoginCookieName.Text = settings.LoginCookieName;
			txtLoginRequestRaw.Text = settings.LoginRequestRaw.Value.Replace("\n", "\r\n");
		}

		private void btnCancelSetting_Click(object sender, EventArgs e)
		{
			EventHandler eventHandler = this.CancelSettingButtonClick;
			if( eventHandler != null )
				eventHandler(btnCancelSetting, EventArgs.Empty);
		}

		private void btnSaveSetting_Click(object sender, EventArgs e)
		{
			if( txtMongoDbConnectionString.Text.Length == 0 ) {
				MessageBox.Show("日志数据库的连接字符串不能为空。", this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if( txtLoginCookieName.Text.Length == 0 ) {
				MessageBox.Show("登录Cookie名称不能为空。", this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if( txtLoginRequestRaw.Text.Length == 0 ) {
				MessageBox.Show("登录请求文本不能为空。", this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try {
				// 检验输入的请求文本是否正确
				HttpOption option = HttpOption.FromRawText(txtLoginRequestRaw.Text);
				Uri uri = new Uri(option.Url);

				if( option.Data == null )
					throw new ArgumentException("没有登录操作需要的提交数据。");
			}
			catch(Exception ex ) {
				MessageBox.Show(ex.Message, this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			RunTimeSettings settings = new RunTimeSettings();
			settings.MongoDbConnectionString = txtMongoDbConnectionString.Text;
			settings.LoginCookieName = txtLoginCookieName.Text;
			settings.LoginRequestRaw = txtLoginRequestRaw.Text;

			XmlHelper.XmlSerializeToFile(settings, "RunTimeSettings.config", Encoding.UTF8);

			MessageBox.Show("保存操作成功完成。", this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

			EventHandler<SaveSettingsEventArgs> eventHandler = this.SaveSettingButtonClick;
			if( eventHandler != null ) {
				SaveSettingsEventArgs args = new SaveSettingsEventArgs { NewSettings = settings };
				eventHandler(btnCancelSetting, args);
			}
		}



	}
}
