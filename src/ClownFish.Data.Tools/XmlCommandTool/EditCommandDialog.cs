using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClownFish.Base.Xml;
using ClownFish.Data;
using ClownFish.Data.Xml;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class EditCommandDialog : Form
	{
		public EditCommandDialog()
		{
			InitializeComponent();

			string[] commandTypes = Enum.GetNames(typeof(System.Data.CommandType));
			foreach( string type in commandTypes )
				this.cboCommandType.Items.Add(type);
			cboCommandType.SelectedIndex = 0;
		}

		private static readonly string s_flagString = "<XmlCommand Name=";


		private void EditCommandDialog_Load(object sender, EventArgs e)
		{
			this.imageList1.Images.Add(Properties.Resources.msg);

			if( txtName.Text.Length > 0 )
				this.Text = "编辑命令";

			try {
				btnImport.Visible = Clipboard.GetText().IndexOf(s_flagString) >= 0;
			}
			catch { }
		}

		private void EditCommandDialog_Shown(object sender, EventArgs e)
		{
			if( txtName.Text.Length > 0 )
				txtCode.Focus();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			ParameterDialog dlg = new ParameterDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			listView1.Items.Add(CreateListViewItem(dlg.CommandParameter));
		}

		private ListViewItem CreateListViewItem(XmlCmdParameter parameter)
		{
			ListViewItem item = new ListViewItem(parameter.Name, 0);
			item.SubItems.Add(parameter.Type.ToString());
			item.SubItems.Add(parameter.Direction.ToString());
			item.SubItems.Add(parameter.Size.ToString());
			item.Tag = parameter;
			return item;
		}

		private void SetCommnadToListViewItem(ListViewItem item, XmlCmdParameter parameter)
		{
			item.Text = parameter.Name;
			item.SubItems[1].Text = parameter.Type.ToString();
			item.SubItems[2].Text = parameter.Direction.ToString();
			item.SubItems[3].Text = parameter.Size.ToString();
			item.Tag = parameter;
		}

		private void btnEdit_Click(object sender, EventArgs e)
		{
			if( listView1.SelectedItems.Count == 0 )
				return;

			ListViewItem item = listView1.SelectedItems[0];

			ParameterDialog dlg = new ParameterDialog();
			dlg.CommandParameter = (XmlCmdParameter)item.Tag;
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			SetCommnadToListViewItem(item, dlg.CommandParameter);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if( listView1.SelectedItems.Count == 0 )
				return;

			int index = listView1.SelectedIndices[0];
			int newFocus = (index > 0 ? index : 0);

			listView1.Items.RemoveAt(index);

			if( listView1.Items.Count > 0 ) {
				if( newFocus <= listView1.Items.Count - 1 )
					listView1.Items[newFocus].Selected = true;
			}

			listView1.Focus();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if( txtName.Text.Trim().Length == 0 ) {
				MessageBox.Show("命令名称不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtName.Focus();
				return;
			}

			if( txtCode.Text.Length == 0 ) {
				MessageBox.Show("命令代码不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txtCode.Focus();
				return;
			}

			this.DialogResult = DialogResult.OK;

		}

		private void listView1_Resize(object sender, EventArgs e)
		{
			if( listView1.Width > 
				columnHeader2.Width + columnHeader3.Width + columnHeader4.Width 
				+ SystemInformation.VerticalScrollBarWidth + SystemInformation.BorderSize.Width  + 10 ) {

				try {
					columnHeader1.Width = listView1.Width - SystemInformation.BorderSize.Width * 2
						- columnHeader2.Width - columnHeader3.Width - columnHeader4.Width - SystemInformation.VerticalScrollBarWidth - 5;
				}
				catch { }
			}
		}



		private List<XmlCmdParameter> Parameters
		{
			get
			{
				List<XmlCmdParameter> list = new List<XmlCmdParameter>(listView1.Items.Count);

				for( int i = 0; i < listView1.Items.Count; i++ )
					list.Add((XmlCmdParameter)listView1.Items[i].Tag);

				return list;
			}
			set
			{
				if( value == null )
					return;

				listView1.Items.Clear();
				foreach(XmlCmdParameter para in value)
					listView1.Items.Add(CreateListViewItem(para));
			}
		}


		public XmlCommandItem Command
		{
			get
			{
				XmlCommandItem xmlCommand = new XmlCommandItem();
				xmlCommand.CommandName = this.txtName.Text.Trim();
				xmlCommand.CommandText = this.txtCode.Text;
				xmlCommand.Database = (txtDataBase.Text.Trim().Length == 0 ? null : txtDataBase.Text.Trim());
				xmlCommand.Parameters = this.Parameters;
				xmlCommand.CommandType = (CommandType)Enum.Parse(typeof(CommandType), cboCommandType.Text);
				xmlCommand.Timeout = (int)this.nudTimeout.Value;
				return xmlCommand;
			}
			set
			{
				if( value == null )
					return;

				this.txtName.Text = value.CommandName;
				this.txtCode.Text = value.CommandText;
				this.txtDataBase.Text = value.Database;
				this.Parameters = value.Parameters;
				this.nudTimeout.Value = value.Timeout;
				cboCommandType.Text = value.CommandType.ToString();
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			try {
				string xml = Clipboard.GetText();
				if( string.IsNullOrEmpty(xml) ) 
					return;
				

				if( xml.IndexOf(s_flagString) < 0 ) 
					return;


				XmlCommandItem command = XmlHelper.XmlDeserialize<XmlCommandItem>(xml);
				if( command != null )
					this.Command = command;
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally {
				btnImport.Visible = false;
			}
		}

		
	}
}
