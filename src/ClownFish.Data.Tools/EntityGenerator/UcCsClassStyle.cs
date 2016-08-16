using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClownFish.Data.Tools.EntityGenerator
{
	public partial class UcCsClassStyle : UserControl
	{
		public UcCsClassStyle()
		{
			InitializeComponent();
		}

		public event EventHandler OptionChanged;

		[Browsable(false)]
		public CsClassStyle CodeStyle
		{
			get
			{
				return new CsClassStyle {
					//MemberStyle = CsClassMemberStyle.AutoProperty,
					SupportWCF = chkWCF.Checked,
					SortByName = chkSortByName.Checked
				};				
			}
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if( OptionChanged != null )
				OptionChanged(sender, e);
		}
	}
}
