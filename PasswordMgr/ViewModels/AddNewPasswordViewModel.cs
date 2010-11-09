using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordMgr.ViewModels
{
    public class AddNewPasswordViewModel : BaseViewModel
    {
        private string _passwordTitleText = string.Empty;
        public string PasswordTitleText
        {
            get { return _passwordTitleText; }
            set
            {
                if (value != _passwordTitleText)
                {
                    _passwordTitleText = value;
                    RaisePropertyChanged("PasswordTitleText","IsTitleValid");
                }
            }
        }

        public bool IsTitleValid
        {
            get { return !string.IsNullOrEmpty(_passwordTitleText); }
        }
    }
}
