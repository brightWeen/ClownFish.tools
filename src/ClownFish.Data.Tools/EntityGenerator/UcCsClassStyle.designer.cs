namespace ClownFish.Data.Tools.EntityGenerator
{
	partial class UcCsClassStyle
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
			this.chkWCF = new System.Windows.Forms.CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkSortByName = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkWCF
			// 
			this.chkWCF.AutoSize = true;
			this.chkWCF.Location = new System.Drawing.Point(96, 5);
			this.chkWCF.Name = "chkWCF";
			this.chkWCF.Size = new System.Drawing.Size(42, 16);
			this.chkWCF.TabIndex = 15;
			this.chkWCF.Text = "&WCF";
			this.chkWCF.UseVisualStyleBackColor = true;
			this.chkWCF.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(5, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 12);
			this.label3.TabIndex = 11;
			this.label3.Text = "代码风格";
			// 
			// chkSortByName
			// 
			this.chkSortByName.AutoSize = true;
			this.chkSortByName.Location = new System.Drawing.Point(170, 5);
			this.chkSortByName.Name = "chkSortByName";
			this.chkSortByName.Size = new System.Drawing.Size(84, 16);
			this.chkSortByName.TabIndex = 16;
			this.chkSortByName.Text = "按名称排序";
			this.chkSortByName.UseVisualStyleBackColor = true;
			this.chkSortByName.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// UcCsClassStyle
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.chkSortByName);
			this.Controls.Add(this.chkWCF);
			this.Controls.Add(this.label3);
			this.Name = "UcCsClassStyle";
			this.Size = new System.Drawing.Size(302, 25);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkWCF;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkSortByName;
	}
}
