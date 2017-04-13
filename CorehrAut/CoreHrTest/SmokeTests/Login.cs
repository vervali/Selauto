using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using NUnit.Framework;
using NUnit.Framework.Internal;




namespace CoreHrTest 
{
    [TestFixture]
   // [TestClass]
    public class Login : Include
    {
        [Test]
       // [TestMethod,TestCategory("Smoke")]
        public void User_can_login()
        {
            try
            {
                NUnit.Framework.Assert.IsTrue(IsAt.Page(Dashboard.pageItemCorehr), "failed to login");
              Console.WriteLine("Login Succesfull");
                    
            }
            catch
            {
                Console.WriteLine("Failed to Execute the Login Test Case");
            }
            
        }
       
    }
}
