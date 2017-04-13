using OpenQA.Selenium;

namespace CorehrAut.CommonCommands
{
    public class IsAt
    {
        public static IWebElement pageArea;
        public static bool Page(string pageItem)
        {
                  
            {
                    pageArea = Keywords.Keywords.Driver.FindElement(By.CssSelector(pageItem));
                if (pageArea.Displayed)
                { return pageArea.Displayed; }
                  return false;
            }
        }
    }

}

