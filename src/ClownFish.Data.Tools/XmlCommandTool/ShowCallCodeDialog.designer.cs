namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class ShowCallCodeDialog
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnCopyAll = new System.Windows.Forms.Button();
			this.ucParameterStyle1 = new ClownFish.Data.Tools.EntityGenerator.ucParameterStyle();
			this.txtCode = new XmlCommandTool.SyntaxHighlighterControl();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnCopyAll);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 481);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(945, 41);
			this.panel1.TabIndex = 1;
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(847, 8);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 1;
			this.btnClose.Text = "关闭(&C)";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnCopyAll
			// 
			this.btnCopyAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCopyAll.Location = new System.Drawing.Point(12, 8);
			this.btnCopyAll.Name = "btnCopyAll";
			this.btnCopyAll.Size = new System.Drawing.Size(251, 23);
			this.btnCopyAll.TabIndex = 0;
			this.btnCopyAll.Text = "复制全部代码到剪切板，并关闭窗口";
			this.btnCopyAll.UseVisualStyleBackColor = true;
			this.btnCopyAll.Click += new System.EventHandler(this.btnCopyAll_Click);
			// 
			// ucParameterStyle1
			// 
			this.ucParameterStyle1.Dock = System.Windows.Forms.DockStyle.Top;
			this.ucParameterStyle1.Location = new System.Drawing.Point(0, 0);
			this.ucParameterStyle1.Name = "ucParameterStyle1";
			this.ucParameterStyle1.Size = new System.Drawing.Size(945, 25);
			this.ucParameterStyle1.TabIndex = 2;
			this.ucParameterStyle1.OptionChanged += new System.EventHandler(this.ucParameterStyle1_OptionChanged);
			// 
			// txtCode
			// 
			this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCode.Language = "cs";
			this.txtCode.Location = new System.Drawing.Point(0, 25);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(945, 456);
			this.txtCode.TabIndex = 3;
			// 
			// ShowCallCodeDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(945, 522);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.ucParameterStyle1);
			this.Controls.Add(this.panel1);
			this.MinimizeBox = false;
			this.Name = "ShowCallCodeDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "自动生成的调用代码";
			this.Load += new System.EventHandler(this.ShowCallCodeDialog_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnCopyAll;
		private ClownFish.Data.Tools.EntityGenerator.ucParameterStyle ucParameterStyle1;
		private SyntaxHighlighterControl txtCode;

	}
}