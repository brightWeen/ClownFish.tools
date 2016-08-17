namespace ClownFish.Log.PerformanceAnalyzer
{
	partial class SettingsControl
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
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLoginCookieName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtLoginRequestRaw = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMongoDbConnectionString = new System.Windows.Forms.TextBox();
			this.btnCancelSetting = new System.Windows.Forms.Button();
			this.btnSaveSetting = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtLoginCookieName);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtLoginRequestRaw);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox2.Location = new System.Drawing.Point(0, 61);
			this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(814, 402);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "用户登录";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(491, 12);
			this.label3.TabIndex = 6;
			this.label3.Text = "说明：1、请求体应该包含登录所面的用户名和密码，2、URL的域名会用实际的域名来替代。";
			// 
			// txtLoginCookieName
			// 
			this.txtLoginCookieName.Location = new System.Drawing.Point(119, 24);
			this.txtLoginCookieName.Name = "txtLoginCookieName";
			this.txtLoginCookieName.Size = new System.Drawing.Size(414, 21);
			this.txtLoginCookieName.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 27);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "登录Cookie名称";
			// 
			// txtLoginRequestRaw
			// 
			this.txtLoginRequestRaw.AcceptsReturn = true;
			this.txtLoginRequestRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLoginRequestRaw.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtLoginRequestRaw.HideSelection = false;
			this.txtLoginRequestRaw.Location = new System.Drawing.Point(11, 123);
			this.txtLoginRequestRaw.Multiline = true;
			this.txtLoginRequestRaw.Name = "txtLoginRequestRaw";
			this.txtLoginRequestRaw.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtLoginRequestRaw.Size = new System.Drawing.Size(792, 265);
			this.txtLoginRequestRaw.TabIndex = 1;
			this.txtLoginRequestRaw.WordWrap = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(317, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "请输入可用于登录的请求文本（请求行，请求头，请求体）";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtMongoDbConnectionString);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(814, 61);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "性能日志的数据库连接地址（仅支持MongoDb数据库）";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 12);
			this.label4.TabIndex = 5;
			this.label4.Text = "数据库连接字符串";
			// 
			// txtMongoDbConnectionString
			// 
			this.txtMongoDbConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMongoDbConnectionString.Location = new System.Drawing.Point(119, 23);
			this.txtMongoDbConnectionString.Name = "txtMongoDbConnectionString";
			this.txtMongoDbConnectionString.Size = new System.Drawing.Size(687, 21);
			this.txtMongoDbConnectionString.TabIndex = 1;
			// 
			// btnCancelSetting
			// 
			this.btnCancelSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancelSetting.Location = new System.Drawing.Point(728, 533);
			this.btnCancelSetting.Name = "btnCancelSetting";
			this.btnCancelSetting.Size = new System.Drawing.Size(75, 23);
			this.btnCancelSetting.TabIndex = 7;
			this.btnCancelSetting.Text = "撤销修改";
			this.btnCancelSetting.UseVisualStyleBackColor = true;
			this.btnCancelSetting.Click += new System.EventHandler(this.btnCancelSetting_Click);
			// 
			// btnSaveSetting
			// 
			this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveSetting.Location = new System.Drawing.Point(617, 533);
			this.btnSaveSetting.Name = "btnSaveSetting";
			this.btnSaveSetting.Size = new System.Drawing.Size(75, 23);
			this.btnSaveSetting.TabIndex = 6;
			this.btnSaveSetting.Text = "保存设置";
			this.btnSaveSetting.UseVisualStyleBackColor = true;
			this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
			// 
			// SettingsControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnCancelSetting);
			this.Controls.Add(this.btnSaveSetting);
			this.Name = "SettingsControl";
			this.Size = new System.Drawing.Size(814, 568);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLoginCookieName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtLoginRequestRaw;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMongoDbConnectionString;
		private System.Windows.Forms.Button btnCancelSetting;
		private System.Windows.Forms.Button btnSaveSetting;
	}
}
