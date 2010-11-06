using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace PwdMgr_WPF_UI.Commands
{
    public abstract class BaseCommand : ICommand
    {
        #region ICommand Members

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
        protected void OnCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, new EventArgs());
        }

        public virtual void Execute(object parameter)
        {
        }

        #endregion
    }
}
