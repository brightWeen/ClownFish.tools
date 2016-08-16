namespace ClownFish.Log.PerformanceAnalyzer
{
	partial class AutoAnalyzerControl
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numericUpDownMillisecond = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownCount = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
			this.label11 = new System.Windows.Forms.Label();
			this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
			this.label10 = new System.Windows.Forms.Label();
			this.listGroupSummary = new System.Windows.Forms.ListView();
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnExecute = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMillisecond)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numericUpDownMillisecond);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.numericUpDownCount);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.dateTimePickerEnd);
			this.groupBox1.Controls.Add(this.label11);
			this.groupBox1.Controls.Add(this.btnExecute);
			this.groupBox1.Controls.Add(this.dateTimePickerStart);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(772, 79);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "搜索参数";
			// 
			// numericUpDownMillisecond
			// 
			this.numericUpDownMillisecond.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownMillisecond.Location = new System.Drawing.Point(360, 48);
			this.numericUpDownMillisecond.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
			this.numericUpDownMillisecond.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.numericUpDownMillisecond.Name = "numericUpDownMillisecond";
			this.numericUpDownMillisecond.Size = new System.Drawing.Size(77, 21);
			this.numericUpDownMillisecond.TabIndex = 13;
			this.numericUpDownMillisecond.Value = new decimal(new int[] {
            300,
            0,
            0,
            0});
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(297, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(53, 12);
			this.label1.TabIndex = 12;
			this.label1.Text = "超时毫秒";
			// 
			// numericUpDownCount
			// 
			this.numericUpDownCount.Location = new System.Drawing.Point(84, 48);
			this.numericUpDownCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownCount.Name = "numericUpDownCount";
			this.numericUpDownCount.Size = new System.Drawing.Size(77, 21);
			this.numericUpDownCount.TabIndex = 11;
			this.numericUpDownCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(21, 52);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 10;
			this.label13.Text = "执行次数";
			// 
			// dateTimePickerEnd
			// 
			this.dateTimePickerEnd.Location = new System.Drawing.Point(362, 20);
			this.dateTimePickerEnd.Name = "dateTimePickerEnd";
			this.dateTimePickerEnd.Size = new System.Drawing.Size(158, 21);
			this.dateTimePickerEnd.TabIndex = 9;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(297, 24);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(53, 12);
			this.label11.TabIndex = 8;
			this.label11.Text = "结束日期";
			// 
			// dateTimePickerStart
			// 
			this.dateTimePickerStart.Location = new System.Drawing.Point(84, 20);
			this.dateTimePickerStart.Name = "dateTimePickerStart";
			this.dateTimePickerStart.Size = new System.Drawing.Size(158, 21);
			this.dateTimePickerStart.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(21, 24);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(53, 12);
			this.label10.TabIndex = 5;
			this.label10.Text = "开始日期";
			// 
			// listGroupSummary
			// 
			this.listGroupSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7});
			this.listGroupSummary.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listGroupSummary.FullRowSelect = true;
			this.listGroupSummary.HideSelection = false;
			this.listGroupSummary.Location = new System.Drawing.Point(0, 79);
			this.listGroupSummary.MultiSelect = false;
			this.listGroupSummary.Name = "listGroupSummary";
			this.listGroupSummary.Size = new System.Drawing.Size(772, 507);
			this.listGroupSummary.TabIndex = 9;
			this.listGroupSummary.UseCompatibleStateImageBehavior = false;
			this.listGroupSummary.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "#";
			this.columnHeader4.Width = 55;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "URL";
			this.columnHeader5.Width = 498;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "平均时间";
			this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader7.Width = 163;
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(660, 21);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(91, 23);
			this.btnExecute.TabIndex = 7;
			this.btnExecute.Text = "自动分析";
			this.btnExecute.UseVisualStyleBackColor = true;
			// 
			// AutoAnalyzerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.listGroupSummary);
			this.Controls.Add(this.groupBox1);
			this.Name = "AutoAnalyzerControl";
			this.Size = new System.Drawing.Size(772, 586);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownMillisecond)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button btnExecute;
		private System.Windows.Forms.DateTimePicker dateTimePickerStart;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.NumericUpDown numericUpDownCount;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.NumericUpDown numericUpDownMillisecond;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listGroupSummary;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader7;
	}
}
