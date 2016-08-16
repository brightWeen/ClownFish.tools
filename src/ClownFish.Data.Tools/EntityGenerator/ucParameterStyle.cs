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
	public partial class ucParameterStyle : UserControl
	{
		public ucParameterStyle()
		{
			InitializeComponent();
		}

		public event EventHandler OptionChanged;

		[Browsable(false)]
		public bool UseNamedType
		{
			get { return rbtnNamed.Checked; }
		}

		private void rbtnNamed_CheckedChanged(object sender, EventArgs e)
		{
			if( OptionChanged != null )
				OptionChanged(sender, e);
		}
	}
}
