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
    /// Interaction logic for FindEntryDialog.xaml
    /// </summary>
    public partial class FindEntryDialog : Window
    {
        public FindEntryDialog()
        {
            InitializeComponent();
        }

        private FindEntryViewModel ViewModel
        {
            get { return DataContext as FindEntryViewModel; }
        }

        public void CloseWindowWithAnimation()
        {
            CloseButton_Click(this, null);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ResetSearch();

            var anim = Resources["SlidingInWindow"] as System.Windows.Media.Animation.Storyboard;
            anim.Completed += new EventHandler(anim_Completed);
            anim.Begin(this);
        }

        void anim_Completed(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SearchText = this.SearchText.Text;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SearchText.Focus();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                CloseWindowWithAnimation();
        }
    }
}
