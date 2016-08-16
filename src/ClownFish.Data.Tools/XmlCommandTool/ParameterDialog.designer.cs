namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class ParameterDialog
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
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.cboDbType = new System.Windows.Forms.ComboBox();
			this.cboDirection = new System.Windows.Forms.ComboBox();
			this.nudSize = new System.Windows.Forms.NumericUpDown();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nudSize)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "DbType";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "Direction";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 93);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(29, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "Size";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(79, 9);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(251, 21);
			this.txtName.TabIndex = 1;
			// 
			// cboDbType
			// 
			this.cboDbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cboDbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDbType.FormattingEnabled = true;
			this.cboDbType.Location = new System.Drawing.Point(79, 35);
			this.cboDbType.MaxDropDownItems = 30;
			this.cboDbType.Name = "cboDbType";
			this.cboDbType.Size = new System.Drawing.Size(251, 22);
			this.cboDbType.TabIndex = 3;
			this.cboDbType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cboDbType_DrawItem);
			// 
			// cboDirection
			// 
			this.cboDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboDirection.FormattingEnabled = true;
			this.cboDirection.Location = new System.Drawing.Point(79, 64);
			this.cboDirection.Name = "cboDirection";
			this.cboDirection.Size = new System.Drawing.Size(251, 20);
			this.cboDirection.TabIndex = 5;
			// 
			// nudSize
			// 
			this.nudSize.Location = new System.Drawing.Point(79, 92);
			this.nudSize.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.nudSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
			this.nudSize.Name = "nudSize";
			this.nudSize.Size = new System.Drawing.Size(251, 21);
			this.nudSize.TabIndex = 7;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(255, 125);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 21);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "取消";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(147, 125);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 21);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// ParameterDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(362, 167);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.nudSize);
			this.Controls.Add(this.cboDirection);
			this.Controls.Add(this.cboDbType);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ParameterDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "设置命令参数";
			this.Load += new System.EventHandler(this.ParameterDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.nudSize)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.ComboBox cboDbType;
		private System.Windows.Forms.ComboBox cboDirection;
		private System.Windows.Forms.NumericUpDown nudSize;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
	}
}