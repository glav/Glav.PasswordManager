using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Glav.PasswordMgr.Engine;

namespace PasswordMgr.Data
{
    public interface IPasswordDataRepository
    {
        PasswordManagerContainer PasswordContainer { get; }
    }
}
