namespace ClownFish.Data.Tools.EntityGenerator
{
	partial class ucParameterStyle
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
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label3 = new System.Windows.Forms.Label();
			this.rbtnNamed = new System.Windows.Forms.RadioButton();
			this.rbtnAnonymous = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(137, 12);
			this.label3.TabIndex = 12;
			this.label3.Text = "类型风格（优先采用）：";
			// 
			// rbtnNamed
			// 
			this.rbtnNamed.AutoSize = true;
			this.rbtnNamed.Location = new System.Drawing.Point(158, 6);
			this.rbtnNamed.Name = "rbtnNamed";
			this.rbtnNamed.Size = new System.Drawing.Size(89, 16);
			this.rbtnNamed.TabIndex = 13;
			this.rbtnNamed.Text = "命名类型(&N)";
			this.rbtnNamed.UseVisualStyleBackColor = true;
			this.rbtnNamed.CheckedChanged += new System.EventHandler(this.rbtnNamed_CheckedChanged);
			// 
			// rbtnAnonymous
			// 
			this.rbtnAnonymous.AutoSize = true;
			this.rbtnAnonymous.Checked = true;
			this.rbtnAnonymous.Location = new System.Drawing.Point(278, 6);
			this.rbtnAnonymous.Name = "rbtnAnonymous";
			this.rbtnAnonymous.Size = new System.Drawing.Size(89, 16);
			this.rbtnAnonymous.TabIndex = 14;
			this.rbtnAnonymous.TabStop = true;
			this.rbtnAnonymous.Text = "匿名类型(&A)";
			this.rbtnAnonymous.UseVisualStyleBackColor = true;
			// 
			// ucParameterStyle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.rbtnAnonymous);
			this.Controls.Add(this.rbtnNamed);
			this.Controls.Add(this.label3);
			this.Name = "ucParameterStyle";
			this.Size = new System.Drawing.Size(397, 25);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RadioButton rbtnNamed;
		private System.Windows.Forms.RadioButton rbtnAnonymous;
	}
}
