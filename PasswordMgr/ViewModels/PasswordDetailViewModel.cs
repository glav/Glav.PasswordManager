using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PasswordMgr.Data;
using System.Security;
using PasswordMgr.Helpers;

namespace PasswordMgr.ViewModels
{
    public class PasswordDetailViewModel : BaseViewModel
    {
        #region Constructors

        public PasswordDetailViewModel()
            : base()
        {
        }

        public PasswordDetailViewModel(IPasswordDataRepository passwordRepository)
            : base(passwordRepository)
        {
        }

        #endregion

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
                if (passArray != null && passReenterArray != null 
                        && passArray.Length > 0 && passReenterArray.Length > 0
                        && passArray.Length == passReenterArray.Length)
                {
                    isValid = true;
                    for (int cnt = 0; cnt < _passphrase.Length; cnt++)
                    {
                        if (passArray[cnt] != passReenterArray[cnt])
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                if (isValid)
                    PasswordContainer.Current.PasswordData = Passphrase;

                return isValid;
            }
        }


    }
}
