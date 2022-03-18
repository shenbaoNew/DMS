using DevComponents.DotNetBar;
using DMS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Security.Cryptography;
using DMS.Forms;
using DMS.DataClass.Pub;
using DMS.Properties;
using System.Collections;
using YY.Methods;
using DMS.DataClass.Systems.User;

namespace DMS
{
    public partial class frmMain : BaseContentsForm
    {
        private ToolStrip middlePanel;
        private TopPanelControl logoPanel;
        private frmMenu leftPanel;
        private Timer timer;
        private ToolStripButton button;
        private MenuStrip mainMenu;
        private Hashtable childForms;
        private UserData user;

        private frmShortCut shortCut;

        public frmMain()
        {
            InitializeComponent();

            this.dockPanel.AllowEndUserDocking = false;
            base.EnableGlass = false;
            SetDockPanelStyle();
            PubContext.formMain = this;
            user = new UserData();

            InitMainType();
        }

        private void SetDockPanelStyle()
        {
            if (PubContext.CurrentUser.UIStyleID == "9")
            {
                this.dockPanel.Theme = new VS2012LightTheme();
            }
            else
            {
                this.dockPanel.Theme = new VS2005Theme();
            }
        }

        #region 功能代码

        private void CreateShotcutTools()
        {
            // 
            // labMemo
            // 
            ToolStripLabel labMemo = new ToolStripLabel();
            labMemo.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            labMemo.Name = "labMemo";
            labMemo.Size = new System.Drawing.Size(72, 22);
            labMemo.Text = "快捷区：";
            labMemo.Click += new EventHandler(labMemo_Click);
            // 
            // StripSeparator2
            // 
            ToolStripSeparator StripSeparator2 = new ToolStripSeparator();
            StripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            StripSeparator2.Name = "StripSeparator2";
            StripSeparator2.Size = new System.Drawing.Size(6, 25);

            //
            //ShotcutTools
            //

            this.middlePanel = new ToolStrip();
            this.middlePanel.CanOverflow = false;
            this.middlePanel.BackgroundImage = ((System.Drawing.Image)(DMS.Properties.Resources.VLine));
            this.middlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;

            this.middlePanel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.middlePanel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            labMemo});
            this.middlePanel.Location = new System.Drawing.Point(0, 0);
            this.middlePanel.Name = "ShotcutTools";
            this.middlePanel.Size = new System.Drawing.Size(692, 25);
            this.middlePanel.TabIndex = 10;

            //ToolStripLabel lebel = new ToolStripLabel();
            //lebel.Text = " 欢迎 " + PubContext.logUser + "   登录时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            //lebel.Alignment = ToolStripItemAlignment.Right;
            //this.middlePanel.Items.Add(lebel);

            ToolStripLabel lebel = new ToolStripLabel();
            lebel.Text = " ";
            lebel.Alignment = ToolStripItemAlignment.Right;
            this.middlePanel.Items.Add(lebel);

            ToolStripLabel logout = new ToolStripLabel();
            logout.Text = "注销";
            logout.VisitedLinkColor = Color.FromArgb(128, 0, 128);
            logout.ActiveLinkColor = Color.Red;
            logout.IsLink = true;
            logout.LinkVisited = true;
            logout.Alignment = ToolStripItemAlignment.Right;
            logout.Click += logout_Click;
            this.middlePanel.Items.Add(logout);

