using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorehrAut.Configuration;
using CoreHrTest;
using CorehrAut.Interfaces;
using CorehrAut.Settings;
using NUnit.Framework;
using System.IO;


namespace CoreHrTest.Reporting
{
    //[TestClass]
    [TestFixture]
    public class UnitTest1 : SetupTearDown
    {
        [Test]
       // [TestMethod]
        public void Checking_the_Test_Name()
        {
            IConfig config = new AppConfigReader();
            Console.WriteLine("Broswer :  {0}", config.GetBrowser());
            Console.WriteLine("Username :  {0}", config.GetUsername());
            Console.WriteLine("Password :  {0}", config.GetPassword());

        }
    }
}
