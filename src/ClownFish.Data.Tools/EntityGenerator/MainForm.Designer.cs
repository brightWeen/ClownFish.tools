namespace ClownFish.Data.Tools.EntityGenerator
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
			this.cboConnectionString = new System.Windows.Forms.ComboBox();
			this.btnConnect = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtSqlScript = new ClownFish.Data.Tools.XmlCommandTool.SyntaxHighlighterControl();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.txtCsCode = new ClownFish.Data.Tools.XmlCommandTool.SyntaxHighlighterControl();
			this.panel5 = new System.Windows.Forms.Panel();
			this.ucParameterStyle1 = new ClownFish.Data.Tools.EntityGenerator.ucParameterStyle();
			this.ucCsClassStyle1 = new ClownFish.Data.Tools.EntityGenerator.UcCsClassStyle();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel3 = new System.Windows.Forms.Panel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.panel4 = new System.Windows.Forms.Panel();
			this.contextMenuStrip5 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.显示隐藏代码窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label2 = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuCopySpName = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuGetXmlCommandBySP = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuCopyTableName = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.生成增删改命令到剪切板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuCopyDbName = new System.Windows.Forms.ToolStripMenuItem();
			this.名称ToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
			this.根据查询生成数据实体类ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.定位到指定对象ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip4 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuCopyViewName = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.contextMenuStrip5.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.contextMenuStrip3.SuspendLayout();
			this.contextMenuStrip4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cboConnectionString);
			this.panel1.Controls.Add(this.btnConnect);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(911, 36);
			this.panel1.TabIndex = 0;
			// 
			// cboConnectionString
			// 
			this.cboConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboConnectionString.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cboConnectionString.FormattingEnabled = true;
			this.cboConnectionString.Location = new System.Drawing.Point(77, 7);
			this.cboConnectionString.Name = "cboConnectionString";
			this.cboConnectionString.Size = new System.Drawing.Size(714, 23);
			this.cboConnectionString.TabIndex = 2;
			// 
			// btnConnect
			// 
			this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnConnect.Location = new System.Drawing.Point(808, 8);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(94, 21);
			this.btnConnect.TabIndex = 0;
			this.btnConnect.Text = "连接数据库(&C)";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "连接字符串";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.txtSqlScript);
			this.panel2.Controls.Add(this.splitter2);
			this.panel2.Controls.Add(this.txtCsCode);
			this.panel2.Controls.Add(this.panel5);
			this.panel2.Controls.Add(this.splitter1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 36);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(911, 545);
			this.panel2.TabIndex = 1;
			// 
			// txtSqlScript
			// 
			this.txtSqlScript.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSqlScript.Location = new System.Drawing.Point(225, 401);
			this.txtSqlScript.Name = "txtSqlScript";
			this.txtSqlScript.Size = new System.Drawing.Size(686, 144);
			this.txtSqlScript.TabIndex = 6;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter2.Location = new System.Drawing.Point(225, 394);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(686, 7);
			this.splitter2.TabIndex = 4;
			this.splitter2.TabStop = false;
			// 
			// txtCsCode
			// 
			this.txtCsCode.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtCsCode.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCsCode.Language = "cs";
			this.txtCsCode.Location = new System.Drawing.Point(225, 26);
			this.txtCsCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.txtCsCode.Name = "txtCsCode";
			this.txtCsCode.ReadOnly = false;
			this.txtCsCode.Size = new System.Drawing.Size(686, 368);
			this.txtCsCode.TabIndex = 5;
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.ucParameterStyle1);
			this.panel5.Controls.Add(this.ucCsClassStyle1);
			this.panel5.Controls.Add(this.linkLabel1);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel5.Location = new System.Drawing.Point(225, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(686, 26);
			this.panel5.TabIndex = 2;
			// 
			// ucParameterStyle1
			// 
			this.ucParameterStyle1.Location = new System.Drawing.Point(65, 0);
			this.ucParameterStyle1.Name = "ucParameterStyle1";
			this.ucParameterStyle1.Size = new System.Drawing.Size(397, 25);
			this.ucParameterStyle1.TabIndex = 9;
			this.ucParameterStyle1.Visible = false;
			this.ucParameterStyle1.OptionChanged += new System.EventHandler(this.ucCsClassStyle1_OptionChanged);
			// 
			// ucCsClassStyle1
			// 
			this.ucCsClassStyle1.Location = new System.Drawing.Point(3, 0);
			this.ucCsClassStyle1.Name = "ucCsClassStyle1";
			this.ucCsClassStyle1.Size = new System.Drawing.Size(502, 25);
			this.ucCsClassStyle1.TabIndex = 8;
			this.ucCsClassStyle1.Visible = false;
			this.ucCsClassStyle1.OptionChanged += new System.EventHandler(this.ucCsClassStyle1_OptionChanged);
			// 
			// linkLabel1
			// 
			this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabel1.Image = global::ClownFish.Data.Tools.Properties.Resources.Help;
			this.linkLabel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.linkLabel1.Location = new System.Drawing.Point(587, 4);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(96, 17);
			this.linkLabel1.TabIndex = 7;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "查看帮助页面";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(219, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(6, 545);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.treeView1);
			this.panel3.Controls.Add(this.panel4);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(219, 545);
			this.panel3.TabIndex = 0;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.HideSelection = false;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 26);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.Size = new System.Drawing.Size(219, 519);
			this.treeView1.TabIndex = 1;
			this.treeView1.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCollapse);
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			this.treeView1.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterExpand);
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// panel4
			// 
			this.panel4.ContextMenuStrip = this.contextMenuStrip5;
			this.panel4.Controls.Add(this.label2);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(219, 26);
			this.panel4.TabIndex = 0;
			// 
			// contextMenuStrip5
			// 
			this.contextMenuStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示隐藏代码窗口ToolStripMenuItem});
			this.contextMenuStrip5.Name = "contextMenuStrip5";
			this.contextMenuStrip5.Size = new System.Drawing.Size(153, 26);
			// 
			// 显示隐藏代码窗口ToolStripMenuItem
			// 
			this.显示隐藏代码窗口ToolStripMenuItem.Name = "显示隐藏代码窗口ToolStripMenuItem";
			this.显示隐藏代码窗口ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.显示隐藏代码窗口ToolStripMenuItem.Text = "隐藏 代码窗口";
			this.显示隐藏代码窗口ToolStripMenuItem.Click += new System.EventHandler(this.显示隐藏代码窗口ToolStripMenuItem_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 12);
			this.label2.TabIndex = 0;
			this.label2.Text = "数据表列表(&D)";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopySpName,
            this.toolStripMenuItem1,
            this.menuGetXmlCommandBySP});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(231, 54);
			// 
			// menuCopySpName
			// 
			this.menuCopySpName.Name = "menuCopySpName";
			this.menuCopySpName.Size = new System.Drawing.Size(230, 22);
			this.menuCopySpName.Text = "复制名称";
			this.menuCopySpName.Click += new System.EventHandler(this.menuCopySpName_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(227, 6);
			// 
			// menuGetXmlCommandBySP
			// 
			this.menuGetXmlCommandBySP.Name = "menuGetXmlCommandBySP";
			this.menuGetXmlCommandBySP.Size = new System.Drawing.Size(230, 22);
			this.menuGetXmlCommandBySP.Text = "生成XmlCommand到剪切板";
			this.menuGetXmlCommandBySP.Click += new System.EventHandler(this.menuGetXmlCommandBySP_Click);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyTableName,
            this.toolStripMenuItem2,
            this.生成增删改命令到剪切板ToolStripMenuItem});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(267, 54);
			// 
			// menuCopyTableName
			// 
			this.menuCopyTableName.Name = "menuCopyTableName";
			this.menuCopyTableName.Size = new System.Drawing.Size(266, 22);
			this.menuCopyTableName.Text = "复制名称";
			this.menuCopyTableName.Click += new System.EventHandler(this.menuCopySpName_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(263, 6);
			// 
			// 生成增删改命令到剪切板ToolStripMenuItem
			// 
			this.生成增删改命令到剪切板ToolStripMenuItem.Name = "生成增删改命令到剪切板ToolStripMenuItem";
			this.生成增删改命令到剪切板ToolStripMenuItem.Size = new System.Drawing.Size(266, 22);
			this.生成增删改命令到剪切板ToolStripMenuItem.Text = "生成增删改XmlCommand到剪切板";
			this.生成增删改命令到剪切板ToolStripMenuItem.Click += new System.EventHandler(this.生成增删改命令到剪切板ToolStripMenuItem_Click);
			// 
			// contextMenuStrip3
			// 
			this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyDbName,
            this.名称ToolStripMenuItem,
            this.根据查询生成数据实体类ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.定位到指定对象ToolStripMenuItem});
			this.contextMenuStrip3.Name = "contextMenuStrip3";
			this.contextMenuStrip3.Size = new System.Drawing.Size(209, 82);
			// 
			// menuCopyDbName
			// 
			this.menuCopyDbName.Name = "menuCopyDbName";
			this.menuCopyDbName.Size = new System.Drawing.Size(208, 22);
			this.menuCopyDbName.Text = "复制名称";
			this.menuCopyDbName.Click += new System.EventHandler(this.menuCopySpName_Click);
			// 
			// 名称ToolStripMenuItem
			// 
			this.名称ToolStripMenuItem.Name = "名称ToolStripMenuItem";
			this.名称ToolStripMenuItem.Size = new System.Drawing.Size(205, 6);
			// 
			// 根据查询生成数据实体类ToolStripMenuItem
			// 
			this.根据查询生成数据实体类ToolStripMenuItem.Name = "根据查询生成数据实体类ToolStripMenuItem";
			this.根据查询生成数据实体类ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.根据查询生成数据实体类ToolStripMenuItem.Text = "根据查询生成数据实体类";
			this.根据查询生成数据实体类ToolStripMenuItem.Click += new System.EventHandler(this.根据查询生成数据实体类ToolStripMenuItem_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(205, 6);
			// 
			// 定位到指定对象ToolStripMenuItem
			// 
			this.定位到指定对象ToolStripMenuItem.Name = "定位到指定对象ToolStripMenuItem";
			this.定位到指定对象ToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
			this.定位到指定对象ToolStripMenuItem.Text = "定位到指定对象";
			this.定位到指定对象ToolStripMenuItem.Click += new System.EventHandler(this.定位到指定对象ToolStripMenuItem_Click);
			// 
			// contextMenuStrip4
			// 
			this.contextMenuStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCopyViewName});
			this.contextMenuStrip4.Name = "contextMenuStrip4";
			this.contextMenuStrip4.Size = new System.Drawing.Size(125, 26);
			// 
			// menuCopyViewName
			// 
			this.menuCopyViewName.Name = "menuCopyViewName";
			this.menuCopyViewName.Size = new System.Drawing.Size(124, 22);
			this.menuCopyViewName.Text = "复制名称";
			this.menuCopyViewName.Click += new System.EventHandler(this.menuCopySpName_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(911, 581);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.MinimumSize = new System.Drawing.Size(700, 400);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "CodeGenerator for SQLSERVER";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.contextMenuStrip5.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.contextMenuStrip3.ResumeLayout(false);
			this.contextMenuStrip4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ComboBox cboConnectionString;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuGetXmlCommandBySP;
		private XmlCommandTool.SyntaxHighlighterControl txtCsCode;
		private System.Windows.Forms.Splitter splitter2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem 生成增删改命令到剪切板ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
		private System.Windows.Forms.ToolStripMenuItem 根据查询生成数据实体类ToolStripMenuItem;
		private ClownFish.Data.Tools.EntityGenerator.UcCsClassStyle ucCsClassStyle1;
		private System.Windows.Forms.ToolStripMenuItem menuCopySpName;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuCopyTableName;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip4;
		private System.Windows.Forms.ToolStripMenuItem menuCopyViewName;
		private System.Windows.Forms.ToolStripMenuItem menuCopyDbName;
		private System.Windows.Forms.ToolStripSeparator 名称ToolStripMenuItem;
		private ucParameterStyle ucParameterStyle1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem 定位到指定对象ToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip5;
		private System.Windows.Forms.ToolStripMenuItem 显示隐藏代码窗口ToolStripMenuItem;
		private XmlCommandTool.SyntaxHighlighterControl txtSqlScript;
	}
}

