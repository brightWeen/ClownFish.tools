using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fiddler;

namespace ClownFish.FiddlerPulgin
{
	public partial class DbActionListControl : UserControl
	{
		public DbActionListControl()
		{
			InitializeComponent();

			if( this.DesignMode == false ) {
				this.imageList1.Images.Add(Properties.Resources.event2);
				this.imageList1.Images.Add(Properties.Resources.ball3);
				this.imageList1.Images.Add(Properties.Resources.ball4);
				this.imageList1.Images.Add(Properties.Resources.ball5);
				this.imageList1.Images.Add(Properties.Resources.Error);
				labSumTime.Text = string.Empty;
			}
		}

		public event EventHandler OnEnableProfilerChanged;

		private void chkEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if( this.OnEnableProfilerChanged != null )
				this.OnEnableProfilerChanged(sender, e);
		}

		public bool EnableDbProfiler
		{
			get { return this.chkEnabled.Checked; }
		}


		public void RefreshUI(Session oSession)
		{
			List<DbActionInfo> list = TryGetDbActionListFromResponseHeader(oSession);
			if( list != null )
				this.LoadData(list);
			else
				this.ClearUI();
		}


		private List<DbActionInfo> TryGetDbActionListFromResponseHeader(Session oSession)
		{
			List<DbActionInfo> list = null;

			int index = 1;
			for( ;;) {
				string headerName = "X-SQL-Action-" + (index++).ToString();
				string value = oSession.GetResponseHeader<string>(headerName);
				if( string.IsNullOrEmpty(value) )
					break;

				DbActionInfo info = DbActionInfo.Deserialize(value);

				if( list == null )
					list = new List<DbActionInfo>();
				list.Add(info);
			}

			return list;
		}


		public void LoadData(List<DbActionInfo> list)
		{
			if( list == null )
				return;


			this.listView1.BeginUpdate();
			this.listView1.Items.Clear();
			this.textBox1.Text = string.Empty;

			TimeSpan sumTimeSpan = TimeSpan.FromMilliseconds(0d);
			int index = 1;

			int groupIndex = 1;
			ListViewGroup g = null;

			foreach( DbActionInfo info in list ) {
				if( info.SqlText == DbActionInfo.OpenConnectionFlag ) {
					g = new ListViewGroup(string.Format("第 {0} 次打开连接", (groupIndex++).ToString()));
					listView1.Groups.Add(g);
				}
				else {
					ListViewItem item = new ListViewItem((index++).ToString());
					if( info.ErrorMsg != null )
						item.ImageIndex = 4;
					else if( info.Time.TotalMilliseconds < 100 )
						item.ImageIndex = 1;
					else if( info.Time.TotalMilliseconds > 1000 ) {
						item.ImageIndex = 3;
						item.BackColor = System.Drawing.Color.LightPink;
					}
					else
						item.ImageIndex = 2;

					if( info.InTranscation )
						item.ForeColor = System.Drawing.Color.Blue;


					item.SubItems.Add(info.Time.ToString());
					item.SubItems.Add(info.SqlText.SubstringN(320));
					item.Tag = info;

					if( g != null )
						item.Group = g;

					listView1.Items.Add(item);
					sumTimeSpan += info.Time;
				}
			}
			listView1.EndUpdate();

			if( index > 1 ) {
				labSumTime.Text = "Sum: " + sumTimeSpan.ToString();

				if( sumTimeSpan.TotalMilliseconds > 1500 )
					labSumTime.ForeColor = System.Drawing.Color.Red;
				else
					labSumTime.ForeColor = SystemColors.WindowText;
			}
			else {
				labSumTime.Text = string.Empty;
				labSumTime.ForeColor = SystemColors.WindowText;
			}


			if( listView1.Items.Count > 0 ) {
				listView1.Items[0].Selected = true;
			}
		}


		private void DbActionListControl_Resize(object sender, EventArgs e)
		{
			this.columnHeader3.Width = this.Width
				- this.columnHeader1.Width
				- this.columnHeader2.Width
				- SystemInformation.VerticalScrollBarWidth * 2
				- SystemInformation.Border3DSize.Width * 4;
		}


		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if( listView1.SelectedItems.Count < 1 )
				return;

			ListViewItem item = listView1.SelectedItems[0];
			DbActionInfo info = (DbActionInfo)item.Tag;

			if( info.SqlText == DbActionInfo.OpenConnectionFlag ) {
				textBox1.Text = string.Empty;
				return;
			}

			// 在XmlCommand中 \r\n 读取后会变成 \n ，这是XML规范问题，所以只能在这里强制添加 \r，
			// http://stackoverflow.com/questions/2004386/how-to-save-newlines-in-xml-attribute
			// 如果是用CPQuery拼接出来的SQL，即使包含\r\n，替换后也能正常显示。

			// 如果希望精确处理XmlCommand，
			// 可以在DataLayerEventSubscriber的Instance_AfterExecute，Instance_OnException
			// 中判断是不是XmlCommand，继而可以针对地处理。
			// 这里简单地处理算了！

			string commandText = info.SqlText.Replace("\n", "\r\n");
			StringBuilder sb = new StringBuilder(commandText);
						
			sb.AppendLine("\r\n");


			if( info.ErrorMsg != null ) {
				sb.AppendLine()
					.AppendLine("---------------------------------------------------------------------------------")
					.AppendLine("Error:")
					.AppendLine(info.ErrorMsg)
					.AppendLine();
			}

			if( info.Parameters != null && info.Parameters.Count > 0 ) {
				sb.AppendLine()
					.AppendLine("---------------------------------------------------------------------------------")
					.AppendLine("Parameters:");

				foreach( CommandParameter p in info.Parameters )
					sb.AppendFormat("  {0} = ({1}) {2}\r\n", p.Name, p.DbType, p.Value);

				sb.AppendLine();
			}
	
			textBox1.Text = sb.ToString();
		}

		public void ClearUI()
		{
			listView1.Items.Clear();
			textBox1.Text = string.Empty;
			labSumTime.Text = string.Empty;
		}

		
	}
}
