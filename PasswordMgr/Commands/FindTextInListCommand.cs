using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.ViewModels;

namespace PasswordMgr.Commands
{
    class FindTextInListCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as FindEntryViewModel;
            if (viewModel != null)
                viewModel.DoSearch();
        }
    }
}
