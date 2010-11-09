using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glav.PasswordMgr.Engine;

namespace PwdMgr_WPF_UI.Data
{
    public interface IPasswordDataRepository
    {
        PasswordManagerContainer PasswordContainer { get; }
    }
}
