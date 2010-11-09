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
using PasswordMgr.Data;

namespace PasswordMgr
{
    /// <summary>
    /// Interaction logic for PasswordDetail.xaml
    /// </summary>
    public partial class PasswordDetail : Window
    {
        public PasswordDetail()
        {
            InitializeComponent();

            PasswordDataRepository.Current.PasswordContainer.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(PasswordContainer_PropertyChanged);
        }

        void PasswordContainer_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Current")
            {
                PwdMain.Clear();
                PwdReenter.Clear();
            }

        }
        public PasswordDetailViewModel ViewModel
        {
            get { return (DataContext as PasswordDetailViewModel); }
        }

        public void CloseWindowWithAnimation()
        {
            CloseButton_Click(this, null);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var anim = Resources["SlidingInWindow"] as System.Windows.Media.Animation.Storyboard;
            anim.Completed += new EventHandler(anim_Completed);
            anim.Begin(this);
        }

        void anim_Completed(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PasswordChangedHandler(object sender, RoutedEventArgs e)
        {
            ViewModel.Passphrase = PwdMain.SecurePassword;
            ViewModel.PassphraseReentry = PwdReenter.SecurePassword;
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                CloseWindowWithAnimation();
        }

    }
}
