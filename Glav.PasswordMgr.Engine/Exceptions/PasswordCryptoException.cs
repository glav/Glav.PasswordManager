using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Glav.PasswordMgr.Engine.Exceptions
{
    public class PasswordCryptoException : PasswordException
    {
        public PasswordCryptoException() : base() { }

        public PasswordCryptoException(string message) : base(message) { }

        public PasswordCryptoException(string message, Exception innerException) : base(message, innerException) { }

        public PasswordCryptoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
