using System;
using System.Security.Cryptography;
using System.IO;
using Glav.PasswordMgr.Engine.Globals;
using Glav.PasswordMgr.Engine.Exceptions;

/************************************************************************************
 * Modification History:-
 * Date        Who  CodeIDTag  Comments
 * ~~~~~~~~~~  ~~~  ~~~~~~~~~  ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
 * 04/02/2006   PG             Initial .Net V2.0 Migration
 *  
 * ***********************************************************************************/

namespace Glav.PasswordMgr.Engine.Crypto
{
    /// <summary>
    /// Summary description for CryptoTool.
    /// </summary>
    public class CryptoTool
    {
        #region private fields

        // The value to use to fill the key after using the passphrase
        private const int DEFAULT_FILLVALUE = 1;
        private const int DEFAULT_IV_VALUE = 2;
        private const int DEFAULT_KEYSIZE = 192;

        private static FileVersions currentVersion = FileVersions.Version3;

        private TripleDES m_Crypto = TripleDESCryptoServiceProvider.Create();

        // The private key and Initialisation vector
        private byte[] m_IV;
        private byte[] m_KEY;

        // The password container
        private string m_passPhrase = null; 

        #endregion

        public CryptoTool(string PassPhrase) : base()
        {
            
            if (PassPhrase != "")
            {
                m_passPhrase = PassPhrase;
                GenerateKeys();
            }
            else
                throw new PasswordCryptoException("Invalid Constructor Value. NULL/EMPTY not allowed.");
        }

        /// <summary>
        /// The current version of the password data file. This determines the method of generating the key.
        /// </summary>
        public FileVersions DataFileVersion 
        {
            get { return currentVersion; }
            set { currentVersion = value; }
        }

        public string PassPhrase
        {
            get
            {
                return m_passPhrase;
            }
            set
            {
                m_passPhrase = value;
                GenerateKeys();
            }
        }

        /// <summary>
        /// Sets a new Key value using the current passphrase
        /// </summary>
        private void SetNewKey()
        {
            m_Crypto.GenerateKey();
            byte[] newKey = new byte[m_Crypto.KeySize/8];
            int pLen = m_passPhrase.Length;  
            byte[] passBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(m_passPhrase);
            for (int i=0; i < m_Crypto.KeySize/8; i++)
            {
                if (i < pLen)
                    newKey[i] = passBytes[i];
                else
                    newKey[i] = Convert.ToByte((i-pLen)+1);
            }

            m_KEY = newKey;
            m_Crypto.Key = m_KEY;
        }

        /// <summary>
        /// Create the Initialisation Vector (IV)
        /// </summary>
        private void SetIV()
        {
            m_Crypto.GenerateIV();
            m_IV = new byte[m_Crypto.IV.Length];
            for (int i=0; i < m_Crypto.IV.Length; i++)
                m_IV[i] = Convert.ToByte(DEFAULT_IV_VALUE);
            m_Crypto.IV = m_IV;
        }

        private void GenerateKeys()
        {
            int keyBytes = (m_Crypto.KeySize/8);
            if (m_passPhrase.Length > keyBytes)
            {
                //TODO: Fix this. Must support huge passphrases. Uses hashing to hash passphrase, then extract key from that
                string msg = "Passphrase too large. Must be a maximum of " + keyBytes.ToString() + " characters in length.";
                throw new PasswordCryptoException(msg);
            }
            SetNewKey();
            SetIV();
        }

        public void EncryptToFile(string FileName, string BytesToEncrypt)
        {
            FileStream writeStream = null;
            CryptoStream cryptStream = null;
            System.IO.MemoryStream readStream = null;

            try 
            {
                byte[] tmpBytes = System.Text.ASCIIEncoding.ASCII.GetBytes(BytesToEncrypt);
                readStream = new System.IO.MemoryStream(tmpBytes);

                // Create the file stream.
                writeStream = new FileStream(FileName,FileMode.Create,FileAccess.Write,FileShare.None);

                // Init the encryption stuff
                ICryptoTransform transform = m_Crypto.CreateEncryptor(m_KEY,m_IV);
                cryptStream = new CryptoStream(writeStream,transform,CryptoStreamMode.Write);

                // Get our data as bytes
                byte[] byteData = readStream.ToArray();

                // Encrypt the data
                cryptStream.Write(byteData,0,byteData.Length);
                cryptStream.Close();
            } 
            finally 
            {
                if (readStream != null)
                    readStream.Close();
                if (writeStream != null)
                    writeStream.Close();
            }
        }

        public string DecryptFromFile(string FileName)
        {
            FileStream readStream = null;
            CryptoStream cryptStream = null;
            MemoryStream returnStream = null;
            string tmpStr = null;

            try 
            {
                // Create the file stream.
                readStream = new FileStream(FileName,FileMode.Open,FileAccess.Read,FileShare.None);

                // Init the encryption stuff
                ICryptoTransform transform = m_Crypto.CreateDecryptor(m_KEY,m_IV);
                cryptStream = new CryptoStream(readStream,transform,CryptoStreamMode.Read);

                byte[] byteData = new Byte[readStream.Length];

                // Decrypt the data
                cryptStream.Read(byteData,0,(int)readStream.Length);
                cryptStream.Close();

                returnStream = new MemoryStream(byteData);
            } 
            finally
            {
                if (readStream != null)
                    readStream.Close();
            }
            if (returnStream != null)
            {
                tmpStr = System.Text.ASCIIEncoding.ASCII.GetString(returnStream.ToArray());
            }
            return tmpStr;
        }

    }
}
