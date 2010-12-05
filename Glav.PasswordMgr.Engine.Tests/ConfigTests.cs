using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Glav.PasswordMgr.Engine.Configuration;

namespace Glav.PasswordMgr.Engine.Tests
{
    /// <summary>
    /// Summary description for ConfigTests
    /// </summary>
    [TestClass]
    public class ConfigTests
    {
        private int LEFTPOS = 1;
        private int TOPPOS = 2;
        private int WIDTH = 3;
        private int HEIGHT = 4;
        private bool REQUIREPWDENTRY = true;

        public ConfigTests()
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
        [TestMethod]
        public void CreateAndSaveFile()
        {
            ConfigMgr.PositionLeft = LEFTPOS;
            ConfigMgr.PositionTop = TOPPOS;
            ConfigMgr.SizeWidth = WIDTH;
            ConfigMgr.SizeHeight = HEIGHT;
            ConfigMgr.RequirePwdOnMaximise = REQUIREPWDENTRY;

            ConfigMgr.Save();
        }

        [TestMethod]
        public void LoadFile()
        {
            ConfigMgr.PositionLeft = LEFTPOS;
            ConfigMgr.PositionTop = TOPPOS;
            ConfigMgr.SizeWidth = WIDTH;
            ConfigMgr.SizeHeight = HEIGHT;
            ConfigMgr.RequirePwdOnMaximise = REQUIREPWDENTRY;

            ConfigMgr.Save();
            
            ConfigMgr.PositionLeft = -1;
            ConfigMgr.PositionTop = -1;
            ConfigMgr.SizeWidth = -1;
            ConfigMgr.SizeHeight = -1;
            ConfigMgr.RequirePwdOnMaximise = false;

            ConfigMgr.Load();

            Assert.IsTrue(ConfigMgr.PositionLeft == LEFTPOS,"Saved Left Position is " + ConfigMgr.PositionLeft.ToString() + " but it should be " + LEFTPOS.ToString());
            Assert.IsTrue(ConfigMgr.PositionTop == TOPPOS, "Saved Top Position is " + ConfigMgr.PositionTop.ToString() + " but it should be " + TOPPOS.ToString());
            Assert.IsTrue(ConfigMgr.SizeHeight == HEIGHT, "Saved Width is " + ConfigMgr.SizeWidth.ToString() + " but it should be " + WIDTH.ToString());
            Assert.IsTrue(ConfigMgr.SizeWidth == WIDTH, "Saved Height is " + ConfigMgr.SizeHeight.ToString() + " but it should be " + HEIGHT.ToString());
            Assert.IsTrue(ConfigMgr.RequirePwdOnMaximise == REQUIREPWDENTRY,"Saved RequirePasswordOnMaximise is " + ConfigMgr.RequirePwdOnMaximise.ToString() + " but it should be " + REQUIREPWDENTRY.ToString());
        }

    }
}
