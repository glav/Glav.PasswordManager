using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PwdMgr_WPF_UI.ViewModels;

namespace PwdMgr_WPF_UI.Commands
{
    class SettingsOptionsToggleCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var viewModel = parameter as MainWindowViewModel;
            if (viewModel != null)
            {
                viewModel.SettingsOptionsToggleSwitch = !viewModel.SettingsOptionsToggleSwitch;
            }
        }
    }
}
