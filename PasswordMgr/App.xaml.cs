using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using PasswordMgr.ViewModels;
using PasswordMgr.Commands;

namespace PasswordMgr
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (e.Args != null && e.Args.Length > 0)
            {
                MainWindow win = new PasswordMgr.MainWindow();
                var fileToOpen = e.Args[0] as string;
                if (fileToOpen != null)
                {
                    OpenFileCommand openCmd = new OpenFileCommand();
                    openCmd.Execute(fileToOpen);
                }
            }
            base.OnStartup(e);
        }
    }
}
