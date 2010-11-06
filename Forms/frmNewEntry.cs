using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Glav.PasswordMgr
{
    public partial class frmNewEntry : Form
    {
        public frmNewEntry()
        {
            InitializeComponent();
        }

        public string NewPasswordDescription
        {
            get
            {
                return txtNewPwdDesc.Text;
            }
        }
    }
}