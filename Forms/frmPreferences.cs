using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Glav.PasswordMgr.Engine.Configuration;

namespace Glav.PasswordMgr
{
    public partial class frmPreferences : Form
    {
        public frmPreferences()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ConfigMgr.RequirePwdOnMaximise = chkReqPwd.Checked;
            ConfigMgr.Save();
        }
    }
}