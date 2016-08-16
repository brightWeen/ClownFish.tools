using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClownFish.Data;
using ClownFish.Data.Xml;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public static class MainFormTreeViewExtensions
	{
		public static bool IsFileNode(this TreeNode node)
		{
			return (node.Tag == null);
		}

		public static bool IsCommandNode(this TreeNode node)
		{
			return (node.Tag != null);
		}

		public static XmlCommandItem GetCommamd(this TreeNode node)
		{
			if( node.IsCommandNode() == false )
				return null;

			return (XmlCommandItem)node.Tag;
		}

		public static void SetCommand(this TreeNode node, XmlCommandItem command)
		{
			node.Tag = command;
		}


		public static List<XmlCommandItem> GetCommandList(this TreeNode root)
		{
			if( root.IsCommandNode() )
				return null;

			List<XmlCommandItem> list = new List<XmlCommandItem>(root.Nodes.Count);

			foreach( TreeNode node in root.Nodes )
				list.Add((XmlCommandItem)node.Tag);

			return list;
		}

	}
}
