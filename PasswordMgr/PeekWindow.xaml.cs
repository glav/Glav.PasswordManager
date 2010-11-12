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
using System.Security;
using System.Runtime.InteropServices;

namespace PasswordMgr
{
    /// <summary>
    /// Interaction logic for PeekWindow.xaml
    /// </summary>
    public partial class PeekWindow : Window
    {
        SecureString _password;

        public PeekWindow()
        {
            InitializeComponent();
        }

        public PeekWindow(SecureString passwordToShow)
            : this()
        {
            _password = passwordToShow;
        }

        protected override void OnContentRendered(EventArgs e)
        {
            if (_password != null)
            {
                var pwdArray = GetCharacterDataFromSecureString(_password);
                if (pwdArray != null && pwdArray.Length > 0)
                {
                    foreach (var pwdChar in pwdArray)
                    {
                        peekPassword.Children.Add(new TextBlock() { Text = pwdChar.ToString() });
                    }
                }
            }

            base.OnContentRendered(e);
        }

        private char[] GetCharacterDataFromSecureString(SecureString secureData)
        {
            char[] bytes = new char[secureData.Length];
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secureData);
                bytes = new char[secureData.Length];
                Marshal.Copy(ptr, bytes, 0, secureData.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }

            return bytes;
        }

    }
}
