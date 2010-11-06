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
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {
        private Glav.PasswordMgr.Engine.PasswordManagerContainer _pwdMgr = new Glav.PasswordMgr.Engine.PasswordManagerContainer();
        private System.Windows.Forms.NotifyIcon _trayIcon;
        Glav.PasswordMgr.Engine.PasswordEntry _pe = null;

        public Window1()
        {
            InitializeComponent();
            _trayIcon = new System.Windows.Forms.NotifyIcon();
            _trayIcon.Click += new EventHandler(_trayIcon_Click);
            _trayIcon.Icon = new System.Drawing.Icon(
                System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("PwdMgrWPF.images.PwdMgr.ico"));
            _trayIcon.Visible = true;
            _trayIcon.Text = "Password Manager - WPF UI";
            _trayIcon.BalloonTipTitle = "Password Manager - WPF Interface";
            _trayIcon.BalloonTipText = "Password Manager simplified WPF Interface";
            _trayIcon.ShowBalloonTip(3000);

            this.Hide();

        }

        private void OnShowPassword(object sender, ExecutedRoutedEventArgs rea)
        {
            MessageBox.Show("here");
        }

        void _trayIcon_Click(object sender, EventArgs mea)
        {
            // Dynamically position our window
            System.Drawing.Rectangle r = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            this.Top = r.Height - this.Height;
            this.Left = r.Width - this.Width;
            RepositionCalloutStartingPoint(this.Width / 2, -1);
            this.Show();
            this.Activate();
        }

        public void ShowPassword(object sender, EventArgs rea)
        {
            if (lstPasswords.Items.Count > 0 && lstPasswords.SelectedIndex >= 0)
            {
                Glav.PasswordMgr.Engine.PasswordEntry entry = _pwdMgr.FindEntry(lstPasswords.SelectedItem.ToString());
                if (entry != null)
                {
                    byte[] charData = Glav.PasswordMgr.Engine.Crypto.CryptoUtility.SecureStringToByteArray(entry.PasswordData);
                    MessageBox.Show(this, System.Text.UTF8Encoding.UTF8.GetString(charData), "Password is....", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }

        }

        protected void btnExit_Click(object sender, RoutedEventArgs rea)
        {
            _trayIcon.Visible = false;
            this.Close();
        }

        protected void btnMinimise_Click(object sender, RoutedEventArgs rea)
        {
            this.Hide();
        }

        private void RepositionCalloutStartingPoint(double x, double y)
        {
            Point calloutPoint = this.CalloutPointer.Points[0];

            if (x != -1)
                calloutPoint.X = x;
            if (y != -1)
                calloutPoint.Y = y;
            this.CalloutPointer.Points[0] = calloutPoint;

        }

        protected void btnSearch_Click(object sender, RoutedEventArgs rea)
        {
            if (_pwdMgr.PasswordList.Length > 0 && txtSearch.Text != string.Empty)
            {
                _pe = _pwdMgr.FindEntry(txtSearch.Text);
                if (_pe != null)
                {
                    int pos = lstPasswords.Items.IndexOf(_pe.Title);
                    if (pos >= 0)
                    {
                        lstPasswords.SelectedIndex = pos;
                        
                        lstPasswords.ScrollIntoView(lstPasswords.SelectedItem);
                        lstPasswords.Focus();
                    }
                }
                else
                    MessageBox.Show(this, "Search text not found", "Not Found", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        protected void btnSearchContinue_Click(object sender, RoutedEventArgs rea)
        {
            if (_pwdMgr.PasswordList.Length > 0 && txtSearch.Text != string.Empty)
            {
                _pe = _pwdMgr.FindEntry(txtSearch.Text, _pe);
                if (_pe != null)
                {
                    int pos = lstPasswords.Items.IndexOf(_pe.Title);
                    if (pos >= 0)
                    {
                        lstPasswords.SelectedIndex = pos;
                        
                        lstPasswords.ScrollIntoView(lstPasswords.SelectedItem);
                        lstPasswords.Focus();
                    }
                }
            }
        }

        protected void btnLoadFile_Click(object sender, RoutedEventArgs rea)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PwdEntry pwdDlg = new PwdEntry();
                if (pwdDlg.ShowDialog() == true)
                {
                    System.Security.SecureString ss = new System.Security.SecureString();

                    foreach (char c in pwdDlg.txtPwd.Password)
                        ss.AppendChar(c);

                    _pwdMgr.Passphrase = ss;
                    try
                    {
                        _pwdMgr.LoadFile(dlg.FileName);

                        lstPasswords.Items.Clear();
                        foreach (Glav.PasswordMgr.Engine.PasswordEntry pe in _pwdMgr.PasswordList)
                            lstPasswords.Items.Add(pe.Title);
                            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error loading the passwords, probably due to an incorrect passphrase","Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                    MessageBox.Show("Cancelled");
            }
        }

    }
}