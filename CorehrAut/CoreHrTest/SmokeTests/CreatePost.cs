using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using CorehrAut.Pages;


namespace CoreHrTest
{
    [TestClass]
    public class CreatePost : Include
    {
        [TestMethod]
        public void User_can_create_social_post()
        {
            Assert.IsTrue(IsAt.Page(Dashboard.pageItemSocial), "Failed to login");
            Dashboard.Post();
            Assert.IsTrue(Dashboard.PostIsPresent, "Post Unsuccessfull");
            Dashboard.DeletePost();
        }
    }
}