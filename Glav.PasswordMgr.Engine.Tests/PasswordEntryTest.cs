using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glav.PasswordMgr.Engine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Glav.PasswordMgr.Engine.Tests
{
    /// <summary>
    /// Summary description for PasswordEntryTest
    /// </summary>
    [TestClass]
    public class PasswordEntryTest
    {
        private const string TEST_TITLE = "EntryTitle";
        private const string TEST_USERID = "TestUser";
        private const string TEST_URL = "http://www.test.com";
        private readonly char[] TEST_PASSWORDDATA = new char[] { 'S', 'o', 'm', 'e', ' ', 'P', 'a', 's', 's', 'w', 'o', 'r', 'd' };
        private const string TEST_COMMENT = "Test Entry Only Comment";
        private readonly DateTime TEST_DATETIME = DateTime.Now;
        private string DIR_TEMP = string.Empty;

        public PasswordEntryTest()
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
            DIR_TEMP = Environment.CurrentDirectory + "\\";
        }

        [TestCleanup]
        public void CleanupFiles()
        {
            string filename = string.Format("{0}pwdData.fle",DIR_TEMP);
            if (System.IO.File.Exists(filename))
                System.IO.File.Delete(filename);
        }


        [TestMethod]
        public void SerialiseOnePasswordEntryTest()
        {

            PasswordEntry entry = new PasswordEntry();
            entry.Title = TEST_TITLE;
            entry.Url = TEST_URL;
            entry.ModifiedDateTime = TEST_DATETIME;
            entry.UserID = TEST_USERID;
            entry.Comment = TEST_COMMENT;
            //entry.PasswordData = new char[TEST_PASSWORDDATA.Length];
            for (int i = 0; i < TEST_PASSWORDDATA.Length; i++)
                entry.PasswordData.AppendChar(TEST_PASSWORDDATA[i]);
                //entry.PasswordData[i] = (char)TEST_PASSWORDDATA[i];

            using (FileStream writeStream = new FileStream(DIR_TEMP + "pwdData.fle", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(writeStream, entry);
            }

            PasswordEntry otherEntry = null;
            using (FileStream readStream = new FileStream(DIR_TEMP + "pwdData.fle", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter fmt = new BinaryFormatter();
                otherEntry =  (PasswordEntry)fmt.Deserialize(readStream);
            }

            Assert.AreEqual(entry.Title, otherEntry.Title);
            Assert.AreEqual(entry.Url, otherEntry.Url);
            Assert.AreEqual(entry.UserID, otherEntry.UserID);
            Assert.AreEqual(entry.ModifiedDateTime, otherEntry.ModifiedDateTime);
            Assert.AreEqual(entry.Comment, otherEntry.Comment);
            Assert.AreEqual(entry.PasswordData.Length,otherEntry.PasswordData.Length);

            char[] tmpPwdData1 = PasswordEntry.GetCharacterData(entry.PasswordData);
            char[] tmpPwdData2 = PasswordEntry.GetCharacterData(otherEntry.PasswordData);

            for (int i = 0; i < entry.PasswordData.Length; i++)
                Assert.AreEqual(tmpPwdData1[i], tmpPwdData2[i]);

        }

        [TestMethod]
        public void SerialiseArrayPasswordEntryTest()
        {
            const int LIST_SIZE = 20;
            PasswordEntry[] srcList = new PasswordEntry[LIST_SIZE];

            for (int loop = 0; loop < LIST_SIZE; loop++)
            {
                PasswordEntry entry = new PasswordEntry();
                entry.Title = TEST_TITLE + ": #" + loop.ToString();
                entry.Url = TEST_URL;
                entry.ModifiedDateTime = TEST_DATETIME;
                entry.UserID = TEST_USERID + ": #" + loop.ToString();
                entry.Comment = TEST_COMMENT + ": #" + loop.ToString();
                //entry.PasswordData = new char[TEST_PASSWORDDATA.Length+1];
                for (int i = 0; i < TEST_PASSWORDDATA.Length; i++)
                    entry.PasswordData.AppendChar(TEST_PASSWORDDATA[i]);
                //entry.PasswordData[TEST_PASSWORDDATA.Length] = (char)loop;
                entry.PasswordData.AppendChar((char)loop);
                srcList[loop] = entry;
            }

            using (FileStream writeStream = new FileStream(DIR_TEMP + "pwdDataList.fle", FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter fmt = new BinaryFormatter();
                fmt.Serialize(writeStream, srcList);
            }

            PasswordEntry[] otherList = null;
            using (FileStream readStream = new FileStream(DIR_TEMP + "pwdDataList.fle", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter fmt = new BinaryFormatter();
                otherList = (PasswordEntry[])fmt.Deserialize(readStream);
            }

            for (int loop = 0; loop < LIST_SIZE; loop++)
            {
                PasswordEntry entry = srcList[loop];
                PasswordEntry otherEntry = otherList[loop];

                Assert.AreEqual(entry.Title, otherEntry.Title);
                Assert.AreEqual(entry.Url, otherEntry.Url);
                Assert.AreEqual(entry.UserID, otherEntry.UserID);
                Assert.AreEqual(entry.ModifiedDateTime, otherEntry.ModifiedDateTime);
                Assert.AreEqual(entry.Comment, otherEntry.Comment);
                Assert.AreEqual(entry.PasswordData.Length, otherEntry.PasswordData.Length);

                char[] tmpPwdData1 = PasswordEntry.GetCharacterData(entry.PasswordData);
                char[] tmpPwdData2 = PasswordEntry.GetCharacterData(otherEntry.PasswordData);

                for (int i = 0; i < entry.PasswordData.Length; i++)
                    Assert.AreEqual(tmpPwdData1[i], tmpPwdData2[i]);
            }

        }

    }
}
