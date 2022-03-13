using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using HtmlHelp.UIComponents;
using YY.Methods;
using DMS.Forms;
using DMS.Forms.DocumentForms;

namespace DMS.Forms
{
    public partial class frmHelpMain :BaseForm
    {
        private HelpManager _helpMamanger = null;
        public frmHelpMain()
        {
            InitializeComponent();
            //   InitHelpFile("MMSHepler.chm");
            // ShowHelpContent("MMSHepler.chm");
        }

        //private void ShowHelpContent(string fileName)
        //{
        //    if (contentBrower == null || contentBrower.IsDisposed)
        //        contentBrower = new frmTableContentBrowser(fileName);
        //    contentBrower.TabText = "MMS帮助文档";
        //   contentBrower.Show(dockPanel);
        //}
        public void NavigateBrowser(string url)
        {
            string targetFrame = String.Empty;
            byte[] postData = null;
            string headers = String.Empty;
            string oUrl = url;
            this.webBrowser.Navigate(oUrl, targetFrame, postData, headers);

        }
        private void tocTree_TocSelected(object sender, TocEventArgs e)
        {
            if (e.Item.Local.Length > 0)
            {
                NavigateBrowser(e.Item.Url);
            }
        }
        //private void ShowHelpIndex(string fileName)
        //{
        //    frmHelpIndex helpIndex=new frmHelpIndex(fileName);
        //    ShowForm(helpIndex);
        //}

        //private void ShowHelpIndex(string fileName, string word)
        //{
        //    frmHelpIndex helpIndex = new frmHelpIndex(fileName);
        //    helpIndex.SearchWord(word);
        //    ShowForm(helpIndex);
        //}

        public void ShowHelpContext(string url, string caption)
        {
            string targetFrame = String.Empty;
            byte[] postData = null;
            string headers = String.Empty;
            string oUrl = url;
            frmHelpBrowser brower = new frmHelpBrowser();
            brower.Text = "Help - " + caption;
            brower.webBrowser.Navigate(oUrl, targetFrame, postData, headers);
            // ShowForm(brower);
        }
        public void ShowQueryCommanderHelpContext(string url, string context, string caption, bool docked)
        {
            url = url.Length == 0 ? @"mk:@MSITStore:" + Application.StartupPath + "\\Documents\\CSS中文完全参考手册.chm" : url;
            url += context;
            string targetFrame = String.Empty;
            byte[] postData = null;
            string headers = String.Empty;
            string oUrl = url;

            if (docked)
                ShowHelpContext(url, caption);
            else
            {
                frmHelpBrowser frm = new frmHelpBrowser();
                frm.webBrowser.Navigate(oUrl, targetFrame, postData, headers);

                frm.ShowDialog(this);

            }
        }

        private void InitHelpFile(string fileName)
        {
            Functions.CopyFileEmbeddedResource(fileName);
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string fileName = string.Empty;
            if (e.Node.Name == "CssCnaShouCe")
            {
                fileName = Application.StartupPath + "\\CSS中文完全参考手册.chm";
            }
            else if (e.Node.Name == "CssYuFa")
                fileName = Application.StartupPath + "\\CSS3.0（语法）.chm";
            else if (e.Node.Name == "Html5W3cSchool")
                fileName = Application.StartupPath + "\\HTML5（W3CSchool版）.chm";
            else if (e.Node.Name == "JavasciptShouCe")
                fileName = Application.StartupPath + "\\Javascipt语言手册.chm";
            else if (e.Node.Name == "jQuery111")
                fileName = Application.StartupPath + "\\jQuery1.11.0_20140330.chm";
            else if (e.Node.Name == "Regex1")
                fileName = Application.StartupPath + "\\正则表达式系统教程.CHM";

            if (!string.IsNullOrEmpty(fileName))
            {
                _helpMamanger = new HelpManager(fileName);
                InfoTypeCategoryFilter _filter = new InfoTypeCategoryFilter();
                this.tocTree.BuildTOC(_helpMamanger.Reader.TableOfContents, _filter);
            }
        }
    }
}
