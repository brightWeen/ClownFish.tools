namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class MainForm
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

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnOpenDirectory = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddFile = new System.Windows.Forms.ToolStripButton();
			this.btnDeleteFile = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnAddCommand = new System.Windows.Forms.ToolStripButton();
			this.btnEditCommand = new System.Windows.Forms.ToolStripButton();
			this.btnDeleteCommnad = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnSaveAll = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnFindCommand = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.btnHelp = new System.Windows.Forms.ToolStripButton();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.labCurrentPath = new System.Windows.Forms.ToolStripStatusLabel();
			this.labMessage = new System.Windows.Forms.ToolStripStatusLabel();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtSQL = new ClownFish.Data.Tools.XmlCommandTool.SyntaxHighlighterControl();
			this.splitter2 = new System.Windows.Forms.Splitter();
			this.txtXML = new ClownFish.Data.Tools.XmlCommandTool.SyntaxHighlighterControl();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuAdd = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuCopyName = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCopyXml = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuGenerateCallCode = new System.Windows.Forms.ToolStripMenuItem();
			this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.toolStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenDirectory,
            this.toolStripSeparator1,
            this.btnAddFile,
            this.btnDeleteFile,
            this.toolStripSeparator2,
            this.btnAddCommand,
            this.btnEditCommand,
            this.btnDeleteCommnad,
            this.toolStripSeparator3,
            this.btnSaveAll,
            this.toolStripSeparator4,
            this.btnFindCommand,
            this.toolStripSeparator5,
            this.btnHelp});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(923, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnOpenDirectory
			// 
			this.btnOpenDirectory.Image = global::ClownFish.Data.Tools.Properties.Resources.openfolderHS;
			this.btnOpenDirectory.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnOpenDirectory.Name = "btnOpenDirectory";
			this.btnOpenDirectory.Size = new System.Drawing.Size(93, 22);
			this.btnOpenDirectory.Text = "打开目录(&D)";
			this.btnOpenDirectory.Click += new System.EventHandler(this.btnOpenDirectory_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// btnAddFile
			// 
			this.btnAddFile.Image = global::ClownFish.Data.Tools.Properties.Resources.NewFolderHS;
			this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddFile.Name = "btnAddFile";
			this.btnAddFile.Size = new System.Drawing.Size(94, 22);
			this.btnAddFile.Text = "新增文件(&N)";
			this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
			// 
			// btnDeleteFile
			// 
			this.btnDeleteFile.Image = global::ClownFish.Data.Tools.Properties.Resources.DeleteFolderHS;
			this.btnDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteFile.Name = "btnDeleteFile";
			this.btnDeleteFile.Size = new System.Drawing.Size(76, 22);
			this.btnDeleteFile.Text = "删除文件";
			this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnAddCommand
			// 
			this.btnAddCommand.Image = global::ClownFish.Data.Tools.Properties.Resources.NewDocumentHS;
			this.btnAddCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAddCommand.Name = "btnAddCommand";
			this.btnAddCommand.Size = new System.Drawing.Size(92, 22);
			this.btnAddCommand.Text = "新增命令(&C)";
			this.btnAddCommand.Click += new System.EventHandler(this.btnAddCommand_Click);
			// 
			// btnEditCommand
			// 
			this.btnEditCommand.Image = ((System.Drawing.Image)(resources.GetObject("btnEditCommand.Image")));
			this.btnEditCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEditCommand.Name = "btnEditCommand";
			this.btnEditCommand.Size = new System.Drawing.Size(91, 22);
			this.btnEditCommand.Text = "修改命令(&E)";
			this.btnEditCommand.Click += new System.EventHandler(this.btnEditCommand_Click);
			// 
			// btnDeleteCommnad
			// 
			this.btnDeleteCommnad.Image = global::ClownFish.Data.Tools.Properties.Resources.DeleteHS;
			this.btnDeleteCommnad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDeleteCommnad.Name = "btnDeleteCommnad";
			this.btnDeleteCommnad.Size = new System.Drawing.Size(76, 22);
			this.btnDeleteCommnad.Text = "删除命令";
			this.btnDeleteCommnad.Click += new System.EventHandler(this.btnDeleteCommnad_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// btnSaveAll
			// 
			this.btnSaveAll.Image = global::ClownFish.Data.Tools.Properties.Resources.SaveAllHS;
			this.btnSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnSaveAll.Name = "btnSaveAll";
			this.btnSaveAll.Size = new System.Drawing.Size(115, 22);
			this.btnSaveAll.Text = "保存所有修改(&S)";
			this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			// 
			// btnFindCommand
			// 
			this.btnFindCommand.Image = global::ClownFish.Data.Tools.Properties.Resources.FindHS;
			this.btnFindCommand.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnFindCommand.Name = "btnFindCommand";
			this.btnFindCommand.Size = new System.Drawing.Size(90, 22);
			this.btnFindCommand.Text = "查找命令(&F)";
			this.btnFindCommand.Click += new System.EventHandler(this.btnFindCommand_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// btnHelp
			// 
			this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnHelp.Image = global::ClownFish.Data.Tools.Properties.Resources.Help;
			this.btnHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnHelp.Name = "btnHelp";
			this.btnHelp.Size = new System.Drawing.Size(23, 22);
			this.btnHelp.Text = "帮助页面";
			this.btnHelp.ToolTipText = "查看帮助页面";
			this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labCurrentPath,
            this.labMessage});
			this.statusStrip1.Location = new System.Drawing.Point(0, 475);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(923, 26);
			this.statusStrip1.TabIndex = 1;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// labCurrentPath
			// 
			this.labCurrentPath.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
			this.labCurrentPath.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
			this.labCurrentPath.ForeColor = System.Drawing.Color.Tomato;
			this.labCurrentPath.IsLink = true;
			this.labCurrentPath.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.labCurrentPath.LinkColor = System.Drawing.Color.Tomato;
			this.labCurrentPath.Name = "labCurrentPath";
			this.labCurrentPath.Size = new System.Drawing.Size(98, 21);
			this.labCurrentPath.Text = "labCurrentPath";
			this.labCurrentPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labCurrentPath.Click += new System.EventHandler(this.labCurrentPath_Click);
			// 
			// labMessage
			// 
			this.labMessage.Name = "labMessage";
			this.labMessage.Size = new System.Drawing.Size(810, 21);
			this.labMessage.Spring = true;
			this.labMessage.Text = "Ready.";
			this.labMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 25);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.Size = new System.Drawing.Size(227, 450);
			this.treeView1.TabIndex = 2;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
			this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(227, 25);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(7, 450);
			this.splitter1.TabIndex = 3;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.txtSQL);
			this.panel1.Controls.Add(this.splitter2);
			this.panel1.Controls.Add(this.txtXML);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(234, 25);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(689, 450);
			this.panel1.TabIndex = 4;
			// 
			// txtSQL
			// 
			this.txtSQL.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSQL.Location = new System.Drawing.Point(0, 0);
			this.txtSQL.Name = "txtSQL";
			this.txtSQL.Size = new System.Drawing.Size(689, 190);
			this.txtSQL.TabIndex = 2;
			// 
			// splitter2
			// 
			this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter2.Location = new System.Drawing.Point(0, 190);
			this.splitter2.Name = "splitter2";
			this.splitter2.Size = new System.Drawing.Size(689, 7);
			this.splitter2.TabIndex = 1;
			this.splitter2.TabStop = false;
			// 
			// txtXML
			// 
			this.txtXML.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtXML.Language = "xml";
			this.txtXML.Location = new System.Drawing.Point(0, 197);
			this.txtXML.Name = "txtXML";
			this.txtXML.Size = new System.Drawing.Size(689, 253);
			this.txtXML.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAdd,
            this.menuEdit,
            this.menuDelete,
            this.menuPaste,
            this.toolStripMenuItem1,
            this.menuCopyName,
            this.menuCopyXml,
            this.toolStripMenuItem2,
            this.menuGenerateCallCode});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 170);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// menuAdd
			// 
			this.menuAdd.Image = global::ClownFish.Data.Tools.Properties.Resources.NewDocumentHS;
			this.menuAdd.Name = "menuAdd";
			this.menuAdd.Size = new System.Drawing.Size(180, 22);
			this.menuAdd.Text = "新增命令";
			this.menuAdd.Click += new System.EventHandler(this.btnAddCommand_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.Image = global::ClownFish.Data.Tools.Properties.Resources.EditTableHS;
			this.menuEdit.Name = "menuEdit";
			this.menuEdit.Size = new System.Drawing.Size(180, 22);
			this.menuEdit.Text = "修改命令";
			this.menuEdit.Click += new System.EventHandler(this.btnEditCommand_Click);
			// 
			// menuDelete
			// 
			this.menuDelete.Image = global::ClownFish.Data.Tools.Properties.Resources.DeleteHS;
			this.menuDelete.Name = "menuDelete";
			this.menuDelete.Size = new System.Drawing.Size(180, 22);
			this.menuDelete.Text = "删除命令";
			this.menuDelete.Click += new System.EventHandler(this.btnDeleteCommnad_Click);
			// 
			// menuPaste
			// 
			this.menuPaste.Image = global::ClownFish.Data.Tools.Properties.Resources.PasteHS;
			this.menuPaste.Name = "menuPaste";
			this.menuPaste.Size = new System.Drawing.Size(180, 22);
			this.menuPaste.Text = "粘贴命令";
			this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
			// 
			// menuCopyName
			// 
			this.menuCopyName.Image = global::ClownFish.Data.Tools.Properties.Resources.CopyHS;
			this.menuCopyName.Name = "menuCopyName";
			this.menuCopyName.Size = new System.Drawing.Size(180, 22);
			this.menuCopyName.Text = "复制名称   Ctrl-C";
			this.menuCopyName.Click += new System.EventHandler(this.复制名称ToolStripMenuItem_Click);
			// 
			// menuCopyXml
			// 
			this.menuCopyXml.Name = "menuCopyXml";
			this.menuCopyXml.Size = new System.Drawing.Size(180, 22);
			this.menuCopyXml.Text = "复制节点XML";
			this.menuCopyXml.Click += new System.EventHandler(this.复制节点XMLToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
			// 
			// menuGenerateCallCode
			// 
			this.menuGenerateCallCode.Image = global::ClownFish.Data.Tools.Properties.Resources.cs;
			this.menuGenerateCallCode.Name = "menuGenerateCallCode";
			this.menuGenerateCallCode.Size = new System.Drawing.Size(180, 22);
			this.menuGenerateCallCode.Text = "生成调用代码   F12";
			this.menuGenerateCallCode.Click += new System.EventHandler(this.menuGenerateCallCode_Click);
			// 
			// fileSystemWatcher1
			// 
			this.fileSystemWatcher1.EnableRaisingEvents = true;
			this.fileSystemWatcher1.SynchronizingObject = this;
			this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(923, 501);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.toolStrip1);
			this.MinimumSize = new System.Drawing.Size(700, 400);
			this.Name = "MainForm";
			this.Text = "CXmlCommandTool";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private XmlCommandTool.SyntaxHighlighterControl txtSQL;
		private System.Windows.Forms.Splitter splitter2;
		private XmlCommandTool.SyntaxHighlighterControl txtXML;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripButton btnOpenDirectory;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnAddFile;
		private System.Windows.Forms.ToolStripStatusLabel labMessage;
		private System.Windows.Forms.ToolStripButton btnDeleteFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton btnAddCommand;
		private System.Windows.Forms.ToolStripButton btnEditCommand;
		private System.Windows.Forms.ToolStripButton btnDeleteCommnad;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton btnSaveAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripButton btnFindCommand;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnHelp;
		private System.Windows.Forms.ToolStripStatusLabel labCurrentPath;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuAdd;
		private System.Windows.Forms.ToolStripMenuItem menuEdit;
		private System.Windows.Forms.ToolStripMenuItem menuDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuCopyName;
		private System.Windows.Forms.ToolStripMenuItem menuCopyXml;
		private System.Windows.Forms.ToolStripMenuItem menuPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem menuGenerateCallCode;
		private System.IO.FileSystemWatcher fileSystemWatcher1;
		private System.Windows.Forms.Timer timer1;
	}
}

