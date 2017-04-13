using System;
using System.Threading;
using OpenQA.Selenium;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using CorehrAut.Keywords;


namespace CorehrAut.Pages
{
    public class People
    {
        public static string pageItem
        {
            get
            {
                return Keywords.Keywords.coreHrPeoplePageAreaHook;
            }
        }
        public static void GoToPeople(PeopleAppFrom pageType)
        {

            Keywords.Keywords.wait(TimeSpan.FromSeconds(10));
            switch (pageType)
            {
                case PeopleAppFrom.Dashboard:
                    Dashboard.PeopleApp.Select();
                    break;
                case PeopleAppFrom.AppSwitcher:
                    Sidebar.AppSwitcher.PeoplePage.Select();
                    break;
            }


        }
        
        public static EmployeeCommand EmployeeFirstName(string firstName)
        {
            return new EmployeeCommand(firstName);
        }



        public class EmployeeCommand
        {
            public string firstName;
            public string lastName;

            public EmployeeCommand(string firstName)
            {
                this.firstName = firstName;
            }
            public EmployeeCommand WithLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }
            public void AddEmployee()
            {
                if (Keywords.Keywords.Driver.Title.Equals("People"))
                {
                    Commands.Click(Keywords.Keywords.addButtonHook);
                    Thread.Sleep(5000);
                    Commands.TypeText(Keywords.Keywords.employeeFirstNameHook, firstName);
                    Commands.TypeText(Keywords.Keywords.employeeLastNameHook, lastName);
                    Commands.TypeText(Keywords.Keywords.employeeEmailHook, firstName + Keywords.Keywords.dateAndTime + "@avanishmail.com");
                    Commands.TypeText(Keywords.Keywords.employeeNumberHook, Keywords.Keywords.dateAndTime);
                    Commands.Click(Keywords.Keywords.employementStatusLookupHook, ".aut-area-xEmploymentStatusLookup table tbody tr[role]:nth-of-type(1) td:nth-of-type(3)");
                    Commands.TypeText(Keywords.Keywords.employeeStartDateHook, "02/19/2017" + Keys.Enter);
                    Commands.Click(Keywords.Keywords.employeePositionLookupHook, ".aut-area-xPositionLookup table tbody tr[role]:nth-of-type(1) td:nth-of-type(3)");
                    Commands.Click(Keywords.Keywords.employeeLocationLookupHook, ".aut-area-xLocationLookup table tbody tr[role]:nth-of-type(1) td:nth-of-type(3)");
                    Commands.Click(Keywords.Keywords.employeeRecordStatusLookupHook, Keywords.Keywords.activeOptionHook );
                    Commands.Click(Keywords.Keywords.saveButtonHook);
                    Thread.Sleep(5000);
                  
                }
            }
                public void EditEmployee()
            {
                
                while (!Keywords.Keywords.Driver.Title.Equals("People"));
                Commands.TypeText("input[type='text']", firstName);
                Commands.Click(".aut-button-xEmployeeDetail:nth-of-type(1)");
                Commands.Click(Keywords.Keywords.employeeEditHook);
                Commands.TypeText(Keywords.Keywords.employeeFirstNameHook, firstName + Keywords.Keywords.dateAndTime);
                Commands.Click(Keywords.Keywords.saveButtonHook);
                Thread.Sleep(10000);
            }
            }
        }
    public enum PeopleAppFrom
    {
        Dashboard,
        AppSwitcher
    }
}

