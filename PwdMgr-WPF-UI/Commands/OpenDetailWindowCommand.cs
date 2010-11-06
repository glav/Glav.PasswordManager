using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using PwdMgr_WPF_UI.Data;

namespace PwdMgr_WPF_UI.Commands
{
    class OpenDetailWindowCommand : BaseCommand
    {
        private static List<PasswordDetail> _openDetailWindows = new List<PasswordDetail>();
        private static object _windowListLock = new object();

        public override void Execute(object parameter)
        {
            if (PasswordDataRepository.Current.PasswordContainer.Current != null)
            {
                lock (_openDetailWindows)
                {
                    _openDetailWindows.ForEach(w => w.CloseWindowWithAnimation());
                    _openDetailWindows.Clear();
                }
                ShowDetailWindow(parameter);
            }
        }

        private void ShowDetailWindow(object parameter)
        {
            var detailform = new PasswordDetail();
            detailform.Owner = App.Current.MainWindow;

            if (parameter != null)
            {
                var mousePoint = (Point)parameter;
                detailform.Top = mousePoint.Y;// +App.Current.MainWindow.Height;
                detailform.Left = mousePoint.X;// +App.Current.MainWindow.Width;
            }

            detailform.Show();

            lock (_windowListLock)
            {
                _openDetailWindows.Add(detailform);
            }

        }
    }

}
