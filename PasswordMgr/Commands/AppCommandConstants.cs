using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordMgr.Commands
{
    public static class AppCommand
    {
        public const string CopyToClipboard = "CopyToClipboardCommand";
        public const string DeletePassword = "DeletePasswordCommand";
        public const string ExitCommand = "ExitCommand";
        public const string MainOptionsToggle = "MainOptionsToggleCommand";
        public const string NewPasswordList = "NewPasswordListCommand";
        public const string OpenDetailWindow = "OpenDetailWindowCommand";
        public const string OpenFile = "OpenFileCommand";
        public const string SettingsOptionsToggle = "SettingsOptionsToggleCommand";
        public const string AddNewPassword = "AddNewPasswordCommand";
        public const string SetPassphrase = "SetPassphraseCommand";
        public const string SaveFile = "SaveFileCommand";
        public const string MergeFiles = "MergeFilesCommand";
        public const string FindEntry = "FindEntryCommand";
        public const string FindTextInList = "FindTextInListCommand";
    }
}
