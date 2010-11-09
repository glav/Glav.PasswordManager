using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Windows;
using System.Security;
using PwdMgr_WPF_UI.Helpers;

namespace PwdMgr_WPF_UI.ViewModels
{
    public class PassphraseEntryViewModel : BaseViewModel
    {
        private bool _reEnterPassphraseRequired = false;
        public bool ReEnterPassphraseRequired
        {
            get { return _reEnterPassphraseRequired; }
            set
            {
                if (value != _reEnterPassphraseRequired)
                {
                    _reEnterPassphraseRequired = value;
                    RaisePropertyChanged("ReEnterPassphraseRequired");
                }
            }
        }

        private SecureString _passphrase;
        public SecureString Passphrase
        {
            get { return _passphrase; }
            set
            {
                if (value != _passphrase)
                {
                    _passphrase = value;
                    RaisePropertyChanged("Passphrase", "IsPassphraseEntryValid");
                }
            }
        }

        private SecureString _passphraseReentry;
        public SecureString PassphraseReentry
        {
            get { return _passphraseReentry; }
            set
            {
                if (value != _passphraseReentry)
                {
                    _passphraseReentry = value;
                    RaisePropertyChanged("PassphraseReentry", "IsPassphraseEntryValid");
                }
            }
        }

        public bool IsPassphraseEntryValid
        {
            get
            {
                bool isValid = false;
                var passArray = _passphrase.AsCharacterArray();
                var passReenterArray = _passphraseReentry.AsCharacterArray();
                if (passArray != null && passReenterArray != null && passArray.Length == passReenterArray.Length)
                {
                    isValid = true ;
                    for (int cnt = 0; cnt < _passphrase.Length; cnt++)
                    {
                        if (passArray[cnt] != passReenterArray[cnt])
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                return isValid;
            }
        }

    }
}
