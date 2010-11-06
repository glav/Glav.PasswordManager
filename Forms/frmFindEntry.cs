using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Glav.PasswordMgr
{
    public partial class frmFindEntry : Form
    {

        public string SearchText
        {
            get
            {
                return txtSearchCriteria.Text;
            }
            set
            {
                txtSearchCriteria.Text = value;
            }
        }

        public frmFindEntry()
        {
            InitializeComponent();

        }

    }
}