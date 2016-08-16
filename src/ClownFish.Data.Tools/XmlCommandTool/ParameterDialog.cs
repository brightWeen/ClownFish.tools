using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClownFish.Data.Xml;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class ParameterDialog : Form
	{
		public ParameterDialog()
		{
			InitializeComponent();
			this.Init();
		}

		private void Init()
		{
			string[] dbTypeArray = Enum.GetNames(typeof(System.Data.DbType));
			Array.Sort(dbTypeArray, StringComparer.OrdinalIgnoreCase);

			foreach(string dbtype in dbTypeArray)
				this.cboDbType.Items.Add(dbtype);

			string[] directionArray = Enum.GetNames(typeof(System.Data.ParameterDirection));
			foreach(string direction in directionArray)
				this.cboDirection.Items.Add(direction);

			this.cboDirection.SelectedIndex = 0;

			this.Location = new Point((SystemInformation.WorkingArea.Width - this.Width) / 2, 50);
		}
		
		private void btnOK_Click(object sender, EventArgs e)
		{
			string name = txtName.Text.Trim();

			if( (name.Length == 0) || (name.Length == 1 && char.IsLetter(name[0]) == false) ) {
				MessageBox.Show("参数Name不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtName.Focus();
				return;
			}

			if( cboDbType.SelectedIndex < 0 ) {
				MessageBox.Show("DbType必须要选择。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				cboDbType.Focus();
				return;
			}

			this.DialogResult = System.Windows.Forms.DialogResult.OK;
		}


		public XmlCmdParameter CommandParameter
		{
			get
			{
				return new XmlCmdParameter {
					Name = txtName.Text.Trim(),
					Type = (DbType)Enum.Parse(typeof(DbType), this.cboDbType.Text),
					Direction = (ParameterDirection)Enum.Parse(typeof(ParameterDirection), this.cboDirection.Text),
					Size = Convert.ToInt32(nudSize.Value)
				};
			}
			set
			{
				try {
					txtName.Text = value.Name;
					cboDbType.Text = value.Type.ToString();
					cboDirection.Text = value.Direction.ToString();
					nudSize.Value = value.Size;
				}
				catch { }
			}
		}

		private void ParameterDialog_Load(object sender, EventArgs e)
		{
			if( txtName.Text.Trim().Length == 0 ) {
				txtName.Text = "@";
				txtName.SelectionStart = 1;
				txtName.Focus();
			}
		}

		private void cboDbType_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();
			e.DrawFocusRectangle();

			if( e.Index >= 0 ) {
				string type = cboDbType.Items[e.Index].ToString();

				if( type == "DateTime" || type == "Currency" || type == "Int32" || type == "String" || type == "AnsiStringFixedLength" )
					e.Graphics.DrawString(type, e.Font, Brushes.Red, e.Bounds);
				else
					e.Graphics.DrawString(type, e.Font, new SolidBrush(e.ForeColor), e.Bounds);
			}
		}


	}
}
