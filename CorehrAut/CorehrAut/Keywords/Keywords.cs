using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System.Threading;
using CorehrAut.Interfaces;
using CorehrAut.Configuration;

namespace CorehrAut.Keywords
{
   public class Keywords
    {
        public static DateTime d = DateTime.Now;
        public static IWebDriver Driver;
        public Keywords(IWebDriver driver)
        {
            if (driver == null)
            {
                throw new NullReferenceException("Driver Object is null");
            }
            PageFactory.InitElements(driver, this);
            Driver = driver;
        }
        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }
        public static void TurnOffWait()
        {
            wait(TimeSpan.FromSeconds(0));
        }
        public static void TurnOnWait()
        {
            wait(TimeSpan.FromSeconds(3));
        }

        public static string dateAndTime
        {
            get
            {
                return d.ToString("yyyyMMddHHmmssfff");
            }
        }
        public static void wait(TimeSpan timeSpan)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)timeSpan.TotalSeconds * 1000);
            //Thread.Sleep((int) timeSpan.TotalSeconds * 1000);
        }
        public static void Initialize(BrowserType driver)
        {
            IConfig config = new AppConfigReader();
            switch (driver)
            {
                case BrowserType.Chrome:
                    Driver = new ChromeDriver(@"E:\CHR\CorehrAut\packages\WebDriver.ChromeDriver.win32.2.28.0.0\content");
                    TurnOnWait();
                    Thread.Sleep(3000);
                    break;
                case BrowserType.Firefox:
                    Driver = new FirefoxDriver();
                    TurnOnWait();
                    break;
                case BrowserType.IExplorer:
                    Driver = new InternetExplorerDriver();
                    TurnOnWait();
                    break;
                case BrowserType.PhantomJS:
                    Driver = new PhantomJSDriver(@"E:\CHR\CorehrAut\CorehrAut");
                    TurnOnWait();
                    break;
            }
        }
        public const string usernameHook = ".aut-input-username";
        [FindsBy(How = How.CssSelector, Using = usernameHook)]
        public static IWebElement userNameTextBox;
        public const string passwordHook = ".aut-input-password";
        [FindsBy(How = How.CssSelector, Using = passwordHook)]
        public static IWebElement passwordTextBox;
        public const string loginButtonhook = ".aut-button-login";
        [FindsBy(How = How.CssSelector, Using = loginButtonhook)]
        public static IWebElement loginButton;
        public static string coreHrPeoplePageAreaHook = ".aut-area-coreHr";
        public static string addButtonHook = ".aut-button-add";
        public static string employeeFirstNameHook = ".aut-input-xFirstName";
        public static string employeeLastNameHook = ".aut-input-xLastName";
        public static string employeeEmailHook = ".aut-input-xEmail";
        public static string employeeNumberHook = ".aut-input-xEmployeeNumber";
        public static string employementStatusLookupHook = ".aut-input-xEmploymentStatusLookup";
        public static string employeeStartDateHook = ".aut-input-xStartDate";
        public static string employeePositionLookupHook = ".aut-input-xPositionLookup";
        public static string employeeLocationLookupHook = ".aut-input-xLocationLookup";
        public static string employeeRecordStatusLookupHook = ".aut-dropdown-xEmployee-xRecordStatus";
        public static string saveButtonHook = ".aut-button-save";
        public static string activeOptionHook = ".aut-button-activeOption";
        public static string employeeEditHook = ".aut-button-edit";

    }

}
