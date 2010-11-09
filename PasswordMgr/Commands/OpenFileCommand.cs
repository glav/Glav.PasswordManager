using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using PasswordMgr.Data;

namespace PasswordMgr.Commands
{
    public class OpenFileCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            string filename = parameter as string;

            if (filename == null)
            {
                using (OpenFileDialog openDialog = new OpenFileDialog())
                {
                    openDialog.Filter = "Password Manager|*.pgr|All Files|*.*";
                    if (openDialog.ShowDialog() == DialogResult.OK)
                    {
                        filename = openDialog.FileName;
                    }
                }
            }

            if (!string.IsNullOrEmpty(filename))
            {
                PassphraseEntry passphraseDialog = new PassphraseEntry();
                passphraseDialog.Owner = App.Current.MainWindow;
                if (passphraseDialog.ShowDialog() == true)
                {
                    if (passphraseDialog.IsPassphraseValid)
                    {
                        PasswordDataRepository.Current.PasswordContainer.Passphrase = passphraseDialog.PwdMain.SecurePassword;
                        try
                        {
                            PasswordDataRepository.Current.PasswordContainer.LoadFile(filename);
                        }
                        catch
                        {
                            System.Windows.MessageBox.Show("Cannot open password file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                passphraseDialog.Close();
            }
        }
    }
}
