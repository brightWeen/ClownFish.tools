namespace ClownFish.FiddlerPulgin
{
	partial class NotReasonableControl
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnImport = new System.Windows.Forms.ToolStripButton();
			this.btnOutput = new System.Windows.Forms.ToolStripButton();
			this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnClear = new System.Windows.Forms.ToolStripButton();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.chkEnabled = new System.Windows.Forms.CheckBox();
			this.listView1 = new ClownFish.FiddlerPulgin.DoubleBufferListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImport,
            this.btnOutput,
            this.btnSaveAs,
            this.toolStripSeparator1,
            this.btnClear});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(574, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnImport
			// 
			this.btnImport.Image = global::ClownFish.FiddlerPulgin.Properties.Resources.input;
			this.btnImport.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(52, 22);
			this.btnImport.Text = "导入";
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnOutput
			// 
			this.btnOutput.Image = global::ClownFish.FiddlerPulgin.Properties.Resources.output2;
			this.btnOutput.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOutput.Name = "btnOutput";
			this.btnOutput.Size = new System.Drawing.Size(52, 22);
			this.btnOutput.Text = "导出";
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			// 
			// btnSaveAs
			// 
			this.btnSaveAs.Image = global::ClownFish.FiddlerPulgin.Properties.Resources.page2;
			this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveAs.Name = "btnSaveAs";
			this.btnSaveAs.Size = new System.Drawing.Size(64, 22);
			this.btnSaveAs.Text = "另存为";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnClear
			// 
			this.btnClear.Image = global::ClownFish.FiddlerPulgin.Properties.Resources.clean;
			this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(76, 22);
			this.btnClear.Text = "清空列表";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox1.Location = new System.Drawing.Point(0, 313);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBox1.Size = new System.Drawing.Size(574, 149);
			this.textBox1.TabIndex = 5;
			this.textBox1.WordWrap = false;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 307);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(574, 6);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// chkEnabled
			// 
			this.chkEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.chkEnabled.AutoSize = true;
			this.chkEnabled.Location = new System.Drawing.Point(427, 5);
			this.chkEnabled.Name = "chkEnabled";
			this.chkEnabled.Size = new System.Drawing.Size(132, 16);
			this.chkEnabled.TabIndex = 8;
			this.chkEnabled.Text = "启用不规范请求分析";
			this.chkEnabled.UseVisualStyleBackColor = true;
			this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 25);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(574, 282);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 7;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "#";
			this.columnHeader1.Width = 55;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Reason";
			this.columnHeader2.Width = 161;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "URL";
			this.columnHeader3.Width = 195;
			// 
			// NotReasonableControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkEnabled);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "NotReasonableControl";
			this.Size = new System.Drawing.Size(574, 462);
			this.Resize += new System.EventHandler(this.NotReasonableControl_Resize);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnImport;
		private System.Windows.Forms.ToolStripButton btnOutput;
		private System.Windows.Forms.ToolStripButton btnSaveAs;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnClear;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Splitter splitter1;
		private DoubleBufferListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.CheckBox chkEnabled;
		
	}
}
