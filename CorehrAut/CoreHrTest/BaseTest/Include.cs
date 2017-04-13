using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using NUnit.Framework;
using CorehrAut.Pages;
using CorehrAut;
using CorehrAut.Interfaces;
using CorehrAut.Configuration;
using CoreHrTest.Reporting;
using CorehrAut.Keywords;

namespace CoreHrTest
{
   [TestFixture]
   // [TestClass]
    public class Include : SetupTearDown
    {
       [SetUp]
       // [TestInitialize,TestCategory("Smoke")]
        public void Init()
        {
            IConfig config = new AppConfigReader();

            Keywords.Initialize(config.GetBrowser());
            LoginPage.Goto();
            LoginPage.LoginAs(config.GetUsername()).WithPassword(config.GetPassword()).Login();
         }
        [TearDown]
      // [TestCleanup,TestCategory("Smoke")]
        public void CleanUp()
        {
            LoginPage.CloseBrowser();
        }

    }
}
