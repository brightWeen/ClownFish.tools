using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class InputNameDialog : Form
	{
		public InputNameDialog()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if( InputText.Length == 0 ) {
				MessageBox.Show(label1.Text, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtName.Focus();
				return;
			}

			this.DialogResult = DialogResult.OK;
		}

		public string InputText
		{
			get { return txtName.Text.Trim(); }
			set { txtName.Text = value; }
		}


		public static string GetInputString()
		{
			InputNameDialog dlg = new InputNameDialog();
			if( dlg.ShowDialog() == DialogResult.OK )
				return dlg.InputText;
			else
				return null;
		}
	}
}
