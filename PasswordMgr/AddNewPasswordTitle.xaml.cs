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

namespace PasswordMgr
{
    /// <summary>
    /// Interaction logic for AddNewPasswordTitle.xaml
    /// </summary>
    public partial class AddNewPasswordTitle : Window
    {
        public AddNewPasswordTitle()
        {
            InitializeComponent();
        }

        public AddNewPasswordViewModel ViewModel
        {
            get { return DataContext as AddNewPasswordViewModel; }
        }


        public string PasswordTitleText
        {
            get { return PasswordTitle.Text; }
            set { PasswordTitle.Text = value; }
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            PasswordTitle.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void PasswordTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.PasswordTitleText = PasswordTitleText;
        }

    }
}
