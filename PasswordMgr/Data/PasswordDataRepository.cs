using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glav.PasswordMgr.Engine;

namespace PwdMgr_WPF_UI.Data
{
    public class PasswordDataRepository : IPasswordDataRepository
    {
        public static PasswordDataRepository Current = new PasswordDataRepository();

        public PasswordDataRepository()
        {
            App.Current.Exit += new System.Windows.ExitEventHandler(Current_Exit);
        }

        private PasswordManagerContainer _pwdContainer = new PasswordManagerContainer();
        public PasswordManagerContainer PasswordContainer
        {
            get { return _pwdContainer; }
        }

        void Current_Exit(object sender, System.Windows.ExitEventArgs e)
        {
            _pwdContainer.Dispose();
        }
    }
}
