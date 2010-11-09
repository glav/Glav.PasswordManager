using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;

namespace PasswordMgr.Commands
{
    public class NewPasswordListCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            PasswordDataRepository.Current.PasswordContainer.ClearAll();
        }
    }
}
