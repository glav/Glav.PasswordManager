using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Glav.PasswordMgr.Engine.Exceptions
{
    public class PasswordConfigurationException : PasswordException
    {
        public PasswordConfigurationException() : base() { }

        public PasswordConfigurationException(string message) : base(message) { }

        public PasswordConfigurationException(string message, Exception innerException) : base(message, innerException) { }

        public PasswordConfigurationException(SerializationInfo info, StreamingContext context) : base(info,context) { }
    }
}
