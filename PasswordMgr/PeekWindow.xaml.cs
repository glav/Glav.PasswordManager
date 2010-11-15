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

        public PeekWindow() : base()
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
                    for (var pCnt = 0; pCnt < pwdArray.Length; pCnt++)
                    {
                        var pwdChar = pwdArray[pCnt];
                        var charToAdd = new TextBlock() { Text = pwdChar.ToString()};
                        if (pCnt == 0)
                            charToAdd.Margin = new Thickness(10,0,0,0);
                        if (pCnt == pwdArray.Length-1)
                            charToAdd.Margin = new Thickness(0,0,10,0);
                        peekPassword.Children.Add(charToAdd);
                        pwdArray[pCnt] = '\0';
                    }

                }
            }
            else
            {
                peekPassword.Children.Add(new TextBlock() { Text = "- No Password Defined -" });

            }

            base.OnContentRendered(e);
        }

        private char[] GetCharacterDataFromSecureString(SecureString secureData)
        {
            if (secureData.Length < 1)
                return null;

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
