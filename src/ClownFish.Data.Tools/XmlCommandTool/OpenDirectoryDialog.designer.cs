namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class OpenDirectoryDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(15, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(185, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "请输入或者选择要打开的目录路径";
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(15, 43);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(650, 21);
			this.txtPath.TabIndex = 1;
			// 
			// btnOpen
			// 
			this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOpen.Image = Properties.Resources.openfolderHS;
			this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
			this.btnOpen.Location = new System.Drawing.Point(671, 43);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(27, 23);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(470, 90);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(590, 90);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// OpenDirectoryDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(720, 139);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenDirectoryDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "打开目录对话框";
			this.Shown += new System.EventHandler(this.OpenDirectoryDialog_Shown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}