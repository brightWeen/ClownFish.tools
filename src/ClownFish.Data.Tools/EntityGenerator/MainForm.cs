using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data.Common;
using ClownFish.Data.Xml;
using ClownFish.Base.Xml;

namespace ClownFish.Data.Tools.EntityGenerator
{

	public partial class MainForm : Form
	{
		
		private static readonly int ICON_DataBase = 0;
		private static readonly int ICON_Table = 1;
		private static readonly int ICON_None = 2;
		private static readonly int ICON_FolderClosed = 3;
		private static readonly int ICON_FolderOpened = 4;
		private static readonly int ICON_SP = 5;
		private static readonly int ICON_View = 6;

		private static readonly string STR_None = "[None]";

		private static readonly string ConnectionStringHistoryFile =
			Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "ClownFishGenerator.txt");

		private string _connectionString;

		public MainForm()
		{
			InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try {
				System.Diagnostics.Process.Start("http://www.cnblogs.com/fish-li/archive/2012/07/17/ClownFish.html");
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.Text += " V" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
			this.Icon = Properties.Resources._003b;
			this.imageList1.Images.Add(Properties.Resources.database);
			this.imageList1.Images.Add(Properties.Resources.table);
			this.imageList1.Images.Add(Properties.Resources.notInclude);
			this.imageList1.Images.Add(Properties.Resources.folderclosed2);
			this.imageList1.Images.Add(Properties.Resources.folderopened2);
			this.imageList1.Images.Add(Properties.Resources.SqlTemplate);
			this.imageList1.Images.Add(Properties.Resources.view);

			this.ucParameterStyle1.Location = this.ucCsClassStyle1.Location;
		}
				

		private void Form1_Shown(object sender, EventArgs e)
		{
			try {
				string[] lines = File.ReadAllText(ConnectionStringHistoryFile, Encoding.Unicode)
							.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
				foreach( string s in lines )
					cboConnectionString.Items.Add(s);
			}
			catch { }

			if( cboConnectionString.Items.Count == 0 )
				cboConnectionString.Text = "server=localhost\\sqlexpress;Integrated Security=SSPI";
			else
				cboConnectionString.SelectedIndex = 0;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			StringBuilder sb = new StringBuilder();

			for( int i = 0; i < cboConnectionString.Items.Count; i++ )
				sb.AppendLine(cboConnectionString.Items[i].ToString());

			try {
				if( sb.Length > 0 )
					File.WriteAllText(ConnectionStringHistoryFile, sb.ToString(), Encoding.Unicode);
				else {
					if( File.Exists(ConnectionStringHistoryFile) )
						File.Delete(ConnectionStringHistoryFile);
				}
			}
			catch { }
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			string connectionString = cboConnectionString.Text.Trim();
			if( connectionString.Length == 0 ) {
				MessageBox.Show("连接字符串不能为空。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			TryToDo(FillDataBases);
			treeView1.Focus();
		}

		private void TryToDo(Action action)
		{
			try {
				action();
			}
			catch( Exception ex ) {
				ShowCode(ex.ToString(), "txt");
			}
		}

		
		private void FillDataBases()
		{
			string connectionString = cboConnectionString.Text.Trim();
			int version = SqlServerHelper.GetSqlServerVersion(connectionString);

			if( version < 9 ) {
				MessageBox.Show("本程序只支持 SQL Server 2005 及以上版本。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			List<string> list = SqlServerHelper.GetDataBaseNames(connectionString);


			treeView1.Nodes.Clear();

			foreach( string table in list ) {
				TreeNode root = new TreeNode(table, ICON_DataBase, ICON_DataBase);
				root.Tag = STR_DataBase;

				TreeNode tablesNode = new TreeNode(STR_Tables, ICON_FolderClosed, ICON_FolderClosed);
				tablesNode.Nodes.Add(new TreeNode("loading...", ICON_None, ICON_None));
				root.Nodes.Add(tablesNode);

				TreeNode viewNode = new TreeNode(STR_Views, ICON_FolderClosed, ICON_FolderClosed);
				viewNode.Nodes.Add(new TreeNode("loading...", ICON_None, ICON_None));
				root.Nodes.Add(viewNode);

				TreeNode spNode = new TreeNode(STR_Procedures, ICON_FolderClosed, ICON_FolderClosed);
				spNode.Nodes.Add(new TreeNode("loading...", ICON_None, ICON_None));
				root.Nodes.Add(spNode);

				treeView1.Nodes.Add(root);
			}

			_connectionString = connectionString;

			RememberConnectionString(connectionString);
		}

		private static readonly string STR_DataBase = "DataBase";
		private static readonly string STR_Tables = "Tables";
		private static readonly string STR_Views = "Views";
		private static readonly string STR_Procedures = "Procedures";


		private void RememberConnectionString(string connectionString)
		{
			for( int i = 0; i < cboConnectionString.Items.Count; i++ )
				if( string.Compare(connectionString, cboConnectionString.Items[i].ToString(), 
					StringComparison.OrdinalIgnoreCase) == 0 )
					return;

			cboConnectionString.Items.Add(connectionString);
		}


		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			if( e.Node.ImageIndex == ICON_FolderClosed ) {
				e.Node.ImageIndex = ICON_FolderOpened;
				e.Node.SelectedImageIndex = ICON_FolderOpened;
			}
		}

		private void treeView1_AfterCollapse(object sender, TreeViewEventArgs e)
		{
			if( e.Node.ImageIndex == ICON_FolderOpened ) {
				e.Node.ImageIndex = ICON_FolderClosed;
				e.Node.SelectedImageIndex = ICON_FolderClosed;
			}
		}

		private void treeView1_AfterExpand(object sender, TreeViewEventArgs e)
		{
			if( _connectionString == null )
				return;

			Application.DoEvents();

			if( e.Node.Text == STR_Tables && e.Node.Tag == null )
				LoadTables(e);
			else if( e.Node.Text == STR_Views && e.Node.Tag == null )
				LoadViews(e);
			else if( e.Node.Text == STR_Procedures && e.Node.Tag == null )
				LoadProcedures(e);
		}

		private void ShowObjects(TreeNode node, List<string> names, int iconIndex)
		{
			node.Tag = "OK";
			node.Nodes.Clear();

			if( names.Count == 0 ) {
				node.Nodes.Add(new TreeNode(STR_None, ICON_None, ICON_None));
				return;
			}

			foreach( string table in names )
				node.Nodes.Add(new TreeNode(table, iconIndex, iconIndex));
		}


		private void LoadTables(TreeViewEventArgs e)
		{
			List<string> list = SqlServerHelper.GetTableNames(_connectionString, e.Node.Parent.Text);
			ShowObjects(e.Node, list, ICON_Table);
		}

		private void LoadViews(TreeViewEventArgs e)
		{
			List<string> list = SqlServerHelper.GetViewNames(_connectionString, e.Node.Parent.Text);
			ShowObjects(e.Node, list, ICON_View);
		}

		private void LoadProcedures(TreeViewEventArgs e)
		{
			List<string> list = SqlServerHelper.GetSpNames(_connectionString, e.Node.Parent.Text);
			ShowObjects(e.Node, list, ICON_SP);
		}

		private void ucCsClassStyle1_OptionChanged(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null )
				return;

			treeView1_AfterSelect(sender, new TreeViewEventArgs(treeView1.SelectedNode));
		}


		private void ShowCode(string code, string language)
		{
			txtCsCode.Language = language;
			txtCsCode.Text = code;
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if( txtCsCode.Visible ) {
				//ucCsClassStyle1.Visible = e.Node.ImageIndex == ICON_Table || e.Node.ImageIndex == ICON_View;
				ucParameterStyle1.Visible = e.Node.ImageIndex == ICON_SP;
			}

			if( e.Node.ImageIndex == ICON_Table )
				GenerateTableCode();

			else if( e.Node.ImageIndex == ICON_SP )
				GenerateSpCode();

			else if( e.Node.ImageIndex == ICON_View )
				GenerateViewCode();
		}

		private void GenerateTableCode()
		{
			if( treeView1.SelectedNode == null )
				return;

			if( treeView1.SelectedNode.ImageIndex != ICON_Table )
				return;

			string database = treeView1.SelectedNode.Parent.Parent.Text;
			string tablename = treeView1.SelectedNode.Text;

			TryToDo(() => {
				List<Field> fields = SqlServerHelper.GetFieldsFromTable(_connectionString, database, tablename);

				if( this.ucCsClassStyle1.CodeStyle.SortByName )
					fields = fields.OrderBy(x => x.Name).ToList();

				ShowCode(Generator.GenerateCode(tablename.TrimPunctuation(),
											fields,
											this.ucCsClassStyle1.CodeStyle
									), "cs");

				txtSqlScript.Text = SqlServerHelper.GenerateTableCreateScript(fields, tablename);
			});

		}

		private void GenerateViewCode()
		{
			if( treeView1.SelectedNode == null )
				return;

			if( treeView1.SelectedNode.ImageIndex != ICON_View )
				return;

			string database = treeView1.SelectedNode.Parent.Parent.Text;
			string viewName = treeView1.SelectedNode.Text;

			TryToDo(() => {
				string query = string.Format("select top 1  * from [{0}] where 1>2", viewName);
				List<Field> fields = SqlServerHelper.GetFieldsFromQuery(_connectionString, database,query);

				if( this.ucCsClassStyle1.CodeStyle.SortByName )
					fields = fields.OrderBy(x => x.Name).ToList();

				ShowCode(Generator.GenerateCode(
											viewName.TrimPunctuation(),
											fields,
											this.ucCsClassStyle1.CodeStyle
									), "cs");
				txtSqlScript.Text = SqlServerHelper.GetViewCode(_connectionString, database, viewName);
			});
		}

		private void GenerateSpCode()
		{
			if( treeView1.SelectedNode == null )
				return;

			if( treeView1.SelectedNode.ImageIndex != ICON_SP )
				return;

			string database = treeView1.SelectedNode.Parent.Parent.Text;
			string spname = treeView1.SelectedNode.Text;

			ShowCode(string.Empty, "cs");
			TryToDo(() => {
				DbParameter[] parameters = SqlServerHelper.GetSpParameters(_connectionString, database, spname);
				ShowCode(Generator.GenerateSpCallCode(parameters, spname, 1, ucParameterStyle1.UseNamedType), "cs");

				txtSqlScript.Text = SqlServerHelper.GetProcedureCode(_connectionString, database, spname);
			});
		}

			

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if( e.Button != MouseButtons.Right )
				return;

			_lastRightClickSelectedNode = e.Node;
			//treeView1.SelectedNode = e.Node;

			if( e.Node.ImageIndex == ICON_SP )
				contextMenuStrip1.Show(treeView1, e.Location);

			else if( e.Node.ImageIndex == ICON_Table )
				contextMenuStrip2.Show(treeView1, e.Location);

			else if( e.Node.ImageIndex == ICON_DataBase )
				contextMenuStrip3.Show(treeView1, e.Location);

			else if( e.Node.ImageIndex == ICON_View )
				contextMenuStrip4.Show(treeView1, e.Location);
		}

		private TreeNode _lastRightClickSelectedNode;

		private void menuCopySpName_Click(object sender, EventArgs e)
		{
			if( _lastRightClickSelectedNode != null )
				Clipboard.SetText(_lastRightClickSelectedNode.Text);
		}
		
		private void menuGetXmlCommandBySP_Click(object sender, EventArgs e)
		{
			if( _lastRightClickSelectedNode == null )
				return;

			string database = _lastRightClickSelectedNode.Parent.Parent.Text;
			TryToDo(() => {
				List<XmlCommandItem> list = SqlServerHelper.ImportCommandFormSP(
									_connectionString, database, _lastRightClickSelectedNode.Text);

				string xml = XmlHelper.XmlSerialize(list, Encoding.UTF8);
				Clipboard.SetText(xml);
			});
			//MessageBox.Show("OK");
		}
		
		private void 根据查询生成数据实体类ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if( _lastRightClickSelectedNode == null )
				return;
			
			QueryDialog dlg = new QueryDialog(_connectionString, _lastRightClickSelectedNode.Text);
			dlg.Owner = this;
			dlg.Show();
		}

		private void 生成增删改命令到剪切板ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if( _lastRightClickSelectedNode == null )
				return;

			string database = _lastRightClickSelectedNode.Parent.Parent.Text;
			TryToDo(() => {
				List<XmlCommandItem> list = SqlServerHelper.GetCUDCommandByTableName(
									_connectionString, database, _lastRightClickSelectedNode.Text);

				string xml = XmlHelper.XmlSerialize(list, Encoding.UTF8);
				Clipboard.SetText(xml);
			});
		}

