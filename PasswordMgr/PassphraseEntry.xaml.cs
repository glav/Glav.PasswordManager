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
using System.Windows.Shapes;
using PasswordMgr.ViewModels;
using PasswordMgr.Helpers;
using System.Security;

namespace PasswordMgr
{
    /// <summary>
    /// Interaction logic for PassphraseEntry.xaml
    /// </summary>
    public partial class PassphraseEntry : Window
    {
        public PassphraseEntry()
        {
            InitializeComponent();
        }

        private PassphraseEntryViewModel ViewModel
        {
            get { return (DataContext as PassphraseEntryViewModel); }
        }

        private void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            ViewModel.Passphrase = PwdMain.SecurePassword;
            ViewModel.PassphraseReentry = PwdReenter.SecurePassword;
        }

        public bool IsPassphraseValid
        {
            get { return ViewModel.IsPassphraseEntryValid; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            PwdMain.Focus();
        }

    }
}
