namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class FileChangedDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnNO = new System.Windows.Forms.Button();
			this.btnYES = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(419, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "XmlCommandTool 检测到以下文件被其它应用程序更新了，是否重新加载它们？";
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(13, 38);
			this.listView1.Name = "listView1";
			this.listView1.ShowItemToolTips = true;
			this.listView1.Size = new System.Drawing.Size(605, 192);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "文件名";
			this.columnHeader1.Width = 394;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "修改类别";
			this.columnHeader2.Width = 140;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnNO
			// 
			this.btnNO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNO.Location = new System.Drawing.Point(494, 310);
			this.btnNO.Name = "btnNO";
			this.btnNO.Size = new System.Drawing.Size(126, 23);
			this.btnNO.TabIndex = 6;
			this.btnNO.Text = "不，忽略所有修改";
			this.btnNO.UseVisualStyleBackColor = true;
			this.btnNO.Click += new System.EventHandler(this.btnNO_Click);
			// 
			// btnYES
			// 
			this.btnYES.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnYES.Location = new System.Drawing.Point(316, 310);
			this.btnYES.Name = "btnYES";
			this.btnYES.Size = new System.Drawing.Size(161, 23);
			this.btnYES.TabIndex = 5;
			this.btnYES.Text = "是的，重新加载所有文件";
			this.btnYES.UseVisualStyleBackColor = true;
			this.btnYES.Click += new System.EventHandler(this.btnYES_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 249);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(521, 12);
			this.label2.TabIndex = 7;
			this.label2.Text = "为了防止文件更新冲突，您可以在下面的文本框内指定一个目录将当前所有节点的内容保存起来。";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(13, 268);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(569, 21);
			this.textBox1.TabIndex = 8;
			// 
			// btnOpen
			// 
			this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOpen.Image = Properties.Resources.openfolderHS;
			this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnOpen.Location = new System.Drawing.Point(591, 266);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(27, 23);
			this.btnOpen.TabIndex = 9;
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// FileChangedDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 345);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnNO);
			this.Controls.Add(this.btnYES);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FileChangedDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "文件修改通知";
			this.Load += new System.EventHandler(this.FileChangedDialog_Load);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FileChangedDialog_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button btnNO;
		private System.Windows.Forms.Button btnYES;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button btnOpen;
	}
}