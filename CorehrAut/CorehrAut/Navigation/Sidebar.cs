using System;
using OpenQA.Selenium;
using CorehrAut.CommonCommands;

namespace CorehrAut.Navigation
{
    public class Sidebar
    {
        public class AppSwitcher
        {
            public class PeoplePage
            {
                public static void Select()
                {
                    AppSwitcher.Select(".aut-button-application-switcher");
                }
            }
            public static void Select(string tag)
            {
                var appSwitcher = Keywords.Keywords.Driver.FindElement(By.CssSelector(tag));
                while (!appSwitcher.Displayed)
                {
                    Keywords.Keywords.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                }
                appSwitcher.Click();
            }
        }
    }
}