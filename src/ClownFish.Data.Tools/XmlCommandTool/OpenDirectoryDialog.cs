using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class OpenDirectoryDialog : Form
	{
		public OpenDirectoryDialog()
		{
			InitializeComponent();
		}

		private void OpenDirectoryDialog_Shown(object sender, EventArgs e)
		{
			string lastPath = RegisterHelper.SafeRead("XmlCommandFilePath", string.Empty).ToString();

			try {
				if( Directory.Exists(lastPath) )
					txtPath.Text = lastPath;

				else {
					string text = Clipboard.GetText();
					if( string.IsNullOrEmpty(text) == false ) {
						if( Directory.Exists(text) )
							txtPath.Text = text;
					}
				}
			}
			catch { }
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dlg = new FolderBrowserDialog();
			dlg.Description = "请选择数据访问配置文件所在路径";
			dlg.ShowNewFolderButton = false;

			if( txtPath.Text.Length > 0 )
				dlg.SelectedPath = txtPath.Text;

			if( dlg.ShowDialog() == DialogResult.OK )
				txtPath.Text = dlg.SelectedPath;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if( txtPath.Text.Trim().Length ==0){
				MessageBox.Show(label1.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtPath.Focus();
				return;
			}


			try {
				if( Directory.Exists(txtPath.Text) == false ) {
					MessageBox.Show("指定的目录不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					txtPath.Focus();
					return;
				}
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			this.DialogResult = DialogResult.OK;				
		}


		public string SelectedPath
		{
			get { return txtPath.Text.Trim(); }
		}
	}
}
