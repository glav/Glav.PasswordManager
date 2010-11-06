using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Glav.PasswordMgr.Engine;
using Glav.PasswordMgr.Engine.Globals;
using Glav.PasswordMgr.Engine.Configuration;

namespace Glav.PasswordMgr
{
    public partial class frmMain : Form
    {
        #region Private fields

        private PasswordManagerContainer _pwdContainer = new PasswordManagerContainer();
        private bool _dataChanged = false;
        private string _searchText = null;
        private PasswordEntry _searchEntry = null;
        private frmPeekWindow _peekWindow = null;

        private BindingSource _bs = new BindingSource();
        #endregion


        #region Constructor

        public frmMain()
        {
            InitializeComponent();
        }

        #endregion

        #region Form Event handlers

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            UpdateCurrentEntry();
            if (! string.IsNullOrEmpty(_pwdContainer.Filename))
                SaveFile(null);
            else
            {
                if (dlgFile.ShowDialog() == DialogResult.OK)
                    SaveFile(dlgFile.FileName);
            }
        }

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            ClearAllData();
        }

        private void menuAddEntry_Click(object sender, EventArgs e)
        {
            AddNewEntry();
        }

        private void lstPasswords_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFormDetails();


            ////////////////////////////
            //HACK: TO TEST DATABINDING
            ////////////////////////////
            _pwdContainer.FindEntry((string)lstPasswords.SelectedItem);
        }

        private void txtPwdTitle_Leave(object sender, EventArgs e)
        {
            if (lstPasswords.Items.Count > 0 && ((string)lstPasswords.Items[lstPasswords.SelectedIndex]) != txtPwdTitle.Text)
            {
                string title = txtPwdTitle.Text;

                UpdateCurrentEntry();
                RefreshPasswordList();
                // Now that we have updated our main password list, we need to locate where in the list it is and reselect it, otherwise
                // we will be positioned on a potentially different password because of the sorting within the list
                int index = lstPasswords.FindStringExact(title);
                lstPasswords.SelectedIndex = index;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool closeForm = CanClearData("exit");
            e.Cancel = !closeForm;

            if (this.WindowState != FormWindowState.Minimized)
            {
                ConfigMgr.PositionLeft = this.Left;
                ConfigMgr.PositionTop = this.Top;
                ConfigMgr.SizeWidth = this.Width;
                ConfigMgr.SizeHeight = this.Height;
                try
                {
                    ConfigMgr.Save();
                }
                catch (Exception ex)
                {
                    string msg = string.Format("Unable to save Configuration data. [{0}]", ex.Message);
                    MessageBox.Show(this, msg, "Error saving configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (closeForm)
                _pwdContainer.Dispose();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ////////////////////////////
            //HACK: TO TEST DATABINDING
            ////////////////////////////
            RefreshPasswordBindings();
            ////////////////////////////
            //HACK: TO TEST DATABINDING
            ////////////////////////////



            EnableFormEntryFields(false);

            CheckCommandLineArguments();

            try
            {
                ConfigMgr.Load();
            }
            catch (Exception ex)
            {
                string msg = string.Format("Unable to Load Configuration data. [{0}]",ex.Message);
                MessageBox.Show(this, msg, "Error loading configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Left = ConfigMgr.PositionLeft;
            this.Top = ConfigMgr.PositionTop;
            this.Width = ConfigMgr.SizeWidth;
            this.Height = ConfigMgr.SizeHeight;

            EnableAvailableMenuOptions();
        }

        /// <summary>
        /// Setup the bindings for the password data to our form fields.
        /// </summary>
        private void RefreshPasswordBindings()
        {
            _bs.DataSource = _pwdContainer;

            txtComments.DataBindings.Add("Text", _bs, "CurrentComment");
            txtPwdTitle.DataBindings.Add("Text", _bs, "CurrentTitle");
            txtUserID.DataBindings.Add("Text", _bs, "CurrentUserID");
            txtUrl.DataBindings.Add("Text", _bs, "CurrentUrl");
            txtPassword.DataBindings.Add("SecureText", _bs, "CurrentPasswordData");
            txtListDescription.DataBindings.Add("Text", _bs, "ListTitle");
            statMain.DataBindings.Add("Text", _bs, "NumberOfPasswords", true, DataSourceUpdateMode.Never, 0,
                                      "Current Number of passwords: 0");
        }

        private void menuChgPassPhrase_Click(object sender, EventArgs e)
        {
            ChangePassphrase();
        }

        private void menuDeleteEntry_Click(object sender, EventArgs e)
        {
            DeleteEntry();
        }

        private void menuFindEntry_Click(object sender, EventArgs e)
        {
            FindText();
        }

        private void menuFindAgain_Click(object sender, EventArgs e)
        {
            FindEntry(true);
        }

        private void menuConvertFile_Click(object sender, EventArgs e)
        {
            using (frmConvertOldFile frmOldFile = new frmConvertOldFile())
            {
                frmOldFile.ShowDialog(this);
            }
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            if (dlgFile.ShowDialog() == DialogResult.OK)
                SaveFile(dlgFile.FileName);

        }

        private void menuCopyPwd_Click(object sender, EventArgs e)
        {
            CopyCurrentPasswordToClipboard();
        }

        #region PasswordWindow Peek Events
        private void tlbarMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (_pwdContainer.PasswordList.Length > 0)
            {
                if (e.X > tlbarBtnPeek.Rectangle.X &&
                    e.X < tlbarBtnPeek.Rectangle.Right &&
                    e.Y > tlbarBtnPeek.Rectangle.Y &&
                    e.Y < tlbarBtnPeek.Rectangle.Bottom)
                {
                    // SHow the peek window
                    _peekWindow = new frmPeekWindow(MousePosition.X - e.X, MousePosition.Y + 5);
                    PasswordEntry currPwd = _pwdContainer.GetEntry(lstPasswords.SelectedItem.ToString());
                    if (currPwd != null)
                    {
                        byte[] pwdData = Glav.PasswordMgr.Engine.Crypto.CryptoUtility.SecureStringToByteArray(currPwd.PasswordData);
                        _peekWindow.DisplayData = pwdData;
                        _peekWindow.Show(this);
                    }
                }
            }
        }

        private void tlbarMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (_peekWindow != null)
                _peekWindow.Dispose();
        }
        #endregion

        private void menuFileMerge_Click(object sender, EventArgs e)
        {
            DialogResult dlg;
            using (frmMergeFiles mergeForm = new frmMergeFiles(_pwdContainer))
            {
                dlg = mergeForm.ShowDialog();
            }
            
            if (dlg == DialogResult.OK)
                RefreshPasswordList();
            
        }

        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            frmHelpAbout helpForm = new frmHelpAbout();
            helpForm.ShowDialog();
            helpForm.Dispose();
        }

        private void menuPreferences_Click(object sender, EventArgs e)
        {
            using (frmPreferences prefs = new frmPreferences())
            {
                prefs.ShowDialog();
            }
        }
        private void frmMain_Layout(object sender, LayoutEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                this.ShowInTaskbar = false;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowForm();
        }
        private void ctxtShow_Click(object sender, EventArgs e)
        {
            ShowForm();
        }

        private void ctxtPrefs_Click(object sender, EventArgs e)
        {
            using (frmPreferences prefs = new frmPreferences())
            {
                prefs.ShowDialog();
            }
        }
        private void ctxtExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }
        #endregion

        #region Generic Action methods - abstracted UI methods - called from menu or action bar

        #region ExitApplication
        /// <summary>
        /// Just exits the application.
        /// </summary>
        private void ExitApplication()
        {
            //if (CanClearData("exit"))
                Application.Exit();
        }
        #endregion

        #region CanClearData
        /// <summary>
        /// Checks if the form/application can close. If there have been changes, make sure the user is aware of this.
        /// </summary>
        /// <returns></returns>
        private bool CanClearData(string prompt)
        {
            bool canExit = true;
            if (_pwdContainer.HasChanged)
            {
                string msg = string.Format("You have not saved your changes. Are you sure you want to {0}?",prompt);
                DialogResult dr = MessageBox.Show(this, msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                canExit = (dr == DialogResult.Yes);
            }
            return canExit;
        }
        #endregion

        #region ClearForm

        private void ClearForm()
        {
            txtPwdTitle.Text = string.Empty;
            txtUserID.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtComments.Text = string.Empty;

            //TODO: Need to change this control into something that can represent passwords without using a managed string instance
            txtPassword.Text = "";
        }

        #endregion

        #region OpenFile

        private void OpenFile()
        {
            if (_pwdContainer.HasChanged)
            {
                DialogResult dr = MessageBox.Show("The file has been changed, but not saved yet. Loading a new file will lose your changes. Are you sure you want to continue to load a new file?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No || dr == DialogResult.Cancel)
                    return;
            }

            if (opendlg.ShowDialog() == DialogResult.OK)
            {
                OpenFile(opendlg.FileName);
            }
        }

        private void OpenFile(string filename)
        {
            try
            {
                // Ask for the passphrase
                frmPassphraseEntry pFrm = new frmPassphraseEntry();
                if (pFrm.ShowDialog() == DialogResult.OK)
                {
                    _pwdContainer.Passphrase = pFrm.Passphrase;
                    pFrm.Dispose();

                    _pwdContainer.LoadFile(filename);
                    RefreshPasswordList();
                    EnableFormEntryFields(true);
                }

                EnableAvailableMenuOptions();

            }
            catch (Exception ex)
            {
                HandleError("Error loading data file", ex);
            }
        }

        #endregion

        #region SaveFile

        private void SaveFile(string filename)
        {
            try
            {
                try
                {
                    if (string.IsNullOrEmpty(filename))
                        _pwdContainer.SaveFile();
                    else
                        _pwdContainer.SaveFile(filename);
                    this.Text = _pwdContainer.Filename;

                    MessageBox.Show(this, "File Saved Successfully.", "Save Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (PasswordMgr.Engine.Exceptions.PasswordCryptoException pcex)
                {
                    MessageBox.Show(this, "No passphrase has been set. Please make sure you set a passphrase before saving your data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                HandleError("Unable to Save File", ex);
            }
        }

        #endregion

        #region RefreshPasswordList
        /// <summary>
        /// Add all the password entries to our listbox and initialise the display.
        /// </summary>
        private void RefreshPasswordList()
        {
            lstPasswords.Items.Clear();
            ClearForm();

            foreach (PasswordEntry entry in _pwdContainer.PasswordList)
                lstPasswords.Items.Add(entry.Title);

            txtListDescription.Text = _pwdContainer.ListTitle;
            this.Text = _pwdContainer.Filename;

            if (lstPasswords.Items.Count > 0)
            {
                lstPasswords.SelectedIndex = 0;
                EnableFormEntryFields(true);
            }
            else
                EnableFormEntryFields(false);
            lstPasswords.Focus();
            EnableAvailableMenuOptions();

            statMain.Text = string.Format("Number of Passwords: {0}", _pwdContainer.NumberOfPasswords);
        }
        #endregion

        #region ClearAlData

        private void ClearAllData()
        {
            if (CanClearData("clear all data"))
            {
                _pwdContainer.ClearAll();
                ClearForm();
                txtListDescription.Text = "";
                lstPasswords.Items.Clear();
                this.Text = "";
                EnableFormEntryFields(false);
                EnableAvailableMenuOptions();
            }
        }

        #endregion

        #region AddNewEntry

        private void AddNewEntry()
        {
            frmNewEntry newEntry = new frmNewEntry();
            if (newEntry.ShowDialog(this) == DialogResult.OK)
            {
                if (_pwdContainer.GetEntry(newEntry.NewPasswordDescription) != null)
                {
                    MessageBox.Show(this, "A password entry with that title/description already exists.", "Error - Duplicate entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                    _pwdContainer.AddEntry(newEntry.NewPasswordDescription, string.Empty, string.Empty, string.Empty, new System.Security.SecureString());
                    RefreshPasswordList();
                    EnableFormEntryFields(true);
                    int pos = lstPasswords.FindStringExact(newEntry.NewPasswordDescription);
                    if (pos >= 0)
                    {
                        lstPasswords.SelectedIndex = pos;
                        txtUserID.Focus();
                    }
                    //txtPwdTitle.Focus();
                    //txtPwdTitle.SelectAll();
                }
            }
        }

        #endregion

        #region DeleteEntry
        /// <summary>
        /// Deletes a password entry from the list and refreshes the display
        /// </summary>
        private void DeleteEntry()
        {
            if (lstPasswords.SelectedIndex >= 0)
            {
                string entry = lstPasswords.SelectedItem.ToString();
                string msg = string.Format("Are you sure you wish to delete entry: '{0}'?", entry);
                DialogResult dr = MessageBox.Show(this, msg, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    _pwdContainer.DeleteEntry(entry);
                    RefreshPasswordList();
                }
            }
        }
        #endregion

        #region ChangePassphrase

        private void ChangePassphrase()
        {
            frmPassphraseEntry frm = new frmPassphraseEntry();
            frm.Tag = "Set or Change Passphrase";
            frm.SingleEntry = false;
            if (frm.ShowDialog() == DialogResult.OK)
                _pwdContainer.Passphrase = frm.Passphrase;
        }

        #endregion

        #region FindEntry - Start search or continue search
        private void FindText()
        {
            if (_pwdContainer.PasswordList.Length > 0)
            {
                using (frmFindEntry findForm = new frmFindEntry())
                {
                    if (findForm.ShowDialog() == DialogResult.OK)
                    {
                        _searchText = findForm.SearchText;
                        FindEntry(false);
                    }
                }
            }
        }

        private bool FindEntry(bool continueSearch)
        {
            bool fndResult = false;
            if (_searchText != null)
            {
                PasswordEntry entry;
                if (continueSearch)
                    entry = _pwdContainer.FindEntry(_searchText, _searchEntry);
                else
                    entry = _pwdContainer.FindEntry(_searchText);
                if (entry != null)
                {
                    fndResult = true;
                    _searchEntry = entry;
                    LocateDisplayItem(entry);
                } else
                {
                    MessageBox.Show("Search text could not be found.", "Search Result", MessageBoxButtons.OK,
                                    MessageBoxIcon.Hand);
                }
            }
            return fndResult;
        }
        #endregion

        #region CopyCurrentPasswordToClipboard
        public void CopyCurrentPasswordToClipboard()
        {
            PasswordEntry current = _pwdContainer.GetEntry(lstPasswords.SelectedItem.ToString());
            string pwd = System.Text.UTF8Encoding.UTF8.GetString(Glav.PasswordMgr.Engine.Crypto.CryptoUtility.SecureStringToByteArray(current.PasswordData));
            Clipboard.SetDataObject(pwd, false);

            MessageBox.Show(this, "Password has been copied to the clipboard. Note: This is an unsafe operation as the password is now in memory in clear text", "Warning/Information",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        #endregion

        #region Show Form (typically after its minimsed and hidden in the tray)
        /// <summary>
        /// Shows the form and ensures we can see it in the System tray
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowForm()
        {
            WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        #endregion

        #region EnableAvailableMenuOptions
        /// <summary>
        /// Enable on the applicable menu options.
        /// </summary>
        private void EnableAvailableMenuOptions()
        {
            bool enabled = (lstPasswords.Items.Count > 0);

            menuFileSave.Enabled = enabled;
            menuFileSaveAs.Enabled = enabled;
            menuDeleteEntry.Enabled = enabled;
            menuFindAgain.Enabled = enabled;
            menuFindEntry.Enabled = enabled;
            menuCopyPwd.Enabled = enabled;
            menuChgPassPhrase.Enabled = enabled;
            menuFileMerge.Enabled = enabled;
        }
        #endregion

        #endregion

        #region HandleError utility methods

        private void HandleError(Exception ex)
        {
            HandleError(null, ex);
        }

        private void HandleError(string message, Exception ex)
        {
            string displayMsg = null;
            if (message != null && message != string.Empty)
                displayMsg = string.Format("{0} \n{1}", message, ex.Message);
            else
                displayMsg = string.Format("Error! \n{0}", ex.Message);

            MessageBox.Show(displayMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        #endregion

        #region UpdateCurrentEntry

        /// <summary>
        /// Updates the current entry (the one displayed on screen) in the internal password list.
        /// This synchronises the internal entry with the entry displayed on screen.
        /// </summary>
        private void UpdateCurrentEntry()
        {
            if (_dataChanged && _pwdContainer.PasswordList.Length > 0)
                _pwdContainer.UpdateEntry(lstPasswords.SelectedItem.ToString(), txtPwdTitle.Text, txtUserID.Text, txtUrl.Text, txtPassword.SecureText, txtComments.Text);
            _dataChanged = false;
        }

        #endregion

        #region UpdateFormDetails

        private void UpdateFormDetails()
        {
            ////////////////////////////
            //HACK: TO TEST DATABINDING
            ////////////////////////////
            return;

            
            PasswordEntry entry = _pwdContainer.GetEntry(lstPasswords.SelectedItem.ToString());
            txtPwdTitle.Text = entry.Title;
            txtUserID.Text = entry.UserID;
            txtUrl.Text = entry.Url;
            txtPassword.SecureText = entry.PasswordData;
            txtComments.Text = entry.Comment;
            lblModifiedDateTime.Text = entry.ModifiedDateTime.ToShortTimeString() + " " + entry.ModifiedDateTime.ToShortDateString();
        }

        #endregion

        #region EnableFormEntryFields
        /// <summary>
        /// Disables or enables the entry fields on the form
        /// </summary>
        /// <param name="enableFields"></param>
        private void EnableFormEntryFields(bool enableFields)
        {
            lstPasswords.Enabled = enableFields;
            txtComments.Enabled = enableFields;
            txtListDescription.Enabled = enableFields;
            txtPassword.Enabled = enableFields;
            txtPwdTitle.Enabled = enableFields;
            txtUrl.Enabled = enableFields;
            txtUserID.Enabled = enableFields;
        }

        #endregion

        #region Toolbar Button Click handler

        private void tlbarMain_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString())
            {
                case "NEW":
                    ClearAllData();
                    break;
                case "SAVE":
                    SaveFile(null);
                    break;
                case "ADD":
                    AddNewEntry();
                    break;
                case "DELETE":
                    DeleteEntry();
                    break;
                case "PEEK":
                    // This button is catered for in the 'MouseDown' & 'MouseUp' event.
                    break;
                case "FIND":
                    FindText();
                    break;
                case "COPYPWD":
                    CopyCurrentPasswordToClipboard();
                    break;
                case "PASSPHRASE":
                    ChangePassphrase();
                    break;
                case "OPEN":
                    OpenFile();
                    break;
                case "EXIT":
                    ExitApplication();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region LocateDisplayItem

        private void LocateDisplayItem(string title)
        {
            if (title != null)
            {
                int pos = lstPasswords.FindString(title);
                if (pos >= 0)
                {
                    lstPasswords.SelectedIndex = pos;
                    UpdateFormDetails();
                }
            }
        }
        private void LocateDisplayItem(PasswordEntry pwdEntry)
        {
            if (pwdEntry != null)
                LocateDisplayItem(pwdEntry.Title);
        }
        #endregion

        #region CheckCommandLineArguments

        /// <summary>
        /// Check if there were was a filename specified as a command line argument. If so, then try and load it.
        /// </summary>
        private void CheckCommandLineArguments()
        {
			// Did we specify a file to load on the command line?
			string[] cmdline = Environment.GetCommandLineArgs();
			if (cmdline.Length > 1)
			{
                // make sure the file specified is valid
                string filename = cmdline[1];
                if (System.IO.File.Exists(filename))
                {
                    OpenFile(filename);
                }
                else
                {
                    MessageBox.Show(this, "The filename specified on the command line was not found.", "Error - File not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
        }

        #endregion



    }
}