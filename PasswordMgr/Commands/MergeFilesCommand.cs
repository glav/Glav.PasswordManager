using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PasswordMgr.Commands
{
    class MergeFilesCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            string filename = null;

            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Filter = Constants.OpenDialogFilter ;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    filename = openDialog.FileName;
                }
            }

            MessageBox.Show("Not Implemented", "Ba bow...");
        }
    }
}
