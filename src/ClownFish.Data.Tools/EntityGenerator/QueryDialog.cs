using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClownFish.Data.Tools.EntityGenerator
{
	public partial class QueryDialog : Form
	{
		private string _connectionString;
		private string _database;

		public QueryDialog(string connectionString, string database)
		{
			InitializeComponent();

			_connectionString = connectionString;
			_database = database;
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			if( txtSql.Text.Trim().Length == 0 )
				return;

			try {
				string query = txtSql.Text.Trim();
				List<Field> fields = SqlServerHelper.GetFieldsFromQuery(_connectionString, _database, query);
				txtCsCode.Text = Generator.GenerateCode(
											"YourModelClassName",
											fields,
											this.ucCsClassStyle1.CodeStyle
									);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void QueryDialog_Shown(object sender, EventArgs e)
		{
			txtSql.Text = "select top 1 * from [xxxxxxxxxxxx]";
		}

		private void ucCsClassStyle1_OptionChanged(object sender, EventArgs e)
		{
			if( txtCsCode.Text.Length == 0 )
				return;

			btnGenerate_Click(null, null);
		}
	}
}
