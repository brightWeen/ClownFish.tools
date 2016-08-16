namespace ClownFish.PreheatWebSite
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if( disposing && (components != null) ) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.linkOpenFile = new System.Windows.Forms.LinkLabel();
			this.btnRun = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtScript = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.txtExecuteResult = new System.Windows.Forms.TextBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.panel1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.linkOpenFile);
			this.panel1.Controls.Add(this.btnRun);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(846, 43);
			this.panel1.TabIndex = 0;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 10;
			this.label3.Text = "脚本文件";
			// 
			// linkOpenFile
			// 
			this.linkOpenFile.AutoSize = true;
			this.linkOpenFile.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.linkOpenFile.Location = new System.Drawing.Point(90, 16);
			this.linkOpenFile.Name = "linkOpenFile";
			this.linkOpenFile.Size = new System.Drawing.Size(173, 12);
			this.linkOpenFile.TabIndex = 4;
			this.linkOpenFile.TabStop = true;
			this.linkOpenFile.Text = "请选择站点预热脚本文件......";
			this.toolTip1.SetToolTip(this.linkOpenFile, "点击链接可选择预热脚本文件");
			this.linkOpenFile.Click += new System.EventHandler(this.linkOpenFile_Click);
			// 
			// btnRun
			// 
			this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRun.Location = new System.Drawing.Point(714, 16);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(120, 23);
			this.btnRun.TabIndex = 3;
			this.btnRun.Text = "执行预热脚本(&R)";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labMessage,
            this.progressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 638);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(846, 22);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labMessage
			// 
			this.labMessage.Name = "labMessage";
			this.labMessage.Size = new System.Drawing.Size(629, 17);
			this.labMessage.Spring = true;
			this.labMessage.Text = "Ready.";
			this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// progressBar
			// 
			this.progressBar.BackColor = System.Drawing.SystemColors.Window;
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(200, 16);
			this.progressBar.Step = 1;
			// 
			// backgroundWorker1
			// 
			this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
			this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 43);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(846, 595);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtScript);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(838, 569);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "脚本内容";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtScript
			// 
			this.txtScript.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtScript.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtScript.Location = new System.Drawing.Point(3, 3);
			this.txtScript.Multiline = true;
			this.txtScript.Name = "txtScript";
			this.txtScript.ReadOnly = true;
			this.txtScript.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtScript.Size = new System.Drawing.Size(832, 563);
			this.txtScript.TabIndex = 3;
			this.txtScript.WordWrap = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.listView1);
			this.tabPage2.Controls.Add(this.splitter1);
			this.tabPage2.Controls.Add(this.txtExecuteResult);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(838, 524);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "请求列表";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(3, 3);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(832, 311);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 2;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "请求地址";
			this.columnHeader1.Width = 643;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "执行时间";
			this.columnHeader2.Width = 140;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(3, 314);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(832, 6);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// txtExecuteResult
			// 
			this.txtExecuteResult.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtExecuteResult.Location = new System.Drawing.Point(3, 320);
			this.txtExecuteResult.Multiline = true;
			this.txtExecuteResult.Name = "txtExecuteResult";
			this.txtExecuteResult.ReadOnly = true;
			this.txtExecuteResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtExecuteResult.Size = new System.Drawing.Size(832, 201);
			this.txtExecuteResult.TabIndex = 0;
			this.txtExecuteResult.WordWrap = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(846, 660);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.panel1);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "站点预热工具";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.LinkLabel linkOpenFile;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel labMessage;
		private System.Windows.Forms.ToolStripProgressBar progressBar;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox txtScript;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox txtExecuteResult;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ToolTip toolTip1;
	}
}