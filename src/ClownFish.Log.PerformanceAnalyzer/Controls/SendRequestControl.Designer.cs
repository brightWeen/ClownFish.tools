namespace ClownFish.Log.PerformanceAnalyzer
{
	partial class SendRequestControl
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

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要修改
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.txtRequestRaw = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btnResenExecute = new System.Windows.Forms.Button();
			this.numericUpDownResend = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.listResendResult = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownResend)).BeginInit();
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.splitter1.Location = new System.Drawing.Point(0, 255);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(763, 6);
			this.splitter1.TabIndex = 8;
			this.splitter1.TabStop = false;
			// 
			// txtRequestRaw
			// 
			this.txtRequestRaw.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtRequestRaw.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtRequestRaw.Location = new System.Drawing.Point(0, 36);
			this.txtRequestRaw.Multiline = true;
			this.txtRequestRaw.Name = "txtRequestRaw";
			this.txtRequestRaw.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtRequestRaw.Size = new System.Drawing.Size(763, 225);
			this.txtRequestRaw.TabIndex = 10;
			this.txtRequestRaw.WordWrap = false;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btnResenExecute);
			this.panel3.Controls.Add(this.numericUpDownResend);
			this.panel3.Controls.Add(this.label13);
			this.panel3.Controls.Add(this.label9);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(0, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(763, 36);
			this.panel3.TabIndex = 9;
			// 
			// btnResenExecute
			// 
			this.btnResenExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnResenExecute.Location = new System.Drawing.Point(646, 6);
			this.btnResenExecute.Name = "btnResenExecute";
			this.btnResenExecute.Size = new System.Drawing.Size(100, 23);
			this.btnResenExecute.TabIndex = 9;
			this.btnResenExecute.Text = "发送请求(F5)";
			this.btnResenExecute.UseVisualStyleBackColor = true;
			this.btnResenExecute.Click += new System.EventHandler(this.btnResenExecute_Click);
			// 
			// numericUpDownResend
			// 
			this.numericUpDownResend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDownResend.Location = new System.Drawing.Point(561, 7);
			this.numericUpDownResend.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numericUpDownResend.Name = "numericUpDownResend";
			this.numericUpDownResend.Size = new System.Drawing.Size(77, 21);
			this.numericUpDownResend.TabIndex = 7;
			this.numericUpDownResend.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(498, 12);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(53, 12);
			this.label13.TabIndex = 6;
			this.label13.Text = "执行次数";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(3, 12);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(125, 12);
			this.label9.TabIndex = 5;
			this.label9.Text = "HttpRequest Raw Text";
			// 
			// listResendResult
			// 
			this.listResendResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.listResendResult.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.listResendResult.FullRowSelect = true;
			this.listResendResult.HideSelection = false;
			this.listResendResult.Location = new System.Drawing.Point(0, 261);
			this.listResendResult.MultiSelect = false;
			this.listResendResult.Name = "listResendResult";
			this.listResendResult.Size = new System.Drawing.Size(763, 226);
			this.listResendResult.TabIndex = 7;
			this.listResendResult.UseCompatibleStateImageBehavior = false;
			this.listResendResult.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "#";
			this.columnHeader1.Width = 79;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "执行时间";
			this.columnHeader2.Width = 212;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "响应状态";
			this.columnHeader3.Width = 167;
			// 
			// SendRequestControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.txtRequestRaw);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.listResendResult);
			this.Name = "SendRequestControl";
			this.Size = new System.Drawing.Size(763, 487);
			this.panel3.ResumeLayout(false);
			this.panel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownResend)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TextBox txtRequestRaw;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.NumericUpDown numericUpDownResend;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ListView listResendResult;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnResenExecute;
	}
}
