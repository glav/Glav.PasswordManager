using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;

namespace PasswordMgr.Commands
{
    class AddNewPasswordCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            AddNewPasswordTitle addNewWindow = new AddNewPasswordTitle();
            addNewWindow.Owner = App.Current.MainWindow;
            if (addNewWindow.ShowDialog() == true)
            {
                var newTitle = addNewWindow.PasswordTitleText;
                if (!PasswordDataRepository.Current.PasswordContainer.DoesEntryExist(newTitle))
                {
                    PasswordDataRepository.Current.PasswordContainer.AddEntry(newTitle,
                        string.Empty, string.Empty, string.Empty, null);
                    addNewWindow.PasswordTitleText = string.Empty;
                }
            }
            addNewWindow.Close();
        }
    }
}
