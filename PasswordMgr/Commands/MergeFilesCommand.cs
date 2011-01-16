using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PasswordMgr.Data;

namespace PasswordMgr.Commands
{
    class MergeFilesCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            string filename = null;

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = Constants.OpenDialogFilter;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = openDialog.FileName;
                    PassphraseEntry passphraseDialog = new PassphraseEntry();
                    passphraseDialog.Owner = App.Current.MainWindow;
                    if (passphraseDialog.ShowDialog() == true)
                    {
                        if (passphraseDialog.IsPassphraseValid)
                        {
                            var pwdsMerged = PasswordDataRepository.Current.PasswordContainer.DataMerge(filename, passphraseDialog.PwdMain.SecurePassword);
                            if (pwdsMerged < 0)
                            {
                                MessageBox.Show("There was an error trying to merg the passwords into the current file. You may have entered the wrong passphrase.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                MessageBox.Show(string.Format("{0} password entries have been merged into the current file.", pwdsMerged), "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    passphraseDialog.Close();

                }
            }
        }
    }
}
