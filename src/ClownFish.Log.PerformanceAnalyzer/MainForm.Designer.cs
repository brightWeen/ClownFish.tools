namespace ClownFish.Log.PerformanceAnalyzer
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
			this.components = new System.ComponentModel.Container();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.logSearchControl1 = new ClownFish.Log.PerformanceAnalyzer.LogSearchControl();
			this.sendRequestControl1 = new ClownFish.Log.PerformanceAnalyzer.SendRequestControl();
			this.settingsControl1 = new ClownFish.Log.PerformanceAnalyzer.SettingsControl();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 630);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(904, 22);
			this.statusStrip1.TabIndex = 0;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(904, 630);
			this.tabControl1.TabIndex = 1;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.logSearchControl1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tabPage1.Size = new System.Drawing.Size(896, 604);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "人工日志分析";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.sendRequestControl1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(821, 604);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "重发请求";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.settingsControl1);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
			this.tabPage3.Size = new System.Drawing.Size(821, 604);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "参数设置";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// logSearchControl1
			// 
			this.logSearchControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.logSearchControl1.Location = new System.Drawing.Point(5, 10);
			this.logSearchControl1.Name = "logSearchControl1";
			this.logSearchControl1.Size = new System.Drawing.Size(886, 589);
			this.logSearchControl1.TabIndex = 0;
			// 
			// sendRequestControl1
			// 
			this.sendRequestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.sendRequestControl1.Location = new System.Drawing.Point(3, 3);
			this.sendRequestControl1.Name = "sendRequestControl1";
			this.sendRequestControl1.Size = new System.Drawing.Size(815, 598);
			this.sendRequestControl1.TabIndex = 0;
			// 
			// settingsControl1
			// 
			this.settingsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.settingsControl1.Location = new System.Drawing.Point(5, 10);
			this.settingsControl1.Name = "settingsControl1";
			this.settingsControl1.Size = new System.Drawing.Size(811, 589);
			this.settingsControl1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 652);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.statusStrip1);
			this.KeyPreview = true;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "性能日志分析工具";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Shown += new System.EventHandler(this.MainForm_Shown);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private LogSearchControl logSearchControl1;
		private SendRequestControl sendRequestControl1;
		private SettingsControl settingsControl1;
		private System.Windows.Forms.ImageList imageList1;
	}
}

