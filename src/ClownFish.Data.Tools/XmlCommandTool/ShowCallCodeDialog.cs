using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClownFish.Data;
using ClownFish.Data.Tools.EntityGenerator;
using ClownFish.Data.Xml;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class ShowCallCodeDialog : Form
	{
		private XmlCommandItem _command;
		private string _nodeText;

		public ShowCallCodeDialog(XmlCommandItem command, string nodeText)
		{
			InitializeComponent();
			_command = command;
			_nodeText = nodeText;
		}

		private void btnCopyAll_Click(object sender, EventArgs e)
		{
			if( txtCode.Text.Length > 0 )
				Clipboard.SetText(txtCode.Text);

			this.Close();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ucParameterStyle1_OptionChanged(object sender, EventArgs e)
		{
			GenerateSpCallCode();
		}

		private void ShowCallCodeDialog_Load(object sender, EventArgs e)
		{
			GenerateSpCallCode();
		}

		private void GenerateSpCallCode()
		{
			int parameterNamePrefixLen = Generator.GuessParameterNamePrefixLen(_command);
			this.txtCode.Text = Generator.GenerateXmlCommandCallCode(
							_command, _nodeText, parameterNamePrefixLen, this.ucParameterStyle1.UseNamedType);
		}


	}
}
