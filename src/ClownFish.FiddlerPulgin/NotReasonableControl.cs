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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections;
using System.Threading;
using System.Security.Cryptography;

namespace ClownFish.FiddlerPulgin
{
	public partial class NotReasonableControl : UserControl
	{

		// 用于缓存将要添加到列表的记录，避免频繁刷新列表
		private List<MsgSessionItem> _messageQueue	= new List<MsgSessionItem>();

		// 供线程分析重复请求的工作队列
		private Queue<Session> _threadQueue = new Queue<Session>();


		// 用于避免重复记录相同请求，
		// 供后台线程分析用，需要考虑【线程同步】
		private Dictionary<string, int> _repeatDict = new Dictionary<string, int>(1024, StringComparer.OrdinalIgnoreCase);

		// 用于避免生重复记录同类请求，采用 Reason + URL 做为 KEY
		// 仅供 FiddlerExtention 触发，不考虑线程同步
		private Dictionary<string, int> _urlDict = new Dictionary<string, int>();


		private class MsgSessionItem
		{
			public string Message;
			public Fiddler.Session Session;
		}


		public NotReasonableControl()
		{
			InitializeComponent();

			if( this.DesignMode == false ) {
				this.imageList1.Images.Add(Properties.Resources.Error);
				this.timer1.Enabled = true;

				StartAnalyzeRepeatRequestThread();
			}
		}

		public event EventHandler OnEnableProfilerChanged;

		private void chkEnabled_CheckedChanged(object sender, EventArgs e)
		{
			if( this.OnEnableProfilerChanged != null )
				this.OnEnableProfilerChanged(sender, e);
		}

		public bool EnableAnalyzeRequest
		{
			get { return this.chkEnabled.Checked; }
		}

		private void NotReasonableControl_Resize(object sender, EventArgs e)
		{
			this.columnHeader3.Width = this.Width
				- this.columnHeader1.Width
				- this.columnHeader2.Width
				- SystemInformation.VerticalScrollBarWidth * 2
				- SystemInformation.Border3DSize.Width * 4;
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if( listView1.SelectedItems.Count > 0 ) {
				ListViewItem item = listView1.SelectedItems[0];
				textBox1.Text = item.Tag.ToString();
			}
			else
				textBox1.Text = string.Empty;
		}


		internal void AddSession(string reason, Fiddler.Session session, bool checkRepeat)
		{
			if( checkRepeat ) {
				string key = reason + session.fullUrl;
				int value = 0;

				//lock( ((ICollection)_urlDict).SyncRoot ) {
					if( _urlDict.TryGetValue(key, out value) == false ) {	// 只取第一个遇到的请求
						_urlDict[key] = 1;		// 这行代码曾经发生过莫名奇妙的报错，
					}
					else {
						return;
					}
				//}
			}

			lock( ((ICollection)_messageQueue).SyncRoot ) {
				_messageQueue.Add(new MsgSessionItem { Message = reason, Session = session });
			}
		}

		internal void AnalyzeRepeatRequest(Session oSession)
		{
			lock( (_threadQueue as ICollection).SyncRoot ) {
				_threadQueue.Enqueue(oSession);
			}
		}


		private void StartAnalyzeRepeatRequestThread()
		{
			Thread thread = new Thread(ThreadFunction);
			thread.IsBackground = true;
			thread.Name = "StartAnalyzeRepeatRequestThread";
			thread.Start();
		}

		private void ThreadFunction()
		{
			Session session = null;

			while( true ) {
				session = null;		// 尽量释放引用

				lock( (_threadQueue as ICollection).SyncRoot ) {
					if( _threadQueue.Count > 0 )
						session = _threadQueue.Dequeue();
				}

				if( session == null ) {
					System.Threading.Thread.Sleep(2000);
					continue;
				}

				try {
					AnalyzeRepeatRequestActioin(session);
				}
				catch { /* 先吃掉异常 */ }
			}
		}


		private void AnalyzeRepeatRequestActioin(Session session)
		{
			string key = GetRequestUniqueKey(session);

			int value = 0;

			lock( (_repeatDict as ICollection).SyncRoot ) {

				if( _repeatDict.TryGetValue(key, out value) == false ) 
					_repeatDict[key] = 1;
				
				else
					_repeatDict[key] = (++value);
			}

			if( value == 2 )		// 第一次发现重复
				AddSession("重复的请求*", session, false);			
		}


