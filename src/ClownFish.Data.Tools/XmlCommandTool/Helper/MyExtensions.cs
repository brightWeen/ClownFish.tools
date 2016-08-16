using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ClownFish.Base;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public static class MyExtensions
	{

		public static TreeNode FindNodeByText(this TreeNodeCollection nodes, string text)
		{
			for( int i = 0; i < nodes.Count; i++ )
				if( nodes[i].Text.EqualsIgnoreCase(text) ) {
					return nodes[i];
				}

			return null;
		}

		public static void RemoveNodeByText(this TreeNodeCollection nodes, string text)
		{
			TreeNode node = nodes.FindNodeByText(text);
			if( node != null )
				nodes.Remove(node);
		}

		public static bool IsSameDirectory(this string dir1, string dir2)
		{
			string path1 = Path.Combine(dir1, "fish.li").ToLower();
			string path2 = Path.Combine(dir2, "fish.li").ToLower();
			return path1 == path2;
		}


		public static void DeleteCurrentSelectedNode(this TreeView treeView1)
		{
			if( treeView1.SelectedNode == null )
				return;


			TreeNode prenode = treeView1.SelectedNode.PrevNode;
			if( prenode == null )
				prenode = treeView1.SelectedNode.NextNode;

			treeView1.Nodes.Remove(treeView1.SelectedNode);

			if( prenode != null )
				treeView1.SelectedNode = prenode;
		}

	}
}
