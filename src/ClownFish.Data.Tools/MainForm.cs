using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClownFish.Data.Tools
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
			this.Text += " V" + fileVersionInfo.FileVersion;
		}

		public void AddMdiChildFormAndShow(Form form)
		{
			form.MdiParent = this;
			form.Show();
			form.WindowState = FormWindowState.Maximized;
		}

		public Form GetExistForm<T>()
		{
			foreach( Form form in this.MdiChildren )
				if( form is T )
					return form;

			return null;
		}

		private void ShowMdiChildForm<T>() where T : Form, new()
		{
			string formId = typeof(T).ToString();

			Form existForm = this.GetExistForm<T>();
			if( existForm != null ) {
				existForm.Select();
				return;
			}

			T form = new T();
			this.AddMdiChildFormAndShow(form);
		}
		private void xmlCommand配置ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowMdiChildForm<XmlCommandTool.MainForm>();
		}

		private void 实体生成ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ShowMdiChildForm<EntityGenerator.MainForm>();
		}

		
	}
}
