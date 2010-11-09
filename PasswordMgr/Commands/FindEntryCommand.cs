using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;
using System.Windows;

namespace PasswordMgr.Commands
{
    class FindEntryCommand : BaseCommand
    {
        private static FindEntryDialog _findEntryWindow = null;
        private static object _lockFindWindow = new object();

        public override void Execute(object parameter)
        {
            if (PasswordDataRepository.Current.PasswordContainer.NumberOfPasswords > 0)
                ShowFindEntryWindow();
        }

        private void ShowFindEntryWindow()
        {
            lock (_lockFindWindow)
            {
                if (_findEntryWindow != null)
                    _findEntryWindow.Close();
                _findEntryWindow = new FindEntryDialog();
                _findEntryWindow.Owner = App.Current.MainWindow;

                _findEntryWindow.Top = App.Current.MainWindow.Top;
                _findEntryWindow.Left = App.Current.MainWindow.Left + App.Current.MainWindow.Width;

                _findEntryWindow.Show();
            }
        }

    }
}