		private string GetRequestUniqueKey(Session session)
		{
			//// 这种方式可以提升性能，但是可能会导致误判，因为不分析具体提交和响应的数据
			//// 误判的机率应该很小，所以就先这样处理。
			//return string.Format("{0},{1},{2}",
			//	(session.requestBodyBytes != null ? session.requestBodyBytes.Length : 0),
			//	(session.responseBodyBytes.Length),
			//	session.fullUrl);

			StringBuilder sb = new StringBuilder();
			sb.Append(session.fullUrl).Append("#");

			if( session.requestBodyBytes != null && session.requestBodyBytes.Length > 0 ) {
				byte[] m1 = (new MD5CryptoServiceProvider()).ComputeHash(session.requestBodyBytes);
				sb.Append(BitConverter.ToString(m1)).Append("#");				
			}
			else
				sb.Append("##");

			if( session.responseBodyBytes != null && session.responseBodyBytes.Length > 0 ) {
				byte[] m2 = (new MD5CryptoServiceProvider()).ComputeHash(session.responseBodyBytes);
				sb.Append(BitConverter.ToString(m2)).Append("#");
			}
			else
				sb.Append("##");

			return sb.ToString();
		}


		private void listView1_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.Control ) {
				if( e.KeyCode == Keys.A ) {		// 全选
					foreach( ListViewItem item in listView1.Items )
						item.Selected = true;
				}
				else if( e.KeyCode == Keys.X ) {	// 全部删除，清空
					btnClear_Click(null, null);
				}

			}
			else {
				if( e.KeyCode == Keys.Delete ) {	// 删除当前选中行
					listView1.BeginUpdate();
					while( listView1.SelectedIndices.Count > 0 )
						listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
					listView1.EndUpdate();
				}
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if( FiddlerApplication.isClosing ) {
				return;
			}

			List<MsgSessionItem> tempList = null;

			lock( ((ICollection)_messageQueue).SyncRoot ) {
				if( _messageQueue.Count > 0 ) {
					// 把要显示的消息放到临时列表中，避免锁定时间过长
					tempList = (from m in _messageQueue select m).ToList();
					_messageQueue.Clear();
				}
			}


			if( tempList != null ) {
				int index = 1;
				if( listView1.Items.Count > 0 )		// 保证序号是连续的，从最后一条记录中 +1
					index = int.Parse(listView1.Items[listView1.Items.Count - 1].Text) + 1;

				timer1.Enabled = false;
				ListViewItem[] items = new ListViewItem[tempList.Count];

				for( int i = 0; i < tempList.Count; i++ ) {
					MsgSessionItem msi = tempList[i];

					ListViewItem item = new ListViewItem((index++).ToString(), 0);
					item.SubItems.Add(msi.Message);
					item.SubItems.Add(msi.Session.PathAndQuery);
					item.Tag = msi.Session.oRequest.headers.ToString() + "\r\n\r\n" + msi.Session.GetRequestBodyAsString();
					items[i] = item;
				}

				listView1.Items.AddRange(items);

				listView1.Items[listView1.Items.Count - 1].EnsureVisible();
				timer1.Enabled = true;
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			listView1.Items.Clear();			

			textBox1.Text = string.Empty;


			//lock( ((ICollection)_urlDict).SyncRoot ) {
				_urlDict.Clear();
			//}

			lock( (_repeatDict as ICollection).SyncRoot ) {
				_repeatDict.Clear();
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.CheckFileExists = true;
			dlg.RestoreDirectory = true;
			dlg.Filter = "*.NotReasonable.json|*.NotReasonable.json";

			if( dlg.ShowDialog() != DialogResult.OK )
				return;


			List<NotReasonableItem> list = null;
			try {
				string json = System.IO.File.ReadAllText(dlg.FileName, Encoding.UTF8);
				list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<NotReasonableItem>>(json);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, "ClownFish.FiddlerPulgin 导入失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			if( list != null ) {
				this.listView1.Items.Clear();

				int index = 1;
				ListViewItem[] items = new ListViewItem[list.Count];

				for( int i = 0; i < list.Count; i++ ) {
					NotReasonableItem m = list[i];

					ListViewItem item = new ListViewItem((index++).ToString(), 0);
					item.SubItems.Add(m.Reason);
					item.SubItems.Add(m.Url);
					item.Tag = m.GetRequestText();
					items[i] = item;
				}
				listView1.Items.AddRange(items);
			}
		}

		private void btnOutput_Click(object sender, EventArgs e)
		{
			if( listView1.Items.Count == 0 )
				return;

			SaveFileDialog dlg = new SaveFileDialog();
			dlg.CheckPathExists = true;
			dlg.RestoreDirectory = true;
			dlg.Filter = "*.NotReasonable.json|*.NotReasonable.json";

			if( dlg.ShowDialog() != DialogResult.OK )
				return;


			List<NotReasonableItem> list = new List<NotReasonableItem>(this.listView1.Items.Count);
			foreach( ListViewItem item in this.listView1.Items ) {
				NotReasonableItem m = new NotReasonableItem();
				m.Reason = item.SubItems[1].Text;
				m.Url = item.SubItems[2].Text;
				m.SetRequestText(item.Tag.ToString());
				list.Add(m);
			}

			try {
				string json = Newtonsoft.Json.JsonConvert.SerializeObject(list, Newtonsoft.Json.Formatting.Indented);
				System.IO.File.WriteAllText(dlg.FileName, json, Encoding.UTF8);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, "ClownFish.FiddlerPulgin 导出失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

		}

		




		
	}
}
