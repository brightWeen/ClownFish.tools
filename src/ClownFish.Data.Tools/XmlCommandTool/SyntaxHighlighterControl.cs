using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace ClownFish.Data.Tools.XmlCommandTool
{
	public partial class SyntaxHighlighterControl : UserControl
	{
		public SyntaxHighlighterControl()
		{
			InitializeComponent();

			if( this.DesignMode == false ) {
				this.textEditorControl1.Font = new Font("Courier New", 9.5f);
				this.ReadOnly = true;
				this.Language = this.Language;

			}

		}



		private string m_Language;
		[Browsable(true)]
		[DefaultValue("sql")]
		public string Language
		{
			set 
			{
				if( m_Language != value ) {
					m_Language = value;
					this.textEditorControl1.SetLanguage(value);
				}
			}
			get { return (string.IsNullOrEmpty(m_Language) ? "sql" : m_Language); }
		}

		// 为了兼容老的代码，那些代码直接使用了Textbox.Text

		new public string Text
		{
			set { this.textEditorControl1.SetText(value); }
			get { return this.textEditorControl1.Text; }
		}

		public string Message
		{
			set { this.textEditorControl1.SetText(value); }
		}


		[Browsable(true)]
		[DefaultValue(true)]
		public bool ReadOnly
		{
			get
			{
				return this.textEditorControl1.IsReadOnly;
			}
			set
			{
				this.textEditorControl1.IsReadOnly = value;
			}
		}

		private void menuSelectAll_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.A | Keys.Control);
		}

		private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
		{
			bool hasSomethingSelected = textEditorControl1.HasSomethingSelected;
			bool isReadOnly = this.ReadOnly;

			menuUndo.Enabled = isReadOnly == false && textEditorControl1.ActiveTextAreaControl.Document.UndoStack.CanUndo;
			menuRedo.Enabled = isReadOnly == false && textEditorControl1.ActiveTextAreaControl.Document.UndoStack.CanRedo;
			menuCut.Enabled = isReadOnly == false && hasSomethingSelected;
			menuCopy.Enabled = hasSomethingSelected;
			menuPaste.Enabled = isReadOnly == false && Clipboard.ContainsText();
			menuDelete.Enabled = menuCut.Enabled;
		}

		private void menuUndo_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.Z | Keys.Control);
		}

		private void menuCut_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.X | Keys.Control);
		}

		private void menuCopy_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.C | Keys.Control);
		}

		private void menuPaste_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.V | Keys.Control);
		}

		private void menuDelete_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.Delete);
		}

		private void menuRedo_Click(object sender, EventArgs e)
		{
			textEditorControl1.ExecuteAction(Keys.Y | Keys.Control);
		}

		private void menuFind_Click(object sender, EventArgs e)
		{
			textEditorControl1.ShowSearchTextDialog();
		}

		private void menuCopyAll_Click(object sender, EventArgs e)
		{
			if( textEditorControl1.Text.Length > 0 )
				Clipboard.SetText(textEditorControl1.Text);
		}

	}
}
