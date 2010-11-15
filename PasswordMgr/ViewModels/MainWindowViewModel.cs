using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.ComponentModel;
using PasswordMgr.Data;
using Glav.PasswordMgr.Engine;
using System.Windows;
using PasswordMgr.Commands;
using System.Security;

namespace PasswordMgr.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Constructors

        public MainWindowViewModel()
            : base()
        {
            base.PasswordContainer.PropertyChanged += new PropertyChangedEventHandler(PasswordContainer_PropertyChanged);
        }

        public MainWindowViewModel(IPasswordDataRepository passwordRepository) : base(passwordRepository) { }

        #endregion

        void PasswordContainer_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "NumberOfPasswords":
                    RaisePropertyChanged("IsDataAvailable","IsPeekOptionEnabled");
                    break;
                case "PasswordList":
                    RaisePropertyChanged("IsDataAvailable","IsPeekOptionEnabled");
                    break;
                case "Current":
                    RaisePropertyChanged("IsPeekOptionEnabled");
                    break;
            }
        }

        public bool IsDataAvailable
        {
            get { return (PasswordContainer.NumberOfPasswords > 0); }
        }

        public bool IsPeekOptionEnabled
        {
            get { return (IsDataAvailable && PasswordContainer.Current != null); }
        }

        internal void ExecuteSelectionDoubleClickCommand(Point mousePoint)
        {
            ICommand cmd = App.Current.Resources[AppCommand.OpenDetailWindow] as ICommand;
            if (cmd != null)
                cmd.Execute(mousePoint);
        }

        public bool _mainOptionsToggleSwitch = false;
        public bool MainOptionsToggleSwitch
        {
            get { return _mainOptionsToggleSwitch; }
            set
            {
                if (value != _mainOptionsToggleSwitch)
                {
                    _mainOptionsToggleSwitch = value;
                    RaisePropertyChanged("MainOptionsToggleSwitch", "IsMainOptionsCollapsed");
                }
            }
        }

        public bool _settingsOptionsToggleSwitch = false;
        public bool SettingsOptionsToggleSwitch
        {
            get { return _settingsOptionsToggleSwitch; }
            set
            {
                if (value != _settingsOptionsToggleSwitch)
                {
                    _settingsOptionsToggleSwitch = value;
                    RaisePropertyChanged("SettingsOptionsToggleSwitch", "IsSettingsOptionsCollapsed");
                }
            }
        }

        public Visibility IsMainOptionsCollapsed
        {
            get { return (MainOptionsToggleSwitch ? Visibility.Collapsed : Visibility.Visible); }
        }
        public Visibility IsSettingsOptionsCollapsed
        {
            get { return (SettingsOptionsToggleSwitch ? Visibility.Collapsed : Visibility.Visible); }
        }



        private Point _currentMousePosition;
        public Point CurrentMousePosition
        {
            get { return _currentMousePosition; }
            set
            {
                if (value != _currentMousePosition)
                {
                    _currentMousePosition = value;
                    RaisePropertyChanged("CurrentMousePosition");
                }
            }
        }


        internal void OnExitApplication(System.ComponentModel.CancelEventArgs e)
        {
            ICommand exitCommand = App.Current.Resources[AppCommand.ExitCommand] as ICommand;
            if (exitCommand != null)
            {
                exitCommand.Execute(e);
            }
        }

        internal void OnApplicationLoaded()
        {
            // Did we specify a file to load on the command line?
            string[] cmdline = Environment.GetCommandLineArgs();
            throw new Exception("shit");
            if (cmdline.Length > 1)
            {
                // make sure the file specified is valid
                string filename = cmdline[1];
                if (System.IO.File.Exists(filename))
                {
                    ICommand openCommand = App.Current.Resources[AppCommand.OpenFile] as ICommand;
                    openCommand.Execute(filename);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("The filename specified on the command line was not found.", "Error - File not found",
                        System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
    }
}
