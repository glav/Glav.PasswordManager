using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;
using System.Windows.Forms;

namespace PasswordMgr.Commands
{
    class SetPassphraseCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            PassphraseEntry passphraseDialog = new PassphraseEntry();
            passphraseDialog.Owner = App.Current.MainWindow;
            if (passphraseDialog.ShowDialog() == true)
            {
                if (passphraseDialog.IsPassphraseValid)
                {
                    PasswordDataRepository.Current.PasswordContainer.Passphrase = passphraseDialog.PwdMain.SecurePassword;
                    MessageBox.Show("Passphrase for this password list has been set/changed.",
                                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            passphraseDialog.Close();

            base.Execute(parameter);
        }
    }
}
