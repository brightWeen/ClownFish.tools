namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class SyntaxHighlighterControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuUndo = new System.Windows.Forms.ToolStripMenuItem();
			this.menuRedo = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.menuCut = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.menuPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.menuFind = new System.Windows.Forms.ToolStripMenuItem();
			this.menuCopyAll = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textEditorControl1
			// 
			this.textEditorControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.textEditorControl1.ContextMenuStrip = this.contextMenuStrip1;
			this.textEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textEditorControl1.IsReadOnly = false;
			this.textEditorControl1.Location = new System.Drawing.Point(0, 0);
			this.textEditorControl1.Name = "textEditorControl1";
			this.textEditorControl1.ShowLineNumbers = false;
			this.textEditorControl1.ShowVRuler = false;
			this.textEditorControl1.Size = new System.Drawing.Size(409, 217);
			this.textEditorControl1.TabIndex = 0;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUndo,
            this.menuRedo,
            this.toolStripMenuItem1,
            this.menuCut,
            this.menuCopy,
            this.menuPaste,
            this.menuDelete,
            this.toolStripMenuItem2,
            this.menuSelectAll,
            this.menuCopyAll,
            this.toolStripMenuItem3,
            this.menuFind});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(195, 242);
			this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
			// 
			// menuUndo
			// 
			this.menuUndo.Name = "menuUndo";
			this.menuUndo.Size = new System.Drawing.Size(194, 22);
			this.menuUndo.Text = "撤消";
			this.menuUndo.Click += new System.EventHandler(this.menuUndo_Click);
			// 
			// menuRedo
			// 
			this.menuRedo.Name = "menuRedo";
			this.menuRedo.Size = new System.Drawing.Size(194, 22);
			this.menuRedo.Text = "重做";
			this.menuRedo.Click += new System.EventHandler(this.menuRedo_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
			// 
			// menuCut
			// 
			this.menuCut.Name = "menuCut";
			this.menuCut.Size = new System.Drawing.Size(194, 22);
			this.menuCut.Text = "剪切";
			this.menuCut.Click += new System.EventHandler(this.menuCut_Click);
			// 
			// menuCopy
			// 
			this.menuCopy.Name = "menuCopy";
			this.menuCopy.Size = new System.Drawing.Size(194, 22);
			this.menuCopy.Text = "复制";
			this.menuCopy.Click += new System.EventHandler(this.menuCopy_Click);
			// 
			// menuPaste
			// 
			this.menuPaste.Name = "menuPaste";
			this.menuPaste.Size = new System.Drawing.Size(194, 22);
			this.menuPaste.Text = "粘贴";
			this.menuPaste.Click += new System.EventHandler(this.menuPaste_Click);
			// 
			// menuDelete
			// 
			this.menuDelete.Name = "menuDelete";
			this.menuDelete.Size = new System.Drawing.Size(194, 22);
			this.menuDelete.Text = "删除";
			this.menuDelete.Click += new System.EventHandler(this.menuDelete_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(191, 6);
			// 
			// menuSelectAll
			// 
			this.menuSelectAll.Name = "menuSelectAll";
			this.menuSelectAll.Size = new System.Drawing.Size(194, 22);
			this.menuSelectAll.Text = "全选";
			this.menuSelectAll.Click += new System.EventHandler(this.menuSelectAll_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(191, 6);
			// 
			// menuFind
			// 
			this.menuFind.Name = "menuFind";
			this.menuFind.Size = new System.Drawing.Size(194, 22);
			this.menuFind.Text = "查找 ...";
			this.menuFind.Click += new System.EventHandler(this.menuFind_Click);
			// 
			// menuCopyAll
			// 
			this.menuCopyAll.Name = "menuCopyAll";
			this.menuCopyAll.Size = new System.Drawing.Size(194, 22);
			this.menuCopyAll.Text = "复制全部文本到剪切板";
			this.menuCopyAll.Click += new System.EventHandler(this.menuCopyAll_Click);
			// 
			// SyntaxHighlighterControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.textEditorControl1);
			this.Name = "SyntaxHighlighterControl";
			this.Size = new System.Drawing.Size(409, 217);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem menuUndo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem menuCut;
		private System.Windows.Forms.ToolStripMenuItem menuCopy;
		private System.Windows.Forms.ToolStripMenuItem menuPaste;
		private System.Windows.Forms.ToolStripMenuItem menuDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem menuSelectAll;
		private System.Windows.Forms.ToolStripMenuItem menuRedo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem menuFind;
		private System.Windows.Forms.ToolStripMenuItem menuCopyAll;
	}
}
