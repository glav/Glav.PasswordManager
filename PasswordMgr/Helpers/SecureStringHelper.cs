using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace PasswordMgr.Helpers
{
    public static class SecureStringHelper
    {
        public static char[] AsCharacterArray(this SecureString secureEntry)
        {
            if (secureEntry == null)
                return null;

            char[] bytes = new char[secureEntry.Length];
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secureEntry);
                bytes = new char[secureEntry.Length];
                Marshal.Copy(ptr, bytes, 0, secureEntry.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }

            return bytes;
        }

        public static byte[] AsByteArray(this SecureString secureEntry)
        {
            if (secureEntry == null)
                return null;

            byte[] bytes = new byte[secureEntry.Length];
            char[] cBytes = secureEntry.AsCharacterArray();

            for (int i = 0; i < cBytes.Length; i++)
                bytes[i] = (byte)cBytes[i];

            return bytes;
        }

    }
}
