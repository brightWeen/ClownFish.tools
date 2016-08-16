namespace ClownFish.Data.Tools
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
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.工具TToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.xmlCommand配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.实体生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.WindowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具TToolStripMenuItem,
            this.WindowsToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.MdiWindowListItem = this.WindowsToolStripMenuItem;
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(934, 25);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 工具TToolStripMenuItem
			// 
			this.工具TToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xmlCommand配置ToolStripMenuItem,
            this.实体生成ToolStripMenuItem});
			this.工具TToolStripMenuItem.Name = "工具TToolStripMenuItem";
			this.工具TToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.工具TToolStripMenuItem.Text = "工具(&T)";
			// 
			// xmlCommand配置ToolStripMenuItem
			// 
			this.xmlCommand配置ToolStripMenuItem.Name = "xmlCommand配置ToolStripMenuItem";
			this.xmlCommand配置ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.xmlCommand配置ToolStripMenuItem.Text = "XmlCommand配置";
			this.xmlCommand配置ToolStripMenuItem.Click += new System.EventHandler(this.xmlCommand配置ToolStripMenuItem_Click);
			// 
			// 实体生成ToolStripMenuItem
			// 
			this.实体生成ToolStripMenuItem.Name = "实体生成ToolStripMenuItem";
			this.实体生成ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
			this.实体生成ToolStripMenuItem.Text = "实体生成";
			this.实体生成ToolStripMenuItem.Click += new System.EventHandler(this.实体生成ToolStripMenuItem_Click);
			// 
			// WindowsToolStripMenuItem
			// 
			this.WindowsToolStripMenuItem.Name = "WindowsToolStripMenuItem";
			this.WindowsToolStripMenuItem.Size = new System.Drawing.Size(64, 21);
			this.WindowsToolStripMenuItem.Text = "窗口(&W)";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(934, 700);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ClownFish.Data.Tools";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem 工具TToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem xmlCommand配置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 实体生成ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem WindowsToolStripMenuItem;
	}
}

