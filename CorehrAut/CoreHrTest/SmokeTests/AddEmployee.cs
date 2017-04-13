using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using CorehrAut.Pages;

namespace CoreHrTest
{
    [TestClass]
    public class AddEmployee : Include
    {
        [TestMethod]
        public void User_can_add_employee()
        {
            People.GoToPeople(PeopleAppFrom.Dashboard);
            People.EmployeeFirstName("firstName").WithLastName("lastName").AddEmployee();
            Assert.IsTrue(IsAt.Page(People.pageItem), "Is not at people page");
            
        }
    }
}
