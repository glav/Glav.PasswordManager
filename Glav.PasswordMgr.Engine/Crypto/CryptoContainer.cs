using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Runtime.InteropServices;

using Glav.PasswordMgr.Engine.Globals;
using Glav.PasswordMgr.Engine.Exceptions;

namespace Glav.PasswordMgr.Engine.Crypto
{
    /// <summary>
    /// This class represents the Cryptographic container tool for the version of the password manager
    /// designed for .Net V2.
    /// It is equivalent to the CryptoTool class that was used in the previous version on .Net V1.1,
    /// however this class uses far more advanced methods of deriving a key from a password and peforms extra
    /// checks to ensure the passphrases are not held in memory in plain, unencrypted form for more than a couple of milliseconds.
    /// Also, the Rijndael method of encryption is used for its higher bit strength (256 bits) vs. 192 bits for TripleDES in the 
    /// previous version.
    /// </summary>
    public class CryptoContainer
    {
        #region Private Fields

        private const int KEY_LENGTH = 256;

        // The private key and Initialisation vector
        private byte[] _cryptoIV = null;
        private byte[] _cryptoKey = null;
        private byte[] _cryptoPassphrase = null;

        private Rijndael _cryptoAlgorithm = RijndaelManaged.Create();  // Rijndael supports 256 bit key lengths

        #endregion

        #region Constructors

        public CryptoContainer() { }

        public CryptoContainer(string passphrase) : base()
        {
            SetPassphrase(passphrase);
        }

        public CryptoContainer(SecureString passphrase)
            : base()
        {
            SetPassphrase(passphrase);
        }

        #endregion

        #region DecryptFromFile
        /// <summary>
        /// Decrypts a file into a string.
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public object DecryptFromFile(string filename)
        {
            if (_cryptoIV == null || _cryptoKey == null)
                GenerateKeys();

            FileStream readStream = null;
            CryptoStream cryptStream = null;
            object data = null;

            try
            {
                // Create the file stream.
                readStream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.None);

                // Init the encryption stuff
                ICryptoTransform transform = _cryptoAlgorithm.CreateDecryptor(_cryptoKey, _cryptoIV);
                cryptStream = new CryptoStream(readStream, transform, CryptoStreamMode.Read);

                BinaryFormatter fmtter = new BinaryFormatter();
                data = fmtter.Deserialize(cryptStream);

            }
            finally
            {
                if (cryptStream != null)
                    cryptStream.Close();
                if (readStream != null)
                    readStream.Close();
            }

            return data;

        }
        #endregion

        #region EncryptToFile method
        /// <summary>
        /// Encrypt our string data into the supplied filename.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="BytesToEncrypt"></param>
        public void EncryptToFile(string filename, object objectData)
        {
            if (_cryptoIV == null || _cryptoKey == null)
                GenerateKeys();

            FileStream writeStream = null;
            CryptoStream cryptStream = null;

            try
            {
                // Create the file stream.
                writeStream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

                // Init the encryption stuff
                ICryptoTransform transform = _cryptoAlgorithm.CreateEncryptor(_cryptoKey, _cryptoIV);
                cryptStream = new CryptoStream(writeStream, transform, CryptoStreamMode.Write);

                // Get our data as bytes
                BinaryFormatter fmtter = new BinaryFormatter();
                fmtter.Serialize(cryptStream, objectData);
            }
            finally
            {
                if (cryptStream != null)
                    cryptStream.Close();
                if (writeStream != null)
                    writeStream.Close();
            }
        }

        #endregion

        #region UtilityMethod - ClearArray

        /// <summary>
        /// Simply erase or clear an array to all zeros.
        /// </summary>
        /// <param name="arrayToClear"></param>
        private void ClearArray(byte[] arrayToClear)
        {
            //TODO: Is this effective?
            for (int loop = 0; loop < arrayToClear.Length; loop++)
                arrayToClear[loop] = 0;
        }

        #endregion

        #region SetPassphrase

        /// <summary>
        /// This is typically a Secure text password that a user has entered. We convert it into an encrypted byte array
        /// using the DPAPI techniques of ProtectedData 
        /// </summary>
        /// <param name="passphrase"></param>
        public void SetPassphrase(SecureString passphrase)
        {
            ValidatePassphrase(passphrase);
            
            byte[] bytes = Crypto.CryptoUtility.SecureStringToByteArray(passphrase);

            _cryptoPassphrase = ProtectedData.Protect(bytes, null, DataProtectionScope.CurrentUser);

            ClearArray(bytes);
        }

        /// <summary>
        /// This is typically a plain text password that a user has entered. We convert it into an encrypted byte array
        /// using the DPAPI techniques of ProtectedData 
        /// </summary>
        /// <param name="passphrase"></param>
        public void SetPassphrase(byte[] passphrase, bool clearPassphraseArray)
        {
            ValidatePassphrase(passphrase);

            if (passphrase == null || passphrase.Length == 0)
            {
                throw new PasswordCryptoException("Invalid passphrase supplied.");
            }

            _cryptoPassphrase = ProtectedData.Protect(passphrase, null, DataProtectionScope.CurrentUser);

            if (clearPassphraseArray)
            {
                // Clear our array that originaly contained the passphrase
                ClearArray(passphrase);
            }
        }

        public void SetPassphrase(string passphrase)
        {
            ValidatePassphrase(passphrase);

            byte[] passBytes = System.Text.UTF8Encoding.UTF8.GetBytes(passphrase);
            SetPassphrase(passBytes,true);
        }

        private void ValidatePassphrase(object passphrase)
        {
            if (passphrase == null)
                throw new PasswordCryptoException("No Passphrase has been set.");
        }
        #endregion

        #region GenerateKeys

        /// <summary>
        /// Generate a new key and IV ready for encryption from the passphrase.
        /// </summary>
        private void GenerateKeys()
        {
            if (_cryptoPassphrase == null || _cryptoPassphrase.Length == 0)
            {
                throw new PasswordCryptoException("Invalid passphrase supplied.");
            }

            // Generate the Key first using SHA256 hashing algorithm
            byte[] unprotectedPass = ProtectedData.Unprotect(_cryptoPassphrase,null,DataProtectionScope.CurrentUser);
            byte[] reversedPass = new byte[unprotectedPass.Length];
            
            // Reverse the passphrase - it will be used for the salt
            for (int arrCnt = unprotectedPass.Length-1; arrCnt >= 0; arrCnt--)
                reversedPass[(unprotectedPass.Length - 1) - arrCnt] = unprotectedPass[arrCnt];

            if (reversedPass.Length < 8)
            {
                List<byte> tmpPass = new List<byte>(reversedPass);
                for (int x = 0; x < 8-reversedPass.Length; x++)
                    tmpPass.Add(0);
                reversedPass = tmpPass.ToArray();
            }

            Rfc2898DeriveBytes pwdGen = new Rfc2898DeriveBytes(unprotectedPass, reversedPass, 1000);
            _cryptoIV = pwdGen.GetBytes(16);
            _cryptoKey = pwdGen.GetBytes(32);
            
            ClearArray(unprotectedPass);
            ClearArray(reversedPass);
        }

        #endregion

    }
}