            this.Controls.Add(this.middlePanel);
        }

        void logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void labMemo_Click(object sender, EventArgs e)
        {
            string frmName = "frmManageShorCut";
            bool result = IsExistChildForm(frmName);
            if (!result)
            {
                //frmManageShorCut shortCut = new frmManageShorCut(this.m_FullMenuTable, this.m_RightMenuTable, this.m_ShortCutTable);
                // shortCut.AfterSaveDataEvent += shortCut_AfterSaveDataEvent;
                //shortCut.Show(this.dockPanel);
            }
        }

        /// <summary> 
        /// 判断是否含有该子窗体 
        /// </summary> 
        /// <param name="_ChildFormName">子窗体名称</param> 
        /// <returns>bool</returns> 
        private bool IsExistChildForm(string ChildFormName)
        {

            bool IsExist = false;
            if (dockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.SystemMdi)
            {
                foreach (Form form in this.MdiChildren)
                {
                    if (string.Compare(form.Name, ChildFormName, true) == 0)
                    {
                        form.BringToFront();
                        IsExist = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (DevComponents.DotNetBar.IDockContent document in dockPanel.Contents)
                {
                    if (string.Compare(document.DockHandler.Form.Name, ChildFormName, true) == 0)
                    {
                        IsExist = true;
                        document.DockHandler.Activate();
                        break;
                    }

                }
            }
            return IsExist;
        }

        void Toolbox_AfterFormCloseEvent(object sender, bool isClose)
        {
            if (null == this.MainMenuStrip)
            {
                button = new ToolStripButton();
                button.Alignment = System.Windows.Forms.ToolStripItemAlignment.Left;
                button.ImageTransparentColor = System.Drawing.Color.Magenta;
                button.Tag = "opentoolbox";
                button.Text = "显示菜单栏";
                button.ToolTipText = "显示菜单栏";
                Image img = (Image)Properties.Resources.ResourceManager.GetObject("opentoolbox");
                if (null != img)
                {
                    button.Image = img;
                }
                button.Click += new EventHandler(OpenToolboxMenuItem_Click);
                this.middlePanel.Items.Insert(1, button);
            }
        }

        void OpenToolboxMenuItem_Click(object sender, EventArgs e)
        {
            this.middlePanel.Items.Remove(button);
            FillTree();
        }

        private void CreateTopPanel()
        {
            logoPanel = new TopPanelControl();
            this.logoPanel.BackgroundImage = ((System.Drawing.Image)(DMS.Properties.Resources.HLine));
            this.logoPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(792, 54);
            this.logoPanel.TabIndex = 10;
            this.logoPanel.Text = " 欢迎 " + PubContext.logUser + "   登录时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            this.Controls.Add(logoPanel);
        }

        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void InitMainType()
        {
            SystemMenu menu = new SystemMenu();
            this.MainMenuStrip = null;
            if (PubContext.CurrentUser.FormModule == "0")
            {
                CreateShotcutTools();
                FillTree();
                CreateTopPanel();
                RefreshTime();
                CreateShortCut(PubContext.ShortCutMenus);
            }
            else if (PubContext.CurrentUser.FormModule == "1")
            {
                FillMenu(1);
                ShowShortCut(PubContext.Menus, PubContext.Menus);
            }
            else if (PubContext.CurrentUser.FormModule == "2")
            {
                FillMenu(1);
                CreateTopPanel();
                ShowShortCut(PubContext.Menus, PubContext.Menus);
            }
        }

        private void FillTree()
        {
            leftPanel = new frmMenu();
            leftPanel.Name = "leftPanel";
            leftPanel.AfterMenuTreeClickEvent += new AfterMenuTreeClickEventHandler(MenuClickEvent);
            leftPanel.AfterContentMenuClickEvent += new AfterContentMenuClickEventHandler(Toolbox_AfterContentMenuClickEvent);
            leftPanel.AfterFormCloseEvent += new AfterConfirmEventHandler(Toolbox_AfterFormCloseEvent);
            leftPanel.Show(this.dockPanel);
        }

        private void FillMenu(int index)
        {
            this.MainMenuStrip = null;
            if (this.Controls.Contains(mainMenu))
                this.Controls.Remove(mainMenu);
            mainMenu = new MenuStrip();
            mainMenu.LayoutStyle = ToolStripLayoutStyle.Flow;

            SystemMenu menu = new SystemMenu();
            menu.AfterMenuTreeClickEvent += new AfterMenuTreeClickEventHandler(MenuClickEvent);
            switch (index)
            {
                case 0:
                    menu.CreateMenu(mainMenu, null);
                    break;
                case 1:
                    menu.CreateMenu(mainMenu, null);
                    break;
            }
            mainMenu.Dock = DockStyle.Top;
            this.MainMenuStrip = mainMenu;
            this.Controls.Add(mainMenu);
        }

        void MenuClickEvent(object sender, string FullClassName, int FormModule, string FormText)
        {

            try
            {

                if (!string.IsNullOrEmpty(FullClassName))
                {

                    dockPanel.DocumentStyle = DevComponents.DotNetBar.DocumentStyle.DockingWindow;//恢复默认显示模式


                    System.Type type = System.Type.GetType(FullClassName);

                    Object obj = type.InvokeMember(null,

                    BindingFlags.DeclaredOnly |

                    BindingFlags.Public | BindingFlags.NonPublic |

                    BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);

                    type.InvokeMember("FormModule", BindingFlags.SetProperty, null, obj, new object[] { FormModule });

                    type.InvokeMember("FormText", BindingFlags.SetProperty, null, obj, new string[] { FormText });

                    ShowFormMoudle(obj);
                }
            }
            catch
            {
                MessageBox.Show("没有此模块对应功能","系统提示");

            }
        }

        void Toolbox_AfterContentMenuClickEvent(object sender, int ClickID, string MenuCode, string FullClassName, int FormModule, string FormText)
        {
            try
            {
                if (ClickID < 3)
                {
                    if (!IsExsitDocuments(ClickID))
                    {
                        if (!string.IsNullOrEmpty(FullClassName))
                        {
                            System.Type type = System.Type.GetType(FullClassName);

                            Object obj = type.InvokeMember(null,

                            BindingFlags.DeclaredOnly |

                            BindingFlags.Public | BindingFlags.NonPublic |

                            BindingFlags.Instance | BindingFlags.CreateInstance, null, null, null);

                            type.InvokeMember("FormModule", BindingFlags.SetProperty, null, obj, new object[] { FormModule });

                            type.InvokeMember("FormText", BindingFlags.SetProperty, null, obj, new string[] { FormText });

                            switch (ClickID)
                            {
                                case 1:
                                    dockPanel.DocumentStyle = DevComponents.DotNetBar.DocumentStyle.DockingWindow;
                                    ShowFormMoudle(obj);
                                    break;
                                case 2:
                                    dockPanel.DocumentStyle = DevComponents.DotNetBar.DocumentStyle.SystemMdi;
                                    ShowFormMoudle(obj);
                                    break;
                                case 3:
                                    break;
                            }
                        }
                    }
                }
                else if(ClickID==3)
                {
                    MenuData menu = PubContext.Menus.FirstOrDefault(c => c.Code == MenuCode);
                    if (menu !=null)
                    {
                        bool result = CreateShortCut(menu);
                        if (result)
                        {
                            user.InsertShortCust(menu);
                        }
                    }
                }
                else if (ClickID == 4)
                {
                    MenuData menu = PubContext.Menus.FirstOrDefault(c => c.Code == MenuCode);
                    if (menu !=null)
                    {
                        DeleteShortCut(menu);
                    }
                }
            }
            catch
            {
                MessageBox.Show("没有为该菜单绑定任何事件，请与系统设计人员联系.");

            }
        }

        private bool CreateShortCut(MenuData item)
        {
            SystemMenu menu = new SystemMenu();
            menu.AfterMenuTreeClickEvent += new AfterMenuTreeClickEventHandler(MenuClickEvent);
            return menu.CreateTool(this.middlePanel, item);
        }

        private void CreateShortCut(List<MenuData> menus)
        {
            if (menus == null && menus.Count <= 0)
                return;

            foreach (MenuData row in menus)
            {
                CreateShortCut(row);
            }
        }

        private bool DeleteShortCut(MenuData item)
        {
            SystemMenu menu = new SystemMenu();
            bool result = menu.DeleteTool(this.middlePanel, item);
            if (result)
            {
                try
                {
                    user.DeleteShortCust(item);
                    return true;
                }
                catch { }
            }

            return false;
        }

        private bool IsExsitDocuments(int ClickID)
        {
            bool canOpen = false;
            string showMsgEx = @"暂不支持页签\窗体混合显示模式!";
            string showMsg = string.Empty;
            switch (ClickID)
            {
                case 1:
                    foreach (Form form in MdiChildren)
                    {
                        canOpen = true;
                        showMsg = "系统已存在采用窗体显示的窗口，" + showMsgEx;
                        break;
                    }
                    break;
                case 2:

                    DevComponents.DotNetBar.IDockContent[] documents = dockPanel.DocumentsToArray();
                    foreach (DevComponents.DotNetBar.IDockContent content in documents)
                    {
                        canOpen = true;
                        showMsg = "系统已存在采用页签显示的窗口，" + showMsgEx;
                        break;
                    }
                    break;

            }
            if (!string.IsNullOrEmpty(showMsg))
                MessageBox.Show(showMsg);
            return canOpen;
        }

        private void ShowFormMoudle(object frm)
        {
            if (frm is BaseContentsForm)
            {
                BaseContentsForm baseForm = frm as BaseContentsForm;

                string formName = baseForm.Name;
                if (baseForm.FormModule > -1)
                    formName += baseForm.FormModule.ToString();
                if (!this.IsExistChildForm(formName)
                   || formName.Equals("frmSendRequest")) //20211015 add by shenbao 发送请求可以开多个窗体
               {
                    if (dockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.DockingWindow)
                    {
                        baseForm.Show(dockPanel);
                    }
                }
            }
            else if (frm is BaseWindowsForm)
            {
                BaseWindowsForm baseForm = frm as BaseWindowsForm;

                string formName = baseForm.Name;
                if (baseForm.FormModule > -1)
                    formName += baseForm.FormModule.ToString();
                if (!this.IsExistChildForm(formName))
                {
                    if (formName == "frmReLogin")
                    {
                        frmReLogin config = (frmReLogin)frm;
                        config.AfterSaveDataEvent -= new AfterSaveDataEventHandler(config_AfterSaveDataEvent);
                        config.AfterSaveDataEvent += new AfterSaveDataEventHandler(config_AfterSaveDataEvent);

                        if (dockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.DockingWindow)
                        {
                            baseForm.ShowDialog(this.dockPanel);
                        }
                    }
                    else
                    {
                        if (dockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.SystemMdi)
                        {
                            baseForm.MdiParent = this;
                            baseForm.BringToFront();
                            baseForm.Show(this);
                        }
                        else
                        {
                            baseForm.Show(dockPanel);
                        }
                    }
                }
            }
        }

        private void ShowShortCut(List<MenuData> fullMenus, List<MenuData> rightMenus)
        {
            if (Convert.ToInt32(PubContext.CurrentUser.ShortCutStyle) > 0)
            {
                if (!IsExistChildForm("frmShortCut"))
                {
                    shortCut = new frmShortCut(Convert.ToInt32(PubContext.CurrentUser.ShortCutStyle), fullMenus, rightMenus);
                    shortCut.AfterMenuTreeClickEvent += new AfterMenuTreeClickEventHandler(MenuClickEvent);
                    shortCut.FormClosed += shortCut_FormClosed;
                    //this.labStatus.Enabled = false;
                    ShowForm(shortCut);
                }
            }
        }

        void shortCut_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.labStatus.Enabled = true;
        }

        private void ShowForm(BaseForm frm)
        {
            string formName = frm.Name;
            if (frm.FormModule > -1)
                formName += frm.FormModule.ToString();
            if (!this.IsExistChildForm(formName))
            {
                if (dockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.SystemMdi)
                {
                    frm.MdiParent = this;
                    frm.BringToFront();
                    frm.Show(this);
                }
                else
                {
                    frm.Show(dockPanel);
                }
            }
        }

        void config_AfterSaveDataEvent(object sender, bool isSave)
        {
            if (isSave)
            {
                this.FormClosing -= new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
                this.Controls.Clear();
                this.Visible = true;
                CloseAllDocuments();
                InitializeComponent();
                childForms = new Hashtable();
                InitMainType();
            }
        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void CloseAllDocuments()
        {

            if (dockPanel.DocumentStyle == DevComponents.DotNetBar.DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {

                foreach (DevComponents.DotNetBar.IDockContent content in dockPanel.DocumentsToArray())
                {
                    content.DockHandler.Close();
                }
            }
        }

        private void RefreshTime()
        {
            timer = new Timer();

            timer.Interval = 1000;
            timer.Enabled = false;//不再使用
            timer.Tick += timer_Tick;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (this.middlePanel.Items.Count > 0)
                this.middlePanel.Items[this.middlePanel.Items.Count - 2].Text = " 欢迎 " + PubContext.logUser + "   登录时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (PubContext.Upgrade) {
                return;
            }
            string msg = "是否确定退出系统?";
            if (ShowMessage.ShowQuestion(msg) == DialogResult.No) {
                e.Cancel = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetToolStripStyle();
        }

        private void SetToolStripStyle()
        {
            if (PubContext.CurrentUser.UIStyleID != "9")
            {
                ToolStripManager.Renderer = new DevComponents.DotNetBar.Rendering.WindowsSevenRenderer();
            }
            else
            {

            }
        }
    }
}
