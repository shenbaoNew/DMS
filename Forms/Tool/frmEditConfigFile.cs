using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMS.Forms
{
    public partial class frmEditConfigFile : BaseForm
    {
        private string fileName = string.Empty;
        private string folderName = string.Empty;
        private string fileExpend = string.Empty;

        public frmEditConfigFile()
        {
            InitializeComponent();

            _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog.Filter = "文本文件|*.txt;*.html;*.htm;*.xml;*.sql;*.cs;*.java;*.c";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.DefaultExt = ".xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName.Trim();
                folderName = Path.GetDirectoryName(fileName);
                fileExpend = Path.GetExtension(fileName);
                SetTextDisplayStyle(fileExpend);

                Stream info = openFileDialog.OpenFile();
                StreamReader sr = new StreamReader(info, System.Text.Encoding.UTF8);
                _txtFile.Text = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
            }
        }

        private void SaveFile()
        {
            if (string.IsNullOrEmpty(fileName))
                return;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.InitialDirectory = folderName;
            saveFileDialog.Filter = "文本文件|*.txt;*.html;*.htm;*.xml;*.sql";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            StreamWriter sw = new StreamWriter(fileName, false, System.Text.Encoding.UTF8);
            sw.WriteLine(_txtFile.Text);
            sw.Close();
            sw.Dispose();

            btnSave.Enabled = false;
        }

        private void SetTextDisplayStyle(string extension)
        {
            string temp = extension.ToLower();
            if (temp == ".xml")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("XML");
            else if(temp==".txt")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TXT");
            else if(temp==".sql")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            else if (temp == ".html"||temp==".htm")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("HTML");
            else if (temp == ".cs")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
            else if (temp == ".java")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("JAVA");
            else if (temp == ".c")
                _txtFile.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void _txtFile_TextChanged(object sender, EventArgs e)
        {
            if (_txtFile.Text.Length > 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }
    }
}
