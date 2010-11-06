using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Glav.PasswordMgr
{
    public partial class frmConvertOldFile : Form
    {
        public frmConvertOldFile()
        {
            InitializeComponent();
        }

        #region Form General Events

        private void btnBrowseRead_Click(object sender, EventArgs e)
        {
            if (txtReadFile.Text != string.Empty)
                dlgReadFile.FileName = txtReadFile.Text;

            if (dlgReadFile.ShowDialog() == DialogResult.OK)
                txtReadFile.Text = dlgReadFile.FileName;
        }

        private void btnBrowseWrite_Click(object sender, EventArgs e)
        {
            if (txtWriteFile .Text != string.Empty)
                dlgWriteFile.FileName = txtWriteFile.Text;

            if (dlgWriteFile.ShowDialog() == DialogResult.OK)
                txtWriteFile.Text = dlgWriteFile.FileName;

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (txtReadFile.Text == string.Empty || txtWriteFile.Text == string.Empty)
            {
                MessageBox.Show(this, "You must specify a file to read/convert and a file to write to", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Get the passphrase
                frmPassphraseEntry frmPhrase = new frmPassphraseEntry();
                frmPhrase.SingleEntry = false;
                if (frmPhrase.ShowDialog(this) == DialogResult.OK)
                    ConvertFile(txtReadFile.Text, txtWriteFile.Text, frmPhrase.Passphrase);
            }
        }

        #endregion

        #region ConvertFile

        private void ConvertFile(string readFile, string writeFile, System.Security.SecureString passphrase )
        {
            grpFileDetails.Enabled = false;
            btnCancel.Enabled = false;
            btnConvert.Enabled = false;

            try
            {
                PasswordMgr.Engine.PasswordContainer oldContainer = new Glav.PasswordMgr.Engine.PasswordContainer();
                PasswordMgr.Engine.PasswordManagerContainer newContainer = new Glav.PasswordMgr.Engine.PasswordManagerContainer();

                progBar.Value = 0;
                progBar.Maximum = 100;

                // Setup the old container

                byte[] passData = PasswordMgr.Engine.Crypto.CryptoUtility.SecureStringToByteArray(passphrase);
                oldContainer.Passphrase = System.Text.ASCIIEncoding.ASCII.GetString(passData);
                oldContainer.LoadFromFile(readFile);

                newContainer.Passphrase = passphrase;
                newContainer.ListTitle = oldContainer.ContainerDescription;

                for (int cnt = 0; cnt < oldContainer.Passwords.Count; cnt++)
                {
                    System.Security.SecureString secStr = new System.Security.SecureString();
                    string tmpPwd = (string)oldContainer.Passwords[cnt];
                    for (int l = 0; l < tmpPwd.Length; l++)
                        secStr.AppendChar(tmpPwd[l]);
                    newContainer.AddEntry((string)oldContainer.PasswordDescriptions[cnt], (string)oldContainer.UserIDs[cnt], string.Empty,
                        string.Empty, secStr);

                    UpdateProgressBar(oldContainer.Passwords.Count+1, cnt+1);  // The +1 is to prevent passing zero 
                }

                newContainer.SaveFile(writeFile);

                UpdateProgressBar(oldContainer.Passwords.Count+1, oldContainer.Passwords.Count+1);

                MessageBox.Show(this, "Conversion completed Successfully", "Conversion Done.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                progBar.Value = 0;

                txtReadFile.Text = string.Empty;
                txtWriteFile.Text = string.Empty;
            }
            catch
            {
                MessageBox.Show(this, "You possibly entered an incorrect passphrase. Unable to decrypt the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                grpFileDetails.Enabled = true;
                btnCancel.Enabled = true;
                btnConvert.Enabled = true;
            }
        }

        #endregion

        #region UpdateProgressBar

        private void UpdateProgressBar(int totalCount, int currentRecord)
        {
            int percentage = (int)((float)(currentRecord / totalCount) * 100);
            progBar.Value = percentage;
            progBar.Refresh();
        }

        #endregion
    }
}