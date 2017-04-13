using Microsoft.VisualStudio.TestTools.UnitTesting;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using CorehrAut.Pages;

namespace CoreHrTest
{
    [TestClass]
    public class EditEmployee : Include
    {
        
        [TestMethod]
        public void User_Can_Edit_Employee()
        {
            People.GoToPeople(PeopleAppFrom.Dashboard);
            People.EmployeeFirstName("firstName").EditEmployee();

        }
    }
}
