using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using ClownFish.Data.Xml;
using ClownFish.Base.Xml;
using ClownFish.Base;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class MainForm : Form
	{
		private string _currentPath;
		private bool _changed;
		private List<string> _deletedFiles = new List<string>();

		private static readonly int Icon_ConfigFile = 0;
		private static readonly int Icon_ConfigFile2 = 1;
		private static readonly int Icon_CommandItem = 2;
		private static readonly int Icon_CommandItem2 = 3;

		private FileChangedDialog _fileChangedDialog;

		public MainForm()
		{
			InitializeComponent();

			// 设计器总是把它设置为true，造成启动时发生异常（因为没有设置监控路径）
			this.fileSystemWatcher1.EnableRaisingEvents = false;
		}

		private void btnHelp_Click(object sender, EventArgs e)
		{
			try {
				System.Diagnostics.Process.Start("http://www.cnblogs.com/fish-li/archive/2012/07/17/ClownFish.html");
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			this.Icon = Properties.Resources._039b;
			this.Text += " V" + System.Diagnostics.FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion;
			labCurrentPath.Text = string.Empty;
			RefreshUI();

			this.imageList1.Images.Add(Properties.Resources.config);
			this.imageList1.Images.Add(Properties.Resources.config2);
			this.imageList1.Images.Add(Properties.Resources.EditCodeHS);
			this.imageList1.Images.Add(Properties.Resources.EditCodeHS2);

			this.fileSystemWatcher1.Filter = "*.config";
			this.fileSystemWatcher1.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

			_fileChangedDialog = new FileChangedDialog();
			_fileChangedDialog.Owner = this;
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if( btnSaveAll.Enabled && e.CloseReason == CloseReason.UserClosing )
				if( MessageBox.Show("当前所做的修改还没有保存，确定就直接退出程序吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== DialogResult.No )
					e.Cancel = true;
		}

		private void RefreshUI()
		{
			TreeNode node = treeView1.SelectedNode;

			btnAddFile.Enabled = string.IsNullOrEmpty(_currentPath) == false;
			btnDeleteFile.Enabled = node != null;

			btnAddCommand.Enabled = node != null;
			btnEditCommand.Enabled = node != null && node.IsCommandNode();
			btnDeleteCommnad.Enabled = btnEditCommand.Enabled;

			btnFindCommand.Enabled = treeView1.Nodes.Count > 0;

			labCurrentPath.Visible = string.IsNullOrEmpty(_currentPath) == false;
			btnSaveAll.Enabled = _changed && labCurrentPath.Visible;
		}

		private void btnOpenDirectory_Click(object sender, EventArgs e)
		{
			if( _changed ) {
				if( MessageBox.Show("当前所做的修改还没有保存，如果继续，那么所做的修改将会丢失，确定还要继续吗？",
					this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No )
					return;
			}


			OpenDirectoryDialog dlg = new OpenDirectoryDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			// 停止对目录的监控
			fileSystemWatcher1.EnableRaisingEvents = false;


			string selectedPath = dlg.SelectedPath;
			treeView1.BeginUpdate();
			treeView1.Nodes.Clear();

			try {
				LoadCommands(selectedPath);

				labCurrentPath.Text = selectedPath;
				RegisterHelper.SafeWrite("XmlCommandFilePath", selectedPath);
				_currentPath = selectedPath;


				_changed = false;
				_deletedFiles.Clear();
				txtSQL.Text = string.Empty;
				txtXML.Text = string.Empty;

				RefreshUI();
				treeView1.Focus();

				// 重新开始监控目录
				_fileChangedDialog.ClearFiles();
				fileSystemWatcher1.Path = selectedPath;
				fileSystemWatcher1.EnableRaisingEvents = true;
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally {
				treeView1.EndUpdate();
			}
		}


		private void SetChangedAndRefreshUIAndTreeFocus()
		{
			treeView1.Focus();
			_changed = true;
			RefreshUI();
		}

		private void btnAddFile_Click(object sender, EventArgs e)
		{
			InputNameDialog dlg = new InputNameDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			TreeNode node = new TreeNode(dlg.InputText, Icon_ConfigFile, Icon_ConfigFile2);
			treeView1.Nodes.Add(node);
			treeView1.SelectedNode = node;
			node.EnsureVisible();

			SetChangedAndRefreshUIAndTreeFocus();
		}


		private void btnDeleteFile_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null || treeView1.SelectedNode.IsCommandNode() )
				return;

			if( MessageBox.Show("确定要删除当前文件吗？\r\n" + treeView1.SelectedNode.Text, 
				this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No )
				return;

			_deletedFiles.Add(treeView1.SelectedNode.Text);

			treeView1.DeleteCurrentSelectedNode();
			SetChangedAndRefreshUIAndTreeFocus();
		}

		private void btnAddCommand_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if( selectedNode == null )
				return;

			TreeNode root = (selectedNode.IsFileNode() ? selectedNode : selectedNode.Parent);

			EditCommandDialog dlg = new EditCommandDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			XmlCommandItem command = dlg.Command;
			TreeNode node = new TreeNode(command.CommandName, Icon_CommandItem, Icon_CommandItem2);
			node.SetCommand(command);

			root.Nodes.Add(node);
			treeView1.SelectedNode = node;
			node.EnsureVisible();

			SetChangedAndRefreshUIAndTreeFocus();
		}

		private void btnEditCommand_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null )
				return;

			XmlCommandItem command = treeView1.SelectedNode.GetCommamd();
			if( command == null )
				return;


			EditCommandDialog dlg = new EditCommandDialog();
			dlg.Command = command;
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			command = dlg.Command;
			treeView1.SelectedNode.SetCommand(command);
			treeView1.SelectedNode.Text = command.CommandName;

			_changed = true;

			treeView1_AfterSelect(null, null);
		}

		private void btnDeleteCommnad_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null || treeView1.SelectedNode.IsFileNode() )
				return;

			if( MessageBox.Show("确定要删除当前命令节点吗？\r\n" + treeView1.SelectedNode.Text,
				this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No )
				return;

			treeView1.DeleteCurrentSelectedNode();
			SetChangedAndRefreshUIAndTreeFocus();
		}
		
		private void btnFindCommand_Click(object sender, EventArgs e)
		{
			InputNameDialog dlg = new InputNameDialog();
			if( dlg.ShowDialog() != DialogResult.OK )
				return;

			string name = dlg.InputText;

			foreach(TreeNode root in treeView1.Nodes)
				foreach(TreeNode node in root.Nodes)
					if( string.Compare(node.Text, name, StringComparison.OrdinalIgnoreCase) == 0 ) {
						treeView1.SelectedNode = node;
						node.EnsureVisible();
						return;
					}

			MessageBox.Show("指定的命令名称不存在。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if( treeView1.SelectedNode == null ) {
				labMessage.Text = "Ready.";
				return;
			}
			labMessage.Text = treeView1.SelectedNode.FullPath;


			XmlCommandItem command = treeView1.SelectedNode.GetCommamd();
			if( command == null ) {
				txtSQL.Text = string.Format("\r\n共 {0} 个命令子节点。", treeView1.SelectedNode.Nodes.Count);
				txtXML.Text = string.Empty;
			}
			else {
				string commandText = command.CommandText;

				command.CommandText = "....................";
				txtXML.Text = XmlHelper.XmlSerialize(command, Encoding.UTF8);
				txtSQL.Text = commandText;
				command.CommandText = commandText;
			}

			RefreshUI();
		}

		private void labCurrentPath_Click(object sender, EventArgs e)
		{
			if( labCurrentPath.Text.Length == 0 )
				return;

			try {
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.FileName = "explorer.exe";
				startInfo.Arguments = string.Format("\"{0}\"", labCurrentPath.Text);
				Process.Start(startInfo);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if( treeView1.SelectedNode == null || treeView1.SelectedNode.IsFileNode() )
				return;

			//this.btnEditCommand_Click(null, null);
			this.menuGenerateCallCode_Click(null, null);
		}

		private void 复制名称ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null )
				return;

			Clipboard.SetText(treeView1.SelectedNode.Text);
		}

		private void 复制节点XMLToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null )
				return;

			
			if( treeView1.SelectedNode.IsFileNode() ) {
				List<XmlCommandItem> list = treeView1.SelectedNode.GetCommandList();
				string xml = XmlHelper.XmlSerialize(list, Encoding.UTF8);
				Clipboard.SetText(xml);
			}
			else {
				XmlCommandItem command = treeView1.SelectedNode.GetCommamd();
				string xml = XmlHelper.XmlSerialize(command, Encoding.UTF8);
				Clipboard.SetText(xml);
			}
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if( e.Button != MouseButtons.Right )
				return;

			if( e.Node != treeView1.SelectedNode )
				treeView1.SelectedNode = e.Node;

			this.contextMenuStrip1.Show(this.treeView1, e.Location);
		}

		private static readonly string XmlCommandFlag = "<ArrayOfXmlCommand>\r\n";

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			menuAdd.Enabled = btnAddCommand.Enabled;
			menuEdit.Enabled = btnEditCommand.Enabled;
			menuDelete.Enabled = btnDeleteCommnad.Enabled;
			//menuImport.Enabled = menuEdit.Enabled == false;
			menuGenerateCallCode.Enabled = btnEditCommand.Enabled;


			if( treeView1.SelectedNode.IsFileNode() ) {
				try {
					string xml = Clipboard.GetText();
					menuPaste.Enabled = string.IsNullOrEmpty(xml) == false && xml.StartsWith(XmlCommandFlag);
				}
				catch {
					menuPaste.Enabled = false;
				}
			}
			else
				menuPaste.Enabled = false;
		}


		
		private void btnSaveAll_Click(object sender, EventArgs e)
		{
			fileSystemWatcher1.EnableRaisingEvents = false;
			_fileChangedDialog.ClearFiles();

			try {
				if( SaveAllToDirectory(_currentPath, true) == false )
					return;


				_changed = false;
				_deletedFiles.Clear();
				this.RefreshUI();

				//MessageBox.Show("操作成功。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally {
				fileSystemWatcher1.EnableRaisingEvents = true;
			}			
		}
		
		private bool SaveAllToDirectory(string outPath, bool checkReduplicateName)
		{
			if( checkReduplicateName ) {
				Dictionary<string, int> dict = new Dictionary<string, int>();
				string lastName = null;

				try {
					foreach( TreeNode root in treeView1.Nodes )
						foreach( TreeNode node in root.Nodes ) {
							lastName = node.Text;
							dict.Add(lastName, 1);
						}
				}
				catch( ArgumentException ) {
					MessageBox.Show(string.Format("命令名称 [{0}] 有重复，请修改后再执行保存操作。", lastName),
								this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return false;
				}
			}


			foreach( string file in _deletedFiles ) {
				string deleteFile = Path.Combine(outPath, file + ".config");
				if( File.Exists(deleteFile) )
					File.Delete(deleteFile);
			}


			foreach( TreeNode root in treeView1.Nodes ) {
				string savePath = Path.Combine(outPath, root.Text + ".config");
				List<XmlCommandItem> list = root.GetCommandList();

				if( File.Exists(savePath) ) {
					// 当使用版本控制管理文件时，文件可能没有签出，且文件没有被更新，所以不能直接覆盖。
					//ClownFish.XmlHelper.XmlSerializeToFile(list, savePath, Encoding.UTF8);

					string xml = XmlHelper.XmlSerialize(list, Encoding.UTF8);
					string xml2 = System.IO.File.ReadAllText(savePath, Encoding.UTF8);
					if( xml != xml2 ) {
						System.IO.File.WriteAllText(savePath, xml, Encoding.UTF8);
						//MessageBox.Show(string.Format("文件 {0} 已更新。", savePath),
						//            this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				else
					XmlHelper.XmlSerializeToFile(list, savePath, Encoding.UTF8);
			}

			return true;
		}
		
		private void LoadCommands(string path)
		{
			string[] files = Directory.GetFiles(path, "*.config", SearchOption.TopDirectoryOnly);

			LoadFiles(files, false);
		}

		private void LoadFiles(string[] files, bool beforeDelete)
		{
			foreach( string file in files ) {
				List<XmlCommandItem> list = null;
				try {
					list = XmlHelper.XmlDeserializeFromFile<List<XmlCommandItem>>(file);
				}
				catch( Exception ex ) {
					throw new InvalidOperationException(
						string.Format("在读取文件 {0} 时失败，错误原因：\r\n{1}", file, ex.Message), ex);
				}

				list.Sort((a, b) => string.Compare(a.CommandName, b.CommandName, StringComparison.OrdinalIgnoreCase));


				TreeNode root = null;
				string nodeText = Path.GetFileNameWithoutExtension(file);

				if( beforeDelete ) 
					root = treeView1.Nodes.FindNodeByText(nodeText);
				

				if( root == null ) {
					root = new TreeNode(nodeText, Icon_ConfigFile, Icon_ConfigFile2);
					treeView1.Nodes.Add(root);
				}
				else {
					root.Text = nodeText;
					root.Nodes.Clear();
				}				

				foreach( XmlCommandItem command in list ) {
					TreeNode node = new TreeNode(command.CommandName, Icon_CommandItem, Icon_CommandItem2);
					node.SetCommand(command);
					root.Nodes.Add(node);
				}				
			}
		}

		
		private void menuPaste_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null || treeView1.SelectedNode.IsCommandNode() )
				return;

			try {
				string xml = Clipboard.GetText();
				if( string.IsNullOrEmpty(xml) )
					return;

				TreeNode root = treeView1.SelectedNode;

				List<XmlCommandItem> list = XmlHelper.XmlDeserialize<List<XmlCommandItem>>(xml);
				foreach( XmlCommandItem command in list ) {
					TreeNode node = new TreeNode(command.CommandName, Icon_CommandItem, Icon_CommandItem2);
					node.SetCommand(command);
					root.Nodes.Add(node);

					SetChangedAndRefreshUIAndTreeFocus();
				}
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
		}

		private void menuGenerateCallCode_Click(object sender, EventArgs e)
		{
			if( treeView1.SelectedNode == null || treeView1.SelectedNode.IsFileNode()) 
				return;
			if( btnEditCommand.Enabled == false )
				return;

			XmlCommandItem command = treeView1.SelectedNode.GetCommamd();
			
			ShowCallCodeDialog dlg = new ShowCallCodeDialog(command, treeView1.SelectedNode.Text);
			dlg.Owner = this;
			dlg.Show();
		}

		private void treeView1_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.KeyCode == Keys.Delete ) {
				if( treeView1.SelectedNode != null ) {
					if( treeView1.SelectedNode.IsFileNode() )
						this.btnDeleteFile_Click(sender, null);
					else
						this.btnDeleteCommnad_Click(sender, null);
				}
			}
			else if( e.KeyCode == Keys.F12 ) {
				if( btnEditCommand.Enabled )
					menuGenerateCallCode_Click(null, null);
			}
			else if( e.Control ) {
				if( e.KeyCode == Keys.C )
					复制名称ToolStripMenuItem_Click(null, null);
			}
		}


		private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
		{
			_fileChangedDialog.AddFile(e);
		}

		internal void FileChangedDialog_YesButtonClicked(string tempOutPath, List<FileSystemEventArgs> eventList)
		{
			// 将当前节点保存到指定的目录中。
			if( string.IsNullOrEmpty(tempOutPath) == false ) {
				if( tempOutPath.IsSameDirectory(_currentPath) ) {
					MessageBox.Show("临时输出目录不能是当前目录。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				try {
					if( SaveAllToDirectory(tempOutPath, false) == false )
						return;
				}
				catch( Exception ex ) {
					MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
					return;
				}
			}

			
			// 记住当前选择的节点
			string currentFileNode = null;
			string currentCommandNode = null;

			if( treeView1.SelectedNode != null ) {
				if( treeView1.SelectedNode.IsFileNode() )
					currentFileNode = treeView1.SelectedNode.Text;
				else {
					currentCommandNode = treeView1.SelectedNode.Text;
					currentFileNode = treeView1.SelectedNode.Parent.Text;
				}
			}


			// 删除节点
			foreach( FileSystemEventArgs e in eventList ) {
				if( e.ChangeType == WatcherChangeTypes.Deleted )
					treeView1.Nodes.RemoveNodeByText(Path.GetFileNameWithoutExtension(e.Name));
			}


			try {
				// 重新加载文件。
				string[] files = (from e in eventList where e.ChangeType != WatcherChangeTypes.Deleted select e.FullPath).ToArray();
				LoadFiles(files, true);
			}
			catch( Exception ex ) {
				MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}


			// 还原当前选择的节点
			if( currentFileNode != null ) {
				foreach( TreeNode root in treeView1.Nodes ) {
					if( root.Text.EqualsIgnoreCase( currentFileNode) ) {
						treeView1.SelectedNode = root;

						if( currentCommandNode != null ) {
							foreach( TreeNode node in root.Nodes ) {
								if( node.Text.EqualsIgnoreCase( currentCommandNode) ) {
									treeView1.SelectedNode = node;
									break;
								}
							}
						}

						break;
					}
				}

				if( treeView1.SelectedNode != null )
					treeView1.SelectedNode.EnsureVisible();

				treeView1_AfterSelect(null, null);
			}

			// 隐藏通知窗口
			FileChangedDialog_ClearAndHide();
		}
		
		internal void FileChangedDialog_ClearAndHide()
		{
			_fileChangedDialog.ClearFiles();
			_fileChangedDialog.Hide();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if( this.fileSystemWatcher1.EnableRaisingEvents )
				if( _fileChangedDialog != null && _fileChangedDialog.Visible == false &&
					_fileChangedDialog.HasFile() && Form.ActiveForm == this )
					_fileChangedDialog.ShowDialog();
		}

		

		
	}
}
