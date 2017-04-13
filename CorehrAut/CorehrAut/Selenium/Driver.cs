using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System.Threading;
using CorehrAut.Interfaces;
using CorehrAut.Configuration;
using CorehrAut.Settings;
using CorehrAut;
using CorehrAut.Keywords;


namespace CorehrAut
{
    public class Driver
    {

        
       public static DateTime d = DateTime.Now;
        public static IWebDriver Instance { get; set; }

        public static void NoWait(Action action)
        {
            TurnOffWait();
            action();
            TurnOnWait();
        }

        public static void TurnOnWait()
        {
            wait(TimeSpan.FromSeconds(3));
        }
        
        public static void TurnOffWait()
        {
            wait(TimeSpan.FromSeconds(0));
        }

        public static string dateAndTime
        {
            get
            {
                return d.ToString("yyyyMMddHHmmssfff");
            }
        }

        public static void Initialize(BrowserType driver)
        {
            IConfig config = new AppConfigReader();
            switch (driver)
            {
                case BrowserType.Chrome:
                    Instance = new ChromeDriver(@"E:\CHR\CorehrAut\packages\WebDriver.ChromeDriver.win32.2.28.0.0\content");
                    TurnOnWait();
                    Thread.Sleep(3000);
                    break;
                case BrowserType.Firefox:
                    Instance = new FirefoxDriver();
                    TurnOnWait();
                    break;
                case BrowserType.IExplorer:
                    Instance = new InternetExplorerDriver();
                    TurnOnWait();
                    break;
                case BrowserType.PhantomJS:
                    Instance = new PhantomJSDriver(@"E:\CHR\CorehrAut\CorehrAut");
                    TurnOnWait();
                    break;
            }
        }
        public static void wait(TimeSpan timeSpan)
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds((int)timeSpan.TotalSeconds * 1000);
            //Thread.Sleep((int) timeSpan.TotalSeconds * 1000);
        }
    }
    
    }