		private void 定位到指定对象ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if( _lastRightClickSelectedNode == null )
				return;

			// 一定要确保选择了数据库节点
			if( _lastRightClickSelectedNode.Nodes.Count != 3 )
				return;


			string name = XmlCommandTool.InputNameDialog.GetInputString();
			if( string.IsNullOrEmpty(name) )
				return;


			foreach( TreeNode node in _lastRightClickSelectedNode.Nodes ) {
				TreeViewEventArgs tvArgs = new TreeViewEventArgs(node);
				treeView1_AfterExpand(null, tvArgs);

				foreach(TreeNode child in node.Nodes)
					if( string.Compare(child.Text, name, StringComparison.OrdinalIgnoreCase) == 0 ) {
						node.Expand();
						treeView1.SelectedNode = child;
						child.EnsureVisible();

						return;
					}
			}
		}

		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			if( treeView1.SelectedNode  == null )
				return;

			if( e.Control ) {
				if( e.KeyCode == Keys.C )
					Clipboard.SetText(treeView1.SelectedNode.Text);
			}
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.Alt ) {
				if( e.KeyCode == Keys.D )
					treeView1.Focus();
			}
		}

		private void 显示隐藏代码窗口ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if( txtCsCode.Visible ) {
				ucParameterStyle1.Visible = false;
				ucCsClassStyle1.Visible = false;
				txtCsCode.Visible = false;
				splitter2.Visible = false;
				this.显示隐藏代码窗口ToolStripMenuItem.Text = "显示 代码窗口";
			}
			else {
				txtCsCode.Visible = true;
				splitter2.Visible = true;

				if( treeView1.SelectedNode != null ) {
					TreeNode node = treeView1.SelectedNode;
					//ucCsClassStyle1.Visible = node.ImageIndex == ICON_Table || node.ImageIndex == ICON_View;
					ucParameterStyle1.Visible = node.ImageIndex == ICON_SP;
				}
				this.显示隐藏代码窗口ToolStripMenuItem.Text = "隐藏 代码窗口";
			}
		}



		

		

		


		

		

		



		

		



		
	}
}
