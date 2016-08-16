using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClownFish.Base;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class FileChangedDialog : Form
	{
		public FileChangedDialog()
		{
			InitializeComponent();
		}

		private void FileChangedDialog_Load(object sender, EventArgs e)
		{
			this.imageList1.Images.Add(Properties.Resources.config);
		}

		public void AddFile(FileSystemEventArgs e)
		{
			foreach( ListViewItem li in this.listView1.Items )
				if( li.ToolTipText.EqualsIgnoreCase(e.FullPath) )
					return;


			ListViewItem item = new ListViewItem(e.Name, 0);
			item.ToolTipText = e.FullPath;
			item.SubItems.Add(e.ChangeType.ToString());
			item.Tag = e;
			listView1.Items.Add(item);
		}

		public bool HasFile()
		{
			return this.listView1.Items.Count > 0;
		}

		public void ClearFiles()
		{
			this.listView1.Items.Clear();
		}

		private void btnYES_Click(object sender, EventArgs e)
		{
			List<FileSystemEventArgs> eventList = new List<FileSystemEventArgs>(listView1.Items.Count);

			foreach( ListViewItem item in this.listView1.Items )
				eventList.Add(item.Tag as FileSystemEventArgs);

			(this.Owner as MainForm).FileChangedDialog_YesButtonClicked(this.textBox1.Text, eventList);
		}

		private void btnNO_Click(object sender, EventArgs e)
		{
			(this.Owner as MainForm).FileChangedDialog_ClearAndHide();
		}

		private void btnOpen_Click(object sender, EventArgs e)
		{
			OpenDirectoryDialog dlg = new OpenDirectoryDialog();
			if( dlg.ShowDialog() == DialogResult.OK )
				this.textBox1.Text = dlg.SelectedPath;
		}

		private void FileChangedDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if( e.CloseReason == CloseReason.UserClosing ) {
				e.Cancel = true;
				this.btnNO_Click(null, null);
			}

		}
	}
}
