using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClownFish.Log.Model;
using ClownFish.Log.PerformanceAnalyzer.ListVewModel;
using ClownFish.Log.PerformanceAnalyzer.Events;
using ClownFish.Base.Xml;
using System.Linq.Dynamic;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace ClownFish.Log.PerformanceAnalyzer
{
	public partial class LogSearchControl : BaseUserControl
	{
		private LogAnalyzer _logAnalyzer = new LogAnalyzer();
		private List<GroupResult> _lastSearchResult;

		internal event EventHandler<ReSendEventArgs> ReSendButtonClick;
		internal Func<RunTimeSettings> GetRunTimeSettings { get; set; }
		private TimeSpan LastQueryTime { get; set; }

		private static readonly string s_defaultFilter = "Count > 5 && Url.StartsWith(\"http://\")";
		private static readonly string s_regPath = @"SOFTWARE\Fish-Li\ClownFish.Log.PerformanceAnalyzer";

		public LogSearchControl()
		{
			InitializeComponent();
		}

		public override void OnFormLoad()
		{
			base.OnFormLoad();

			dateTimePickerEnd.Value = DateTime.Today;
			dateTimePickerStart.Value = DateTime.Today.AddDays(-7);

			txtFilter.Text = LoadLastFilter();

			if( txtFilter.Text.Length == 0 ) 
				txtFilter.Text = s_defaultFilter;
		}


		private string LoadLastFilter()
		{
			try {
				using( RegistryKey key = Registry.CurrentUser.OpenSubKey(s_regPath, false) ) {
					if( key != null ) {
						object val = key.GetValue("lastFilter", string.Empty);
						return val.ToString();
					}
				}
			}
			catch { }

			return string.Empty;
		}


		public override void OnFormClose()
		{
			base.OnFormClose();

			if( txtFilter.Text != s_defaultFilter ) {
				RegistryKey key = null;
				using(key = Registry.CurrentUser.OpenSubKey(s_regPath, true) ) {
					if( key == null )
						key = Registry.CurrentUser.CreateSubKey(s_regPath);

					if( key != null ) {
						key.SetValue("lastFilter", txtFilter.Text);
					}
				}
			}
		}

		private
			async
			void btnSearchData_Click(object sender, EventArgs e)
		{
			if( btnSearchData.Enabled == false )
				return;


			DateTime start = dateTimePickerStart.Value.Date;
			DateTime end = dateTimePickerEnd.Value.Date;

			if( end < start ) {
				MessageBox.Show("结束日期必须大于开始日期。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dateTimePickerStart.Focus();
				return;
			}

			if( end.Subtract(start).Days > 15 ) {
				MessageBox.Show("日期范围不允许超过15天。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				dateTimePickerStart.Focus();
				return;
			}

			string connectionString = GetRunTimeSettings().MongoDbConnectionString;
			if( string.IsNullOrEmpty(connectionString)) {
				MessageBox.Show("请设置MongoDB连接字符串参数后，才能搜索日志。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			btnSearchData.Tag = btnSearchData.Text;
			btnSearchData.Text = "正在搜索...";
			btnSearchData.Enabled = false;

			try {
				List<GroupResult> list = await Task.Run(() => SearchLog(start, end, connectionString));
				//List<GroupResult> list = SearchLog(start, end);
				ShowGroupResult(list);
			}
			catch(Exception ex ) {
				MessageBox.Show(ex.Message, this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				RestoreSearchButton();
			}
		}


		private List<GroupResult> SearchLog(DateTime start, DateTime end, string connectionString)
		{
			Stopwatch watch = Stopwatch.StartNew();

			List<GroupResult> list = _logAnalyzer.Search(connectionString, start, end);

			//MessageBox.Show(list.Count.ToString());

			if( txtFilter.Text.Length > 0 ) {
				try {
					list = list.AsQueryable<GroupResult>().Where(txtFilter.Text).ToList();
				}
				catch( Exception ex ) {
					MessageBox.Show("过滤条件无效，" + ex.Message, this.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return null;
				}
				finally {
					watch.Stop();
				}
			}
			else
				watch.Stop();

			// 记录查询时间
			this.LastQueryTime = watch.Elapsed;


			// 保存最近一次的搜索数据，供排序使用
			_lastSearchResult = list;

			return list;
		}

		private void ShowGroupResult(List<GroupResult> list)
		{
			if( list == null )
				return;

			labQueryTime1.Text = _logAnalyzer.LastQueryTime.ToString();
			labQueryTime2.Text = (this.LastQueryTime - _logAnalyzer.LastQueryTime).ToString();

			listGroupSummary.BeginUpdate();
			listGroupSummary.Items.Clear();

			int index = 1;
			foreach( var g in list ) {
				ListViewItem item = new ListViewItem(index++.ToString());
				item.SubItems.Add(g.Url);
				item.SubItems.Add(g.Count.ToString());
				item.SubItems.Add(g.AvgTime.ToString());
				item.Tag = g.List;
				listGroupSummary.Items.Add(item);
			}
			listGroupSummary.EndUpdate();
			RestoreSearchButton();
		}

		private void RestoreSearchButton()
		{
			btnSearchData.Text = btnSearchData.Tag.ToString();
			btnSearchData.Enabled = true;
		}


		private List<PerformanceInfo> GetCurrentGroupData()
		{
			if( listGroupSummary.SelectedItems.Count > 0 ) {
				ListViewItem selectItem = listGroupSummary.SelectedItems[0];
				return selectItem.Tag as List<PerformanceInfo>;
			}
			return null;
		}
		private void listGroupSummary_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<PerformanceInfo> list = GetCurrentGroupData();
			if( list != null )
				ShowGroupDetail(list);
		}

		private void ShowGroupDetail(List<PerformanceInfo> List)
		{
			listGroupDetail.BeginUpdate();
			listGroupDetail.Items.Clear();

			int index = 1;
			foreach( var info in List ) {
				ListViewItem item = new ListViewItem(index++.ToString());
				item.SubItems.Add(info.PerformanceType);
				item.SubItems.Add(info.Time.ToString("yyyy-MM-dd HH:mm:ss"));
				item.SubItems.Add(info.ExecuteTimeString);
				item.Tag = info;
				listGroupDetail.Items.Add(item);
			}

			listGroupDetail.EndUpdate();
			linkResendTo.Visible = false;

			if( listGroupDetail.Items.Count > 0 ) {
				listGroupDetail.Items[0].Selected = true;
				//listGroupDetail.Focus();
			}
		}

		private void listGroupDetail_ItemActivate(object sender, EventArgs e)
		{
			if( listGroupDetail.SelectedItems.Count == 0 )
				return;

			ListViewItem item = listGroupDetail.SelectedItems[0];
			PerformanceInfo info = item.Tag as PerformanceInfo;

			string xml = XmlHelper.XmlSerialize(info, Encoding.UTF8);

			DetailViewerForm form = new DetailViewerForm();
			form.Owner = this.FindForm();
			form.SetText(xml);
			form.Show();

		}

		private void listGroupSummary_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if( e.Column == 2 ) {
				// 按次数排序
				_lastSearchResult = (from x in _lastSearchResult
									 orderby x.Count descending
									 select x
									 ).ToList();

				ShowGroupResult(_lastSearchResult);
			}
			else if( e.Column == 3 ) {
				// 按平均时间排序
				_lastSearchResult = (from x in _lastSearchResult
									 orderby x.AvgTime descending
									 select x
									 ).ToList();

				ShowGroupResult(_lastSearchResult);
			}
		}

		private void listGroupDetail_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if( e.Column == 2 || e.Column == 3 ) {
				List<PerformanceInfo> list = GetCurrentGroupData();
				if( list == null )
					return;


				if( e.Column == 2 )
					list = (from x in list orderby x.Time descending select x).ToList();

				else if( e.Column == 3 )
					list = (from x in list orderby x.ExecuteTime descending select x).ToList();

				ShowGroupDetail(list);
			}
		}

		private void listGroupDetail_SelectedIndexChanged(object sender, EventArgs e)
		{
			if( listGroupDetail.SelectedItems.Count == 0 ) {
				linkResendTo.Visible = false;
				return;
			}

			PerformanceInfo info = (listGroupDetail.SelectedItems[0].Tag as PerformanceInfo);
			linkResendTo.Visible = info.HttpInfo != null;
		}

		private static readonly Regex s_regex = new Regex(@"(Save|Delete|Update|Insert|Change|Edit|Create|Lock|Add|Enable|Disable)", RegexOptions.IgnoreCase | RegexOptions.Compiled);


		private void linkResendTo_Click(object sender, EventArgs e)
		{
			if( linkResendTo.Visible == false )
				return;

			if( listGroupDetail.SelectedItems.Count == 0 )
				return;


			PerformanceInfo info = (listGroupDetail.SelectedItems[0].Tag as PerformanceInfo);
			if( info.HttpInfo != null ) {

				if( string.IsNullOrEmpty(info.HttpInfo.Url)== false
					// 单独排除 LoadData ，避免被正则表达式判断为匹配 adD ，误解为 add
					&& info.HttpInfo.Url.IndexOf("LoadData", StringComparison.OrdinalIgnoreCase) < 0
					&& s_regex.IsMatch(info.HttpInfo.Url)
					) {
					if( MessageBox.Show("当前请求可能会修改数据库，确定要重发请求吗？", this.FindForm().Text,
						 MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
						== DialogResult.No )
						return;
				}

				EventHandler<ReSendEventArgs> eventHandler = this.ReSendButtonClick;
				if( eventHandler != null ) {
					ReSendEventArgs args = new ReSendEventArgs {
						RequestRaw = info.HttpInfo.RequestText.Value.Trim(' ', '\r', '\n')
					};
					eventHandler(linkResendTo, args);
				}
			}
		}


		internal void LinkResendToButtonClick()
		{
			this.linkResendTo_Click(null, null);
		}

		private void LogSearchControl_Resize(object sender, EventArgs e)
		{
			this.columnHeader5.Width = this.Width
										- this.columnHeader4.Width
										- this.columnHeader6.Width
										- this.columnHeader7.Width
										- SystemInformation.VerticalScrollBarWidth * 2;
		}
	}
}
