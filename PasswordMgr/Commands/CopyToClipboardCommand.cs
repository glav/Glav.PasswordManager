using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glav.PasswordMgr.Engine;
using PasswordMgr.Helpers;
using System.Windows.Forms;
using PasswordMgr.Data;

namespace PasswordMgr.Commands
{
    class CopyToClipboardCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            var currentPwd = PasswordDataRepository.Current.PasswordContainer.Current;
            if (currentPwd != null)
            {
                var chars = currentPwd.PasswordData.AsCharacterArray();
                if (chars != null && chars.Length > 0)
                {
                    string pwd = UTF8Encoding.UTF8.GetString(currentPwd.PasswordData.AsByteArray());
                    Clipboard.SetDataObject(pwd, false);

                    MessageBox.Show("Password has been copied to the clipboard. Note: This is an unsafe operation as the password is now in memory in clear text",
                                        "Warning/Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("No Password to copy for this entry.","Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
