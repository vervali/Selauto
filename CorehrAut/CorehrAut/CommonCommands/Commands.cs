using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;



namespace CorehrAut.CommonCommands
{
    class Commands
    {
       
        public static void Element(string hookName)
        {
            try
            {
                Keywords.Keywords.Driver.FindElement(By.CssSelector(hookName));
                Keywords.Keywords.Driver.FindElements(By.CssSelector(hookName));
                Keywords.Keywords.wait(TimeSpan.FromSeconds(60));
                Console.WriteLine("Status : OK");
            }
            catch
            {
                Console.WriteLine($"Element : {0}, not found even after 60 seconds", hookName);
            }
            

        }
        public static void Click(string hookName)
        {
            try
            {

                Keywords.Keywords.Driver.FindElement(By.CssSelector(hookName)).Click();
                Keywords.Keywords.wait(TimeSpan.FromSeconds(5));
                Console.WriteLine($"Element : {0} found, Status : OK", hookName);
            }
            catch
            {
                Console.WriteLine($"Element : {0}, not found even after 60 seconds", hookName);
            }


        }
        public static void Click(string hookName, int number)
        {
            try
            {

                Keywords.Keywords.Driver.FindElements(By.CssSelector(hookName))[number].Click();
                Keywords.Keywords.wait(TimeSpan.FromSeconds(5));
                Console.WriteLine($"Element : {0} found, Status : OK", hookName);
            }

             catch
            {
                Console.WriteLine($"Element : {0} {1}, not found even after 60 seconds", hookName + number);
            }

        }
        public static void TypeText(string hookName, string text)
        {
            try
            {

                Keywords.Keywords.Driver.FindElement(By.CssSelector(hookName)).SendKeys(text);
                Keywords.Keywords.wait(TimeSpan.FromSeconds(5));
                Console.WriteLine($"Element : {0} found, Status : OK", hookName);
            }

            catch
            {
                Console.WriteLine($"Unable to send : {0}, to : {1}", text + hookName);
                throw new Exception("Error Occured");
               
            }
        }
        public static void Click(string outerHookName, string innerHookName)
        {

            Keywords.Keywords.Driver.FindElement(By.CssSelector(outerHookName)).Click();
            Keywords.Keywords.wait(TimeSpan.FromSeconds(10));
            Keywords.Keywords.Driver.FindElement(By.CssSelector(innerHookName)).Click();
            Keywords.Keywords.wait(TimeSpan.FromSeconds(10));
        }
        /*public enum SelectorType
        {
            CssSelector,
            LinkText,
            Xpath,
            PartialLinkText,
            ClassName,
            Id,
            TagName,
            Name

        }*/

        public enum ActionType
        {
            Click,
            SendKeys

        }

        private static By GetElementLocator(How locator, string hookName)
        {
            switch (locator)
            {
                case How.CssSelector:
                    return By.CssSelector(hookName);

                case How.ClassName:
                    return By.ClassName(hookName);

                case How.LinkText:
                    return By.LinkText(hookName);

                case How.XPath:
                    return By.XPath(hookName);

                case How.PartialLinkText:
                    return By.PartialLinkText(hookName);

                case How.Id:
                    return By.Id(hookName);

                case How.TagName:
                    return By.TagName(hookName);

                case How.Name:
                    return By.Name(hookName);
                default:
                    return By.CssSelector(hookName);

            }
        }
        public static void PerformAction(ActionType action, How locator, string hookName, params string[] args)
        {
            switch (action)
            {
                case ActionType.Click:
                    //ButtonHelper.ClickButton(GetElementLocator(locator, hookName));
                    
                    break;

                case ActionType.SendKeys:
                    //TextBoxHelper.ClearTextBox(GetElementLocator(selectorType, hookName));
                    //TextBoxHelper.TypeInTextBox(GetElementLocator(locator, hookName), args[0]);
                    break;


            }
        }
    }
}
