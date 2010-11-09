using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PwdMgr_WPF_UI.ViewModels;
using PwdMgr_WPF_UI.Commands;

namespace PwdMgr_WPF_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindowViewModel ViewModel
        {
            get { return DataContext as MainWindowViewModel; }
        }

        #region Listview click and key handlers

        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var mousePoint = AddOffsetToMousePosition(e.GetPosition(null));
            ViewModel.ExecuteSelectionDoubleClickCommand(mousePoint);
        }
        private void ListView_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Point p = new Point(this.Left + (this.Width / 2), this.Top);
                ViewModel.ExecuteSelectionDoubleClickCommand(p);
            }
        }

        #endregion

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SettingsNavGrid.Height == 40)
                SettingsNavGrid.Height = 160;
            else
                SettingsNavGrid.Height = 40;
        }

        private Point AddOffsetToMousePosition(Point original)
        {
            original.X += this.Left;
            original.Y += this.Top;
            return original;
        }

        #region Window Event Handlers

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ViewModel.CurrentMousePosition = AddOffsetToMousePosition(e.GetPosition(null));
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ViewModel.OnExitApplication(e);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.OnApplicationLoaded();

            SetupHotkeys();
        }

        private void SetupHotkeys()
        {
            // Add CTRL-F to hotkeys for Password List View
            InputGestureCollection fGestures = new InputGestureCollection();
            fGestures.Add(new KeyGesture(Key.F, ModifierKeys.Control));
            RoutedUICommand ctrlFUiCommand = new RoutedUICommand("CTRL-F", "CTRLF", typeof(ListView), fGestures);
            PasswordListView.CommandBindings.Add(new CommandBinding(ctrlFUiCommand, FindCommandBinding_Executed));

            InputGestureCollection dGestures = new InputGestureCollection();
            dGestures.Add(new KeyGesture(Key.D, ModifierKeys.Control));
            RoutedUICommand ctrlDUiCommand = new RoutedUICommand("CTRL-D", "CTRLD", typeof(ListView), dGestures);
            PasswordListView.CommandBindings.Add(new CommandBinding(ctrlDUiCommand, DeleteCommandBinding_Executed));

            //TODO: This (CTRL-A) does not work
            InputGestureCollection aGestures = new InputGestureCollection();
            aGestures.Add(new KeyGesture(Key.A, ModifierKeys.Control));
            RoutedUICommand ctrlAUiCommand = new RoutedUICommand("CTRL-A", "CTRLA", typeof(ListView), aGestures);
            PasswordListView.CommandBindings.Add(new CommandBinding(ctrlAUiCommand, AddCommandBinding_Executed));

            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, DeleteCommandBinding_Executed));
            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Save, SaveCommandBinding_Executed));
            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, CopyToClipCommandBinding_Executed));
            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete, DeleteCommandBinding_Executed));
            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.Open, OpenCommandBinding_Executed));
            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.New, NewCommandBinding_Executed));
            PasswordListView.CommandBindings.Add(new CommandBinding(ApplicationCommands.SelectAll, AddCommandBinding_Executed));
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        #endregion


        #region Command Binding handlers

        private void ExecuteCommand(string commandName)
        {
            ICommand cmd = App.Current.Resources[commandName] as ICommand;
            if (cmd != null)
            {
                cmd.Execute(null);
            }
        }
        private void NewCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.NewPasswordList);
        }

        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.OpenFile);
        }
        private void SaveCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("save not implemented");
            ExecuteCommand(AppCommand.SaveFile);
        }
        private void FindCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.FindEntry);
        }
        private void AddCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.AddNewPassword);
        }
        private void CopyToClipCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.CopyToClipboard);
        }
        private void DeleteCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.DeletePassword);
        }
        private void MergeFilesCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ExecuteCommand(AppCommand.MergeFiles);
        }

        #endregion

        private void PasswordListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PasswordListView.ScrollIntoView(PasswordListView.SelectedItem);
        }

    }
}
