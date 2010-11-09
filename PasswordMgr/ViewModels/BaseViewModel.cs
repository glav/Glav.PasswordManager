using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using PwdMgr_WPF_UI.Data;
using Glav.PasswordMgr.Engine;

namespace PwdMgr_WPF_UI.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private IPasswordDataRepository _passwordRepository;

        public BaseViewModel()
        {
            _passwordRepository = PasswordDataRepository.Current;
        }
        public BaseViewModel(IPasswordDataRepository passwordRepository)
        {
            _passwordRepository = passwordRepository;
        }


        public PasswordManagerContainer PasswordContainer
        {
            get { return _passwordRepository.PasswordContainer; }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void RaisePropertyChanged(params string[] propertyNames)
        {
            if (PropertyChanged != null)
            {
                propertyNames.ToList().ForEach(p => RaisePropertyChanged(p));
            }
        }
        #endregion


    }
}
