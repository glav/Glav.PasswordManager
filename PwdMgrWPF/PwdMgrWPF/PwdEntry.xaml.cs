using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PwdMgrWPF
{
    /// <summary>
    /// Interaction logic for PwdEntry.xaml
    /// </summary>

    public partial class PwdEntry : System.Windows.Window
    {

        public PwdEntry()
        {
            InitializeComponent();
        }

        protected void btnOK_Clicked(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        protected void btnCancel_Clicked(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

    }
}