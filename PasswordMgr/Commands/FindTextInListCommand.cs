using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwdMgr_WPF_UI.ViewModels;

namespace PwdMgr_WPF_UI.Commands
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
