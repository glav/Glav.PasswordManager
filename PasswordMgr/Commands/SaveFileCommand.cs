using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;
using System.Windows;
using Forms=System.Windows.Forms;

namespace PasswordMgr.Commands
{
    /// <summary>
    /// For this command, lets assu,e a parameter should be a bool which indicates whether to use the current filename (nasically a straight save)
    /// or do a Save-As type command to save with a new filename.
    /// </summary>
    class SaveFileCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            bool useCurrentFilename = true;
            if (parameter != null)
            {
                try
                {
                    useCurrentFilename = (bool)parameter;
                }
                catch
                {
                    useCurrentFilename = true;
                }
            }

            if (useCurrentFilename)
            {
                // verify the filename exists
                if (string.IsNullOrWhiteSpace(PasswordDataRepository.Current.PasswordContainer.Filename))
                    useCurrentFilename = false;
            }

            try
            {
                if (useCurrentFilename)
                {
                    PasswordDataRepository.Current.PasswordContainer.SaveFile();
                }
                else
                {
                    Forms.SaveFileDialog saveAsDlg = new Forms.SaveFileDialog();
                    saveAsDlg.DefaultExt = ".pgr";
                    saveAsDlg.AddExtension = true;
                    saveAsDlg.Filter = "Password Manager Files|*.pgr|All Files|*.*";
                    if (saveAsDlg.ShowDialog() == Forms.DialogResult.OK)
                    {
                        PasswordDataRepository.Current.PasswordContainer.SaveFile(saveAsDlg.FileName);
                    }
                }
                MessageBox.Show(string.Format("Passwords saved to: {0}", PasswordDataRepository.Current.PasswordContainer.Filename));

            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Could not save your password file.\n{0}", ex.Message), "Error Saving your passwords", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
    }
}
