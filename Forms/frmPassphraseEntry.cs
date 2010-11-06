using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security;

namespace Glav.PasswordMgr
{
    public partial class frmPassphraseEntry : Form
    {
        #region Private fields

        private bool _singleEntry = true;

        #endregion

        #region Constructor

        public frmPassphraseEntry()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Determines whether only single entry is required for a password. Setting this value to true will cause the
        /// Passphrase re-enter field and label to be invisible
        /// </summary>
        public bool SingleEntry
        {
            get { return _singleEntry; }
            set { _singleEntry = value; }
        }

        public SecureString Passphrase
        {
            get { return txtEntry.SecureText; }
        }

        #endregion

        #region Form events

        private void frmPassphraseEntry_Load(object sender, EventArgs e)
        {
            if (_singleEntry)
            {
                lblReEnter.Visible = false;
                txtReEntry.Visible = false;
            }
        }


        private void btnOk_Click(object sender, EventArgs e)
        {
            char[] pwd1 = txtEntry.CharacterData;
            char[] pwd2 = txtReEntry.CharacterData;
            bool pwdsSame = true;

            if (pwd1.Length != pwd2.Length)
                pwdsSame = false;
            else
            {
                for (int i = 0; i < pwd1.Length; i++)
                {
                    if (pwd1[i] != pwd2[i])
                    {
                        pwdsSame = false;
                        break;
                    }
                }
            }

            if (pwdsSame || _singleEntry)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("The Passwords do not match. Try retyping them.");
                txtEntry.SecureText.Clear();
                txtEntry.Clear();
                txtReEntry.SecureText.Clear();
                txtReEntry.Clear();
                txtEntry.Focus();
            }

        }
        #endregion
    }
}