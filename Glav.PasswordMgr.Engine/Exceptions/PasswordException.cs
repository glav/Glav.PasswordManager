using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Glav.PasswordMgr.Engine.Exceptions
{
    public class PasswordException : System.Exception
    {
        public PasswordException() : base() { }

        public PasswordException(string message) : base(message) { }

        public PasswordException(string message, Exception innerException) : base(message, innerException) { }

        public PasswordException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
