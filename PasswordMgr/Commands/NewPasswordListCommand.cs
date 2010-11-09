using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwdMgr_WPF_UI.Data;

namespace PwdMgr_WPF_UI.Commands
{
    public class NewPasswordListCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            PasswordDataRepository.Current.PasswordContainer.ClearAll();
        }
    }
}
