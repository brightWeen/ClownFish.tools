using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Net;
using System.Diagnostics;


namespace ClownFish.Log.PerformanceAnalyzer
{
	public partial class SendRequestControl : BaseUserControl
	{
		internal Func<RunTimeSettings> GetRunTimeSettings { get; set; }

		
		public SendRequestControl()
		{
			InitializeComponent();
		}

		internal void SetRequestRaw(string requestRaw)
		{
			txtRequestRaw.Text = requestRaw;
			listResendResult.Items.Clear();
		}

		internal void ResendExecuteButtonClick()
		{
			this.btnResenExecute_Click(null, null);
		}

		private async void btnResenExecute_Click(object sender, EventArgs e)
		{
			if( btnResenExecute.Enabled == false )
				return;

			if( txtRequestRaw.Text.Length == 0 ) {
				MessageBox.Show("HttpRequest Raw Text Is Emtpy!", this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			try {
				RunTimeSettings settings = GetRunTimeSettings();
				RequestHelper helper = new RequestHelper(settings.LoginRequestRaw, settings.LoginCookieName);

				btnResenExecute.Enabled = false;
				List<ResendResult> list = await Task.Run(() => helper.BatchSendRequest(txtRequestRaw.Text, (int)numericUpDownResend.Value));

				ShowSendResult(list);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally {
				btnResenExecute.Enabled = true;
			}
		}

		private void ShowSendResult(List<ResendResult> list)
		{
			listResendResult.BeginUpdate();
			listResendResult.Items.Clear();

			long sumTime = 0;
			for( int i = 0; i < list.Count; i++ ) {
				sumTime += list[i].ExecuteTime.Ticks;

				ListViewItem item = new ListViewItem((i + 1).ToString());
				item.SubItems.Add(list[i].ExecuteTime.ToString());
				item.SubItems.Add(list[i].Message);
				listResendResult.Items.Add(item);
			}

			if( list.Count > 1 ) {

				TimeSpan ts = TimeSpan.FromTicks(sumTime / list.Count);
				ListViewItem avgItem = new ListViewItem("avg");
				avgItem.SubItems.Add(ts.ToString());
				avgItem.SubItems.Add("");
				listResendResult.Items.Add(avgItem);
			}

			listResendResult.EndUpdate();
		}

		

		
	}
}
