using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Glav.PasswordMgr.Engine;

namespace Glav.PasswordMgr
{
    public partial class frmMergeFiles : Form
    {
        private PasswordManagerContainer _pwdContainer = null;

        public frmMergeFiles()
        {
            InitializeComponent();
        }

        public frmMergeFiles(PasswordManagerContainer pwdContainer)
            : this()
        {
            _pwdContainer = pwdContainer;
            _pwdContainer.PasswordMerged += new PasswordMergedDelegate(_pwdContainer_PasswordMerged);
            _pwdContainer.PasswordMergeError += new PasswordMergedDelegate(_pwdContainer_PasswordMergeError);
        }

        void _pwdContainer_PasswordMergeError(object sender, PasswordMergedEventArgs e)
        {
            //MessageBox.Show(this, "Error performing merge: [" + e.Message + "]","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show(this, "Error performing merge. This can be caused by an incorrect passphrase or a badly formatted/corrupt password file", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void _pwdContainer_PasswordMerged(object sender, PasswordMergedEventArgs e)
        {
            progressBar.Value = e.PercentComplete;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog() == DialogResult.OK)
                txtFilename.Text = dlgOpen.FileName;
        }

        /// <summary>
        /// Clean up our event delegates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMergeFiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            _pwdContainer.PasswordMerged -= new PasswordMergedDelegate(_pwdContainer_PasswordMerged);
            _pwdContainer.PasswordMergeError -= new PasswordMergedDelegate(_pwdContainer_PasswordMergeError);
        }

        private void btnMerge_Click(object sender, EventArgs e)
        {
            int numRecords = 0;

            // Grab the passphrase first
            frmPassphraseEntry passEntry = new frmPassphraseEntry();
            if (passEntry.ShowDialog() == DialogResult.OK)
            {
                progressBar.Visible = true;
                System.Security.SecureString passphrase = passEntry.Passphrase;
                numRecords = _pwdContainer.DataMerge(txtFilename.Text, passphrase);
            }

            if (numRecords >= 0)
            {
                string msg = string.Format("Merge Process Complete. {0} Records merged.", numRecords);
                MessageBox.Show(this, msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(this, "No records merged.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}