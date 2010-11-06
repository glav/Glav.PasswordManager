using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Glav.PasswordMgr.Engine.Crypto;

namespace Glav.PasswordMgr.Engine.Tests
{
    /// <summary>
    /// Summary description for CryptoTests
    /// </summary>
    [TestClass]
    public class CryptoTests
    {
        private string _dataToEncrypt = "This is some data that should be encrypted";
        private byte[] _passPhraseArray = null;
        private byte[] _badPassPhraseArray = null;
        private string _passPhrase = "SomeSecureThing";
        private string _incorrectPassphrase = "This Should not work";
        private string FILENAME = string.Empty;

        public CryptoTests()
        {
            _passPhraseArray = System.Text.UTF8Encoding.UTF8.GetBytes(_passPhrase);
            _badPassPhraseArray = System.Text.UTF8Encoding.UTF8.GetBytes(_incorrectPassphrase);
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        [TestInitialize]
        public void SetupFilename()
        {
            FILENAME = Environment.CurrentDirectory + "\\test_encrypted_file.enc";
        }

        [TestCleanup]
        public void CleanupFiles()
        {
            if (System.IO.File.Exists(FILENAME))
                System.IO.File.Delete(FILENAME);
        }


        [TestMethod]
        public void EncryptFile()
        {
            //const string FILENAME = "d:\\temp\\test_encrypted_file.enc";
            CryptoContainer c = new CryptoContainer();
            c.SetPassphrase(_passPhraseArray,false);
            c.EncryptToFile(FILENAME, _dataToEncrypt);

            // Now Decrypt the file
            CryptoContainer c2 = new CryptoContainer();
            c2.SetPassphrase(_passPhraseArray,false);
            string fileContents = (string)c2.DecryptFromFile(FILENAME);

            Assert.IsTrue(fileContents == _dataToEncrypt,"Decrypted data does not match original data");
        }

        [TestMethod]
        public void FailToDecryptFile()
        {
            //const string FILENAME = "d:\\temp\\test_encrypted_file.enc";
            CryptoContainer c = new CryptoContainer();
            c.SetPassphrase(_passPhraseArray, false);
            c.EncryptToFile(FILENAME, _dataToEncrypt);

            // Now Decrypt the file
            try
            {
                CryptoContainer c2 = new CryptoContainer();
                c2.SetPassphrase(_badPassPhraseArray, false);
                string fileContents = (string)c2.DecryptFromFile(FILENAME);

                Assert.IsTrue(fileContents != _dataToEncrypt, "Decrypted data matches original data. The data should not be able to be decryped!");
            }
            catch
            {
                // This is expected
            }
        }
    }
}
