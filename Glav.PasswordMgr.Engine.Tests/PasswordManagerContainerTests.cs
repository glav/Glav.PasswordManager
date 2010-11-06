using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security;
using System.Runtime.InteropServices;

namespace Glav.PasswordMgr.Engine.Tests
{
    /// <summary>
    /// Summary description for PasswordManagerContainerTests
    /// </summary>
    [TestClass]
    public class PasswordManagerContainerTests
    {
        private string FILENAME = string.Empty;

        public PasswordManagerContainerTests()
        {
            //
            // TODO: Add constructor logic here
            //
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
            FILENAME = Environment.CurrentDirectory + "\\test_PwdMgrContainer_file.enc";
        }

        [TestCleanup]
        public void CleanupFiles()
        {
            if (System.IO.File.Exists(FILENAME))
                System.IO.File.Delete(FILENAME);
        }

        [TestMethod]
        public void SaveLoadFileTest()
        {
            // Construct some data to save and use as comparison
            PasswordManagerContainer container = new PasswordManagerContainer();
            SecureString sec = new SecureString();
            sec.AppendChar('1');
            sec.AppendChar('2');
            sec.AppendChar('3');
            container.Passphrase = sec;

            SecureString secPwd1 = new SecureString();
            secPwd1.AppendChar('1');
            container.AddEntry("title1", "user1", "url1", "comment1", secPwd1);
            SecureString secPwd2 = new SecureString();
            secPwd2.AppendChar('2');
            container.AddEntry("title2", "user2", "url2", "comment2", secPwd2);
            SecureString secPwd3 = new SecureString();
            secPwd3.AppendChar('3');
            container.AddEntry("title3", "user3", "url3", "comment3", secPwd3);

            container.ListTitle = "TestTitle";
            container.SaveFile(FILENAME);

            // Now that we have saved it away, create a new instance and load the file, then compare the contents
            
            PasswordManagerContainer container2 = new PasswordManagerContainer();
            SecureString sec2 = new SecureString();
            sec2.AppendChar('1');
            sec2.AppendChar('2');
            sec2.AppendChar('3');
            container2.Passphrase = sec2;
            container2.LoadFile(FILENAME);

            // Now do the tests
            Assert.AreEqual(container.PasswordList.Length, container2.PasswordList.Length, "Loaded list contains differing number of passwords from the original, saved list");
            Assert.AreEqual(container.ListTitle, container2.ListTitle, "Password containers ListTitles are different.");

            for (int i = 0; i < container.PasswordList.Length; i++)
            {
                PasswordEntry pe1 = container.PasswordList[i];
                PasswordEntry pe2 = container2.PasswordList[i];

                Assert.AreEqual(pe1.Title, pe2.Title, "Mismatched password entry data. File did not load/save correctly.");
                Assert.AreEqual(pe1.UserID, pe2.UserID, "Mismatched password entry data. File did not load/save correctly.");
                Assert.AreEqual(pe1.Url, pe2.Url, "Mismatched password entry data. File did not load/save correctly.");
                Assert.AreEqual(pe1.Comment, pe2.Comment, "Mismatched password entry data. File did not load/save correctly.");
                Assert.AreEqual(pe1.Title, pe2.Title, "Mismatched password entry data. File did not load/save correctly.");

                char[] pwd1 = GetSecureStringData(pe1.PasswordData);
                char[] pwd2 = GetSecureStringData(pe2.PasswordData);
                // We know the passwords are only 1 char long...
                Assert.AreEqual(pwd1.Length, pwd2.Length, "Password lengths are different when comparing a saved and loaded password entry");
                Assert.AreEqual(pwd1[0], pwd2[0], "Passwords are different when comparing a saved and loaded password entry");
                
            }

            // Now this test SHOULD FAIL as we will use a bad passphrase
            PasswordManagerContainer container3 = new PasswordManagerContainer();
            SecureString sec3 = new SecureString();
            sec3.AppendChar('x');
            sec3.AppendChar('y');
            sec3.AppendChar('z');
            container3.Passphrase = sec3;
            try
            {
                container3.LoadFile(FILENAME);
                Assert.Fail("File loaded successfully with an INCORRECT passphrase!");
            }
            catch
            {
                // All is good
            }




        }

        private char[] GetSecureStringData(SecureString secString)
        {
            char[] bytes = new char[secString.Length];
            IntPtr ptr = Marshal.SecureStringToBSTR(secString);
            Marshal.Copy(ptr, bytes, 0, secString.Length);
            if (ptr != IntPtr.Zero)
                Marshal.ZeroFreeBSTR(ptr);

            return bytes;

        }
    }
}
