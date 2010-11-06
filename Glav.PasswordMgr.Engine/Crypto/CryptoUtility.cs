using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Runtime.InteropServices;

namespace Glav.PasswordMgr.Engine.Crypto
{
    public static class CryptoUtility
    {
        /// <summary>
        /// Utility function to convert a secure string instance into a array of characters
        /// </summary>
        /// <param name="secString"></param>
        /// <returns></returns>
        public static char[] SecureStringToCharArray(SecureString secString)
        {
            char[] bytes = new char[secString.Length];
            IntPtr ptr = IntPtr.Zero;

            try
            {
                ptr = Marshal.SecureStringToBSTR(secString);
                Marshal.Copy(ptr, bytes, 0, secString.Length);
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Marshal.ZeroFreeBSTR(ptr);
            }

            return bytes;
        }
        /// <summary>
        /// Utility function to convert a secure string instance into a array of bytes
        /// </summary>
        /// <param name="secString"></param>
        /// <returns></returns>
        public static byte[] SecureStringToByteArray(SecureString secString)
        {
            byte[] bytes = new byte[secString.Length];
            char[] cBytes = SecureStringToCharArray(secString);

            for (int i = 0; i < cBytes.Length; i++)
                bytes[i] = (byte)cBytes[i];

            return bytes;
        }
    }
}
