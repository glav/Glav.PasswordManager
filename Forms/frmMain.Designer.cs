namespace Glav.PasswordMgr
{
    partial class frmMain
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
            if (disposing && (components != null))
            {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Security.SecureString secureString2 = new System.Security.SecureString();
            this.tlbarBtnSep3 = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnCopyPwd = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnPeek = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnFind = new System.Windows.Forms.ToolBarButton();
            this.tlbatBtnSep4 = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnExit = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnPassphrase = new System.Windows.Forms.ToolBarButton();
            this.tlbatBtnSep5 = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnSep2 = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnNew = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnOpen = new System.Windows.Forms.ToolBarButton();
            this.tlbarMain = new System.Windows.Forms.ToolBar();
            this.tlbarBtnSep0 = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnSep1 = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnAdd = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnDelete = new System.Windows.Forms.ToolBarButton();
            this.tlbarBtnSave = new System.Windows.Forms.ToolBarButton();
            this.imgMain = new System.Windows.Forms.ImageList();
            this.statMain = new System.Windows.Forms.StatusBar();
            this.menuAddEntry = new System.Windows.Forms.MenuItem();
            this.menuFileExit = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuDeleteEntry = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuFindEntry = new System.Windows.Forms.MenuItem();
            this.menuFindAgain = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuCopyPwd = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuFileNew = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuFileSave = new System.Windows.Forms.MenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuPreferences = new System.Windows.Forms.MenuItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuTools = new System.Windows.Forms.MenuItem();
            this.menuChgPassPhrase = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuFileMerge = new System.Windows.Forms.MenuItem();
            this.menuConvertFile = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon();
            this.ctxtMain = new System.Windows.Forms.ContextMenu();
            this.ctxtShow = new System.Windows.Forms.MenuItem();
            this.ctxtPrefs = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.ctxtExit = new System.Windows.Forms.MenuItem();
            this.dlgFile = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.opendlg = new System.Windows.Forms.OpenFileDialog();
            this.pnlMainDisplayContainer = new System.Windows.Forms.Panel();
            this.pnlPwdAndDetailContainer = new System.Windows.Forms.Panel();
            this.splitPwdAndDetailsSplitter = new System.Windows.Forms.SplitContainer();
            this.lstPasswords = new System.Windows.Forms.ListBox();
            this.txtPassword = new SecurePasswordTextBox.SecureTextBox();
            this.lblModifiedDateTime = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.RichTextBox();
            this.txtPwdTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlListDescContainer = new System.Windows.Forms.Panel();
            this.txtListDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlMainDisplayContainer.SuspendLayout();
            this.pnlPwdAndDetailContainer.SuspendLayout();
            this.splitPwdAndDetailsSplitter.Panel1.SuspendLayout();
            this.splitPwdAndDetailsSplitter.Panel2.SuspendLayout();
            this.splitPwdAndDetailsSplitter.SuspendLayout();
            this.pnlListDescContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlbarBtnSep3
            // 
            this.tlbarBtnSep3.Name = "tlbarBtnSep3";
            this.tlbarBtnSep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbarBtnCopyPwd
            // 
            this.tlbarBtnCopyPwd.ImageIndex = 5;
            this.tlbarBtnCopyPwd.Name = "tlbarBtnCopyPwd";
            this.tlbarBtnCopyPwd.Tag = "COPYPWD";
            this.tlbarBtnCopyPwd.Text = "Copy to Clipboard";
            this.tlbarBtnCopyPwd.ToolTipText = "Copies the password to the clipboard";
            // 
            // tlbarBtnPeek
            // 
            this.tlbarBtnPeek.ImageIndex = 8;
            this.tlbarBtnPeek.Name = "tlbarBtnPeek";
            this.tlbarBtnPeek.Tag = "PEEK";
            this.tlbarBtnPeek.Text = "Peek";
            this.tlbarBtnPeek.ToolTipText = "Peek at a hidden/obscured password.";
            // 
            // tlbarBtnFind
            // 
            this.tlbarBtnFind.ImageIndex = 9;
            this.tlbarBtnFind.Name = "tlbarBtnFind";
            this.tlbarBtnFind.Tag = "FIND";
            this.tlbarBtnFind.Text = "Find";
            this.tlbarBtnFind.ToolTipText = "Find an entry that contains a specific piece of text";
            // 
            // tlbatBtnSep4
            // 
            this.tlbatBtnSep4.Name = "tlbatBtnSep4";
            this.tlbatBtnSep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbarBtnExit
            // 
            this.tlbarBtnExit.ImageIndex = 7;
            this.tlbarBtnExit.Name = "tlbarBtnExit";
            this.tlbarBtnExit.Tag = "EXIT";
            this.tlbarBtnExit.Text = "  Exit  ";
            this.tlbarBtnExit.ToolTipText = "Exit the Application";
            // 
            // tlbarBtnPassphrase
            // 
            this.tlbarBtnPassphrase.ImageIndex = 6;
            this.tlbarBtnPassphrase.Name = "tlbarBtnPassphrase";
            this.tlbarBtnPassphrase.Tag = "PASSPHRASE";
            this.tlbarBtnPassphrase.Text = "Passphrase";
            this.tlbarBtnPassphrase.ToolTipText = "Change the passphrase of the currently loaded password list.";
            // 
            // tlbatBtnSep5
            // 
            this.tlbatBtnSep5.Name = "tlbatBtnSep5";
            this.tlbatBtnSep5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbarBtnSep2
            // 
            this.tlbarBtnSep2.Name = "tlbarBtnSep2";
            this.tlbarBtnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbarBtnNew
            // 
            this.tlbarBtnNew.ImageIndex = 0;
            this.tlbarBtnNew.Name = "tlbarBtnNew";
            this.tlbarBtnNew.Tag = "NEW";
            this.tlbarBtnNew.Text = "New";
            this.tlbarBtnNew.ToolTipText = "Create a new empty list of passwords.";
            // 
            // tlbarBtnOpen
            // 
            this.tlbarBtnOpen.ImageIndex = 1;
            this.tlbarBtnOpen.Name = "tlbarBtnOpen";
            this.tlbarBtnOpen.Tag = "OPEN";
            this.tlbarBtnOpen.Text = "Open";
            this.tlbarBtnOpen.ToolTipText = "Open an existing file";
            // 
            // tlbarMain
            // 
            this.tlbarMain.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.tlbarBtnSep0,
            this.tlbarBtnNew,
            this.tlbarBtnOpen,
            this.tlbarBtnSep1,
            this.tlbarBtnAdd,
            this.tlbarBtnDelete,
            this.tlbarBtnSave,
            this.tlbarBtnSep2,
            this.tlbarBtnPeek,
            this.tlbarBtnFind,
            this.tlbarBtnSep3,
            this.tlbarBtnCopyPwd,
            this.tlbatBtnSep4,
            this.tlbarBtnPassphrase,
            this.tlbatBtnSep5,
            this.tlbarBtnExit});
            this.tlbarMain.DropDownArrows = true;
            this.tlbarMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlbarMain.ImageList = this.imgMain;
            this.tlbarMain.Location = new System.Drawing.Point(0, 0);
            this.tlbarMain.Name = "tlbarMain";
            this.tlbarMain.ShowToolTips = true;
            this.tlbarMain.Size = new System.Drawing.Size(626, 41);
            this.tlbarMain.TabIndex = 0;
            this.tlbarMain.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tlbarMain_ButtonClick);
            this.tlbarMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tlbarMain_MouseDown);
            this.tlbarMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tlbarMain_MouseUp);
            // 
            // tlbarBtnSep0
            // 
            this.tlbarBtnSep0.Name = "tlbarBtnSep0";
            this.tlbarBtnSep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbarBtnSep1
            // 
            this.tlbarBtnSep1.Name = "tlbarBtnSep1";
            this.tlbarBtnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // tlbarBtnAdd
            // 
            this.tlbarBtnAdd.ImageIndex = 2;
            this.tlbarBtnAdd.Name = "tlbarBtnAdd";
            this.tlbarBtnAdd.Tag = "ADD";
            this.tlbarBtnAdd.Text = "Add";
            this.tlbarBtnAdd.ToolTipText = "Add a password entry to the list";
            // 
            // tlbarBtnDelete
            // 
            this.tlbarBtnDelete.ImageIndex = 3;
            this.tlbarBtnDelete.Name = "tlbarBtnDelete";
            this.tlbarBtnDelete.Tag = "DELETE";
            this.tlbarBtnDelete.Text = "Delete";
            this.tlbarBtnDelete.ToolTipText = "Delete a password entry from the list";
            // 
            // tlbarBtnSave
            // 
            this.tlbarBtnSave.ImageIndex = 4;
            this.tlbarBtnSave.Name = "tlbarBtnSave";
            this.tlbarBtnSave.Tag = "SAVE";
            this.tlbarBtnSave.Text = "Save";
            this.tlbarBtnSave.ToolTipText = "Saves the current list of passwords to a file";
            // 
            // imgMain
            // 
            this.imgMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgMain.ImageStream")));
            this.imgMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imgMain.Images.SetKeyName(0, "");
            this.imgMain.Images.SetKeyName(1, "");
            this.imgMain.Images.SetKeyName(2, "");
            this.imgMain.Images.SetKeyName(3, "");
            this.imgMain.Images.SetKeyName(4, "");
            this.imgMain.Images.SetKeyName(5, "");
            this.imgMain.Images.SetKeyName(6, "");
            this.imgMain.Images.SetKeyName(7, "");
            this.imgMain.Images.SetKeyName(8, "");
            this.imgMain.Images.SetKeyName(9, "");
            // 
            // statMain
            // 
            this.statMain.Location = new System.Drawing.Point(0, 351);
            this.statMain.Name = "statMain";
            this.statMain.Size = new System.Drawing.Size(626, 16);
            this.statMain.TabIndex = 9;
            // 
            // menuAddEntry
            // 
            this.menuAddEntry.Index = 0;
            this.menuAddEntry.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuAddEntry.Text = "&Add";
            this.menuAddEntry.Click += new System.EventHandler(this.menuAddEntry_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Index = 7;
            this.menuFileExit.Text = "E&xit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuAddEntry,
            this.menuDeleteEntry,
            this.menuItem7,
            this.menuFindEntry,
            this.menuFindAgain,
            this.menuItem4,
            this.menuCopyPwd,
            this.menuItem5});
            this.menuItem1.Text = "&Edit";
            // 
            // menuDeleteEntry
            // 
            this.menuDeleteEntry.Index = 1;
            this.menuDeleteEntry.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.menuDeleteEntry.Text = "&Delete";
            this.menuDeleteEntry.Click += new System.EventHandler(this.menuDeleteEntry_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Text = "-";
            // 
            // menuFindEntry
            // 
            this.menuFindEntry.Index = 3;
            this.menuFindEntry.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.menuFindEntry.Text = "&Find";
            this.menuFindEntry.Click += new System.EventHandler(this.menuFindEntry_Click);
            // 
            // menuFindAgain
            // 
            this.menuFindAgain.Index = 4;
            this.menuFindAgain.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.menuFindAgain.Text = "Find Again";
            this.menuFindAgain.Click += new System.EventHandler(this.menuFindAgain_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 5;
            this.menuItem4.Text = "-";
            // 
            // menuCopyPwd
            // 
            this.menuCopyPwd.Index = 6;
            this.menuCopyPwd.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuCopyPwd.Text = "Copy &Password to Clipboard";
            this.menuCopyPwd.Click += new System.EventHandler(this.menuCopyPwd_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 7;
            this.menuItem5.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 6;
            this.menuItem2.Text = "-";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Index = 0;
            this.menuFileNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuFileNew.Text = "&New";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 1;
            this.menuFileOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuFileOpen.Text = "&Open ...";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuItem9,
            this.menuPreferences,
            this.menuItem2,
            this.menuFileExit});
            this.menuFile.Text = "&File";
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 2;
            this.menuFileSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuFileSave.Text = "&Save";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Index = 3;
            this.menuFileSaveAs.Text = "Save &As...";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 4;
            this.menuItem9.Text = "-";
            // 
            // menuPreferences
            // 
            this.menuPreferences.Index = 5;
            this.menuPreferences.Text = "&Preferences";
            this.menuPreferences.Click += new System.EventHandler(this.menuPreferences_Click);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuItem1,
            this.menuTools,
            this.menuHelp});
            // 
            // menuTools
            // 
            this.menuTools.Index = 2;
            this.menuTools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuChgPassPhrase,
            this.menuItem6,
            this.menuFileMerge,
            this.menuConvertFile});
            this.menuTools.Text = "&Tools";
            // 
            // menuChgPassPhrase
            // 
            this.menuChgPassPhrase.Index = 0;
            this.menuChgPassPhrase.Text = "Chan&ge Passphrase";
            this.menuChgPassPhrase.Click += new System.EventHandler(this.menuChgPassPhrase_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "-";
            // 
            // menuFileMerge
            // 
            this.menuFileMerge.Index = 2;
            this.menuFileMerge.Text = "&Merge Password Files";
            this.menuFileMerge.Click += new System.EventHandler(this.menuFileMerge_Click);
            // 
            // menuConvertFile
            // 
            this.menuConvertFile.Index = 3;
            this.menuConvertFile.Text = "Con&vert old format file";
            this.menuConvertFile.Click += new System.EventHandler(this.menuConvertFile_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 3;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
            this.menuHelp.Text = "&Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 0;
            this.menuHelpAbout.Text = "&About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.ContextMenu = this.ctxtMain;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Password Manager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // ctxtMain
            // 
            this.ctxtMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.ctxtShow,
            this.ctxtPrefs,
            this.menuItem3,
            this.ctxtExit});
            // 
            // ctxtShow
            // 
            this.ctxtShow.Index = 0;
            this.ctxtShow.Text = "&Show";
            this.ctxtShow.Click += new System.EventHandler(this.ctxtShow_Click);
            // 
            // ctxtPrefs
            // 
            this.ctxtPrefs.Index = 1;
            this.ctxtPrefs.Text = "&Preferences";
            this.ctxtPrefs.Click += new System.EventHandler(this.ctxtPrefs_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // ctxtExit
            // 
            this.ctxtExit.Index = 3;
            this.ctxtExit.Text = "E&xit";
            this.ctxtExit.Click += new System.EventHandler(this.ctxtExit_Click);
            // 
            // dlgFile
            // 
            this.dlgFile.DefaultExt = "*.pgr";
            this.dlgFile.FileName = "Passwords";
            this.dlgFile.Filter = "Password Manager Files|*.pgr|All Files|*.*";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tlbarMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(626, 40);
            this.panel1.TabIndex = 7;
            // 
            // opendlg
            // 
            this.opendlg.DefaultExt = "*.pgr";
            this.opendlg.Filter = "Password Manager Files|*.pgr|All Files|*.*";
            // 
            // pnlMainDisplayContainer
            // 
            this.pnlMainDisplayContainer.Controls.Add(this.pnlPwdAndDetailContainer);
            this.pnlMainDisplayContainer.Controls.Add(this.pnlListDescContainer);
            this.pnlMainDisplayContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainDisplayContainer.Location = new System.Drawing.Point(0, 40);
            this.pnlMainDisplayContainer.Name = "pnlMainDisplayContainer";
            this.pnlMainDisplayContainer.Size = new System.Drawing.Size(626, 311);
            this.pnlMainDisplayContainer.TabIndex = 10;
            // 
            // pnlPwdAndDetailContainer
            // 
            this.pnlPwdAndDetailContainer.Controls.Add(this.splitPwdAndDetailsSplitter);
            this.pnlPwdAndDetailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPwdAndDetailContainer.Location = new System.Drawing.Point(0, 39);
            this.pnlPwdAndDetailContainer.Name = "pnlPwdAndDetailContainer";
            this.pnlPwdAndDetailContainer.Size = new System.Drawing.Size(626, 272);
            this.pnlPwdAndDetailContainer.TabIndex = 1;
            // 
            // splitPwdAndDetailsSplitter
            // 
            this.splitPwdAndDetailsSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitPwdAndDetailsSplitter.Location = new System.Drawing.Point(0, 0);
            this.splitPwdAndDetailsSplitter.Name = "splitPwdAndDetailsSplitter";
            // 
            // splitPwdAndDetailsSplitter.Panel1
            // 
            this.splitPwdAndDetailsSplitter.Panel1.Controls.Add(this.lstPasswords);
            // 
            // splitPwdAndDetailsSplitter.Panel2
            // 
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.txtPassword);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.lblModifiedDateTime);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.label10);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.label9);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.txtComments);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.txtPwdTitle);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.label6);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.txtUrl);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.label5);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.txtUserID);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.label3);
            this.splitPwdAndDetailsSplitter.Panel2.Controls.Add(this.label4);
            this.splitPwdAndDetailsSplitter.Size = new System.Drawing.Size(626, 272);
            this.splitPwdAndDetailsSplitter.SplitterDistance = 240;
            this.splitPwdAndDetailsSplitter.TabIndex = 0;
            // 
            // lstPasswords
            // 
            this.lstPasswords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstPasswords.FormattingEnabled = true;
            this.lstPasswords.Location = new System.Drawing.Point(0, 0);
            this.lstPasswords.Name = "lstPasswords";
            this.lstPasswords.Size = new System.Drawing.Size(240, 272);
            this.lstPasswords.Sorted = true;
            this.lstPasswords.TabIndex = 0;
            this.lstPasswords.SelectedIndexChanged += new System.EventHandler(this.lstPasswords_SelectedIndexChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(87, 99);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.SecureText = secureString2;
            this.txtPassword.ShowDialogWhenPasting = false;
            this.txtPassword.Size = new System.Drawing.Size(261, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lblModifiedDateTime
            // 
            this.lblModifiedDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifiedDateTime.Location = new System.Drawing.Point(88, 242);
            this.lblModifiedDateTime.Name = "lblModifiedDateTime";
            this.lblModifiedDateTime.Size = new System.Drawing.Size(260, 16);
            this.lblModifiedDateTime.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 242);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Last Modified:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Comments:";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(87, 155);
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(254, 77);
            this.txtComments.TabIndex = 4;
            this.txtComments.Text = "";
            // 
            // txtPwdTitle
            // 
            this.txtPwdTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPwdTitle.Location = new System.Drawing.Point(8, 35);
            this.txtPwdTitle.Name = "txtPwdTitle";
            this.txtPwdTitle.Size = new System.Drawing.Size(340, 20);
            this.txtPwdTitle.TabIndex = 0;
            this.txtPwdTitle.Leave += new System.EventHandler(this.txtPwdTitle_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Password Title/Name:";
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(87, 125);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(261, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(49, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "URL:";
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.Location = new System.Drawing.Point(87, 72);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(261, 20);
            this.txtUserID.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "User ID:";
            // 
            // pnlListDescContainer
            // 
            this.pnlListDescContainer.Controls.Add(this.txtListDescription);
            this.pnlListDescContainer.Controls.Add(this.label2);
            this.pnlListDescContainer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlListDescContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlListDescContainer.Name = "pnlListDescContainer";
            this.pnlListDescContainer.Size = new System.Drawing.Size(626, 39);
            this.pnlListDescContainer.TabIndex = 0;
            // 
            // txtListDescription
            // 
            this.txtListDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtListDescription.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtListDescription.Location = new System.Drawing.Point(108, 9);
            this.txtListDescription.Name = "txtListDescription";
            this.txtListDescription.Size = new System.Drawing.Size(497, 20);
            this.txtListDescription.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "List Description:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 367);
            this.Controls.Add(this.pnlMainDisplayContainer);
            this.Controls.Add(this.statMain);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mainMenu1;
            this.Name = "frmMain";
            this.Text = "Password Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.frmMain_Layout);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlMainDisplayContainer.ResumeLayout(false);
            this.pnlPwdAndDetailContainer.ResumeLayout(false);
            this.splitPwdAndDetailsSplitter.Panel1.ResumeLayout(false);
            this.splitPwdAndDetailsSplitter.Panel2.ResumeLayout(false);
            this.splitPwdAndDetailsSplitter.Panel2.PerformLayout();
            this.splitPwdAndDetailsSplitter.ResumeLayout(false);
            this.pnlListDescContainer.ResumeLayout(false);
            this.pnlListDescContainer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolBarButton tlbarBtnSep3;
        private System.Windows.Forms.ToolBarButton tlbarBtnCopyPwd;
        private System.Windows.Forms.ToolBarButton tlbarBtnPeek;
        private System.Windows.Forms.ToolBarButton tlbarBtnFind;
        private System.Windows.Forms.ToolBarButton tlbatBtnSep4;
        private System.Windows.Forms.ToolBarButton tlbarBtnExit;
        private System.Windows.Forms.ToolBarButton tlbarBtnPassphrase;
        private System.Windows.Forms.ToolBarButton tlbatBtnSep5;
        private System.Windows.Forms.ToolBarButton tlbarBtnSep2;
        private System.Windows.Forms.ToolBarButton tlbarBtnNew;
        private System.Windows.Forms.ToolBarButton tlbarBtnOpen;
        private System.Windows.Forms.ToolBar tlbarMain;
        private System.Windows.Forms.ToolBarButton tlbarBtnSep0;
        private System.Windows.Forms.ToolBarButton tlbarBtnSep1;
        private System.Windows.Forms.ToolBarButton tlbarBtnAdd;
        private System.Windows.Forms.ToolBarButton tlbarBtnDelete;
        private System.Windows.Forms.ToolBarButton tlbarBtnSave;
        private System.Windows.Forms.ImageList imgMain;
        private System.Windows.Forms.StatusBar statMain;
        private System.Windows.Forms.MenuItem menuAddEntry;
        private System.Windows.Forms.MenuItem menuFileExit;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuDeleteEntry;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuFindEntry;
        private System.Windows.Forms.MenuItem menuFindAgain;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuCopyPwd;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuFileNew;
        private System.Windows.Forms.MenuItem menuFileOpen;
        private System.Windows.Forms.MenuItem menuFile;
        private System.Windows.Forms.MenuItem menuFileSave;
        private System.Windows.Forms.MenuItem menuFileSaveAs;
        private System.Windows.Forms.MenuItem menuItem9;
        private System.Windows.Forms.MenuItem menuPreferences;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuTools;
        private System.Windows.Forms.MenuItem menuChgPassPhrase;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem menuFileMerge;
        private System.Windows.Forms.MenuItem menuHelp;
        private System.Windows.Forms.MenuItem menuHelpAbout;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenu ctxtMain;
        private System.Windows.Forms.MenuItem ctxtShow;
        private System.Windows.Forms.MenuItem ctxtPrefs;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem ctxtExit;
        private System.Windows.Forms.SaveFileDialog dlgFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.OpenFileDialog opendlg;
        private System.Windows.Forms.Panel pnlMainDisplayContainer;
        private System.Windows.Forms.Panel pnlListDescContainer;
        private System.Windows.Forms.TextBox txtListDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlPwdAndDetailContainer;
        private System.Windows.Forms.SplitContainer splitPwdAndDetailsSplitter;
        private System.Windows.Forms.ListBox lstPasswords;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtComments;
        private System.Windows.Forms.TextBox txtPwdTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblModifiedDateTime;
        private System.Windows.Forms.Label label10;
        private SecurePasswordTextBox.SecureTextBox txtPassword;
        private System.Windows.Forms.MenuItem menuConvertFile;
    }
}