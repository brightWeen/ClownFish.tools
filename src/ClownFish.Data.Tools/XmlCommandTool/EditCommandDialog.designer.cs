namespace ClownFish.Data.Tools.XmlCommandTool
{
	partial class EditCommandDialog
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAdd = new System.Windows.Forms.ToolStripButton();
			this.btnEdit = new System.Windows.Forms.ToolStripButton();
			this.btnDelete = new System.Windows.Forms.ToolStripButton();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnImport = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.cboCommandType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtDataBase = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.txtCode = new XmlCommandTool.SyntaxHighlighterControl();
			this.label4 = new System.Windows.Forms.Label();
			this.nudTimeout = new System.Windows.Forms.NumericUpDown();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.panel2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel1.Location = new System.Drawing.Point(662, 3);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(393, 532);
			this.panel1.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listView1);
			this.groupBox2.Controls.Add(this.toolStrip1);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Location = new System.Drawing.Point(0, 115);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(393, 374);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "命令参数";
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(3, 42);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(387, 329);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.ItemActivate += new System.EventHandler(this.btnEdit_Click);
			this.listView1.Resize += new System.EventHandler(this.listView1_Resize);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 142;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Type";
			this.columnHeader2.Width = 84;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Direction";
			this.columnHeader3.Width = 78;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Size";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader4.Width = 55;
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdd,
            this.btnEdit,
            this.btnDelete});
			this.toolStrip1.Location = new System.Drawing.Point(3, 17);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(387, 25);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnAdd
			// 
			this.btnAdd.Image = Properties.Resources.NewDocumentHS;
			this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(51, 22);
			this.btnAdd.Text = "新增";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Image = Properties.Resources.EditTableHS;
			this.btnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(51, 22);
			this.btnEdit.Text = "修改";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Image = Properties.Resources.DeleteHS;
			this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(51, 22);
			this.btnDelete.Text = "删除";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnImport);
			this.panel2.Controls.Add(this.btnCancel);
			this.panel2.Controls.Add(this.btnOK);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 489);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(393, 43);
			this.panel2.TabIndex = 1;
			// 
			// btnImport
			// 
			this.btnImport.Location = new System.Drawing.Point(7, 10);
			this.btnImport.Name = "btnImport";
			this.btnImport.Size = new System.Drawing.Size(100, 23);
			this.btnImport.TabIndex = 2;
			this.btnImport.Text = "从剪切板导入";
			this.btnImport.UseVisualStyleBackColor = true;
			this.btnImport.Visible = false;
			this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(301, 10);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "取消(&C)";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(206, 10);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "确定(&K)";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.nudTimeout);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.cboCommandType);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtDataBase);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(393, 115);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "基本信息";
			// 
			// cboCommandType
			// 
			this.cboCommandType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCommandType.FormattingEnabled = true;
			this.cboCommandType.Location = new System.Drawing.Point(62, 76);
			this.cboCommandType.Name = "cboCommandType";
			this.cboCommandType.Size = new System.Drawing.Size(174, 20);
			this.cboCommandType.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(29, 12);
			this.label3.TabIndex = 4;
			this.label3.Text = "类型";
			// 
			// txtDataBase
			// 
			this.txtDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDataBase.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtDataBase.Location = new System.Drawing.Point(62, 45);
			this.txtDataBase.Name = "txtDataBase";
			this.txtDataBase.Size = new System.Drawing.Size(318, 21);
			this.txtDataBase.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "数据库";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtName.Location = new System.Drawing.Point(62, 18);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(318, 21);
			this.txtName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.Color.Red;
			this.label1.Location = new System.Drawing.Point(10, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "名称*";
			// 
			// splitter1
			// 
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
			this.splitter1.Location = new System.Drawing.Point(655, 3);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(7, 532);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// txtCode
			// 
			this.txtCode.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtCode.Location = new System.Drawing.Point(3, 3);
			this.txtCode.Name = "txtCode";
			this.txtCode.ReadOnly = false;
			this.txtCode.Size = new System.Drawing.Size(652, 532);
			this.txtCode.TabIndex = 2;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(243, 80);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 12);
			this.label4.TabIndex = 6;
			this.label4.Text = "超时(秒)";
			// 
			// nudTimeout
			// 
			this.nudTimeout.Font = new System.Drawing.Font("Courier New", 9F);
			this.nudTimeout.Location = new System.Drawing.Point(301, 76);
			this.nudTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.nudTimeout.Name = "nudTimeout";
			this.nudTimeout.Size = new System.Drawing.Size(79, 21);
			this.nudTimeout.TabIndex = 7;
			this.nudTimeout.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
			// 
			// EditCommandDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(1058, 538);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.panel1);
			this.MinimizeBox = false;
			this.Name = "EditCommandDialog";
			this.Padding = new System.Windows.Forms.Padding(3);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "新增命令";
			this.Load += new System.EventHandler(this.EditCommandDialog_Load);
			this.Shown += new System.EventHandler(this.EditCommandDialog_Shown);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nudTimeout)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Splitter splitter1;
		private XmlCommandTool.SyntaxHighlighterControl txtCode;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtDataBase;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAdd;
		private System.Windows.Forms.ToolStripButton btnEdit;
		private System.Windows.Forms.ToolStripButton btnDelete;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ComboBox cboCommandType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.NumericUpDown nudTimeout;
		private System.Windows.Forms.Label label4;
	}
}