using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using PwdMgr_WPF_UI.Data;
using System.ComponentModel;

namespace PwdMgr_WPF_UI.Commands
{
    public class ExitCommand : BaseCommand
    {
        #region ICommand Members

        public override void Execute(object parameter)
        {
            if (PasswordDataRepository.Current.PasswordContainer.HasChanged)
            {
                if (MessageBox.Show("You have made changes but not saved your data. Are you sure you wish to exit?",
                                        "Warning - Changes Detected", MessageBoxButton.YesNo, MessageBoxImage.Warning) != MessageBoxResult.Yes)
                {
                    var cancelArgs = parameter as CancelEventArgs;
                    if (cancelArgs != null)
                        cancelArgs.Cancel = true;
                    return;
                }
            }
            Application.Current.Shutdown();
        }

        #endregion
    }
}
