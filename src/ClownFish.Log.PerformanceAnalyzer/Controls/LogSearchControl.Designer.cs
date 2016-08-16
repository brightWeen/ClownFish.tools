namespace ClownFish.Log.PerformanceAnalyzer
{
	partial class LogSearchControl
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.listGroupSummary = new System.Windows.Forms.ListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2 = new System.Windows.Forms.Panel();
			this.listGroupDetail = new System.Windows.Forms.ListView();
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel1 = new System.Windows.Forms.Panel();
			this.linkResendTo = new System.Windows.Forms.LinkLabel();
			this.label12 = new System.Windows.Forms.Label();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.labQueryTime2 = new System.Windows.Forms.Label();
			this.labQueryTime1 = new System.Windows.Forms.Label();
			this.txtFilter = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
			this.label11 = new System.Windows.Forms.Label();
			this.btnSearchData = new System.Windows.Forms.Button();
			this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// listGroupSummary
			// 
			this.listGroupSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
			this.listGroupSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listGroupSummary.FullRowSelect = true;
			this.listGroupSummary.HideSelection = false;
			this.listGroupSummary.Location = new System.Drawing.Point(0, 78);
			this.listGroupSummary.MultiSelect = false;
			this.listGroupSummary.Name = "listGroupSummary";
			this.listGroupSummary.Size = new System.Drawing.Size(761, 218);
			this.listGroupSummary.TabIndex = 8;
			this.listGroupSummary.UseCompatibleStateImageBehavior = false;
			this.listGroupSummary.View = System.Windows.Forms.View.Details;
			this.listGroupSummary.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listGroupSummary_ColumnClick);
			this.listGroupSummary.SelectedIndexChanged += new System.EventHandler(this.listGroupSummary_SelectedIndexChanged);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "#";
			this.columnHeader4.Width = 55;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "URL";
			this.columnHeader5.Width = 411;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "次数";
			this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader6.Width = 76;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "平均时间";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader7.Width = 173;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 296);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(761, 6);
			this.splitter1.TabIndex = 7;
			this.splitter1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.listGroupDetail);
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 302);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(761, 252);
			this.panel2.TabIndex = 6;
			// 
			// listGroupDetail
			// 
			this.listGroupDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
			this.listGroupDetail.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listGroupDetail.FullRowSelect = true;
			this.listGroupDetail.HideSelection = false;
			this.listGroupDetail.Location = new System.Drawing.Point(0, 28);
			this.listGroupDetail.MultiSelect = false;
			this.listGroupDetail.Name = "listGroupDetail";
			this.listGroupDetail.Size = new System.Drawing.Size(761, 224);
			this.listGroupDetail.TabIndex = 4;
			this.listGroupDetail.UseCompatibleStateImageBehavior = false;
			this.listGroupDetail.View = System.Windows.Forms.View.Details;
			this.listGroupDetail.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listGroupDetail_ColumnClick);
			this.listGroupDetail.ItemActivate += new System.EventHandler(this.listGroupDetail_ItemActivate);
			this.listGroupDetail.SelectedIndexChanged += new System.EventHandler(this.listGroupDetail_SelectedIndexChanged);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "#";
			this.columnHeader8.Width = 43;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "类别";
			this.columnHeader9.Width = 77;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "发生时间";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader10.Width = 250;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "执行时间";
			this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader11.Width = 218;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.linkResendTo);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(761, 28);
			this.panel1.TabIndex = 3;
			// 
			// linkResendTo
			// 
			this.linkResendTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkResendTo.AutoSize = true;
			this.linkResendTo.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkResendTo.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.linkResendTo.Location = new System.Drawing.Point(645, 7);
			this.linkResendTo.Name = "linkResendTo";
			this.linkResendTo.Size = new System.Drawing.Size(77, 12);
			this.linkResendTo.TabIndex = 4;
			this.linkResendTo.TabStop = true;
			this.linkResendTo.Text = "重发请求(F4)";
			this.linkResendTo.Visible = false;
			this.linkResendTo.Click += new System.EventHandler(this.linkResendTo_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(3, 7);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(209, 12);
			this.label12.TabIndex = 3;
			this.label12.Text = "分组的详细记录（点击行可重发请求）";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.labQueryTime2);
			this.groupBox3.Controls.Add(this.labQueryTime1);
			this.groupBox3.Controls.Add(this.txtFilter);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.dateTimePickerEnd);
			this.groupBox3.Controls.Add(this.label11);
			this.groupBox3.Controls.Add(this.btnSearchData);
			this.groupBox3.Controls.Add(this.dateTimePickerStart);
			this.groupBox3.Controls.Add(this.label10);
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(761, 78);
			this.groupBox3.TabIndex = 5;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "筛选范围";
			// 
			// labQueryTime2
			// 
			this.labQueryTime2.AutoSize = true;
			this.labQueryTime2.Location = new System.Drawing.Point(518, 28);
			this.labQueryTime2.Name = "labQueryTime2";
			this.labQueryTime2.Size = new System.Drawing.Size(47, 12);
			this.labQueryTime2.TabIndex = 8;
			this.labQueryTime2.Text = ".......";
			// 
			// labQueryTime1
			// 
			this.labQueryTime1.AutoSize = true;
			this.labQueryTime1.Location = new System.Drawing.Point(518, 12);
			this.labQueryTime1.Name = "labQueryTime1";
			this.labQueryTime1.Size = new System.Drawing.Size(47, 12);
			this.labQueryTime1.TabIndex = 7;
			this.labQueryTime1.Text = ".......";
			// 
			// txtFilter
			// 
			this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtFilter.Location = new System.Drawing.Point(75, 47);
			this.txtFilter.Name = "txtFilter";
			this.txtFilter.Size = new System.Drawing.Size(663, 21);
			this.txtFilter.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 5;
			this.label1.Text = "过滤条件";
			// 
			// dateTimePickerEnd
			// 
			this.dateTimePickerEnd.Location = new System.Drawing.Point(329, 18);
			this.dateTimePickerEnd.Name = "dateTimePickerEnd";
			this.dateTimePickerEnd.Size = new System.Drawing.Size(158, 21);
			this.dateTimePickerEnd.TabIndex = 4;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(264, 22);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 12);
			this.label11.TabIndex = 3;
			this.label11.Text = "结束日期";
			// 
			// btnSearchData
			// 
			this.btnSearchData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSearchData.Location = new System.Drawing.Point(647, 18);
			this.btnSearchData.Name = "btnSearchData";
			this.btnSearchData.Size = new System.Drawing.Size(91, 23);
			this.btnSearchData.TabIndex = 2;
			this.btnSearchData.Text = "搜索数据";
			this.btnSearchData.UseVisualStyleBackColor = true;
			this.btnSearchData.Click += new System.EventHandler(this.btnSearchData_Click);
			// 
			// dateTimePickerStart
			// 
			this.dateTimePickerStart.Location = new System.Drawing.Point(75, 18);
			this.dateTimePickerStart.Name = "dateTimePickerStart";
			this.dateTimePickerStart.Size = new System.Drawing.Size(158, 21);
			this.dateTimePickerStart.TabIndex = 1;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(12, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 0;
			this.label10.Text = "开始日期";
			// 
			// LogSearchControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listGroupSummary);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.groupBox3);
			this.Name = "LogSearchControl";
			this.Size = new System.Drawing.Size(761, 554);
			this.Resize += new System.EventHandler(this.LogSearchControl_Resize);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel linkResendTo;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnSearchData;
		private System.Windows.Forms.DateTimePicker dateTimePickerStart;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ListView listGroupDetail;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ListView listGroupSummary;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.TextBox txtFilter;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label labQueryTime1;
		private System.Windows.Forms.Label labQueryTime2;
	}
}
