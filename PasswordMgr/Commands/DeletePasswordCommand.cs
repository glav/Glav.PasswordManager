using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;
using System.Windows.Forms;

namespace PasswordMgr.Commands
{
    class DeletePasswordCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            string msg = string.Format("Are you sure you wish to delete the password entry for {0}?",PasswordDataRepository.Current.PasswordContainer.Current.Title);
            if (MessageBox.Show(msg, "Confirm Password Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                PasswordDataRepository.Current.PasswordContainer.DeleteEntry(PasswordDataRepository.Current.PasswordContainer.Current.Title);
            }
        }
    }
}
