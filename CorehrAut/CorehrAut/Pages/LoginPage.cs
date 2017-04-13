using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using CorehrAut.CommonCommands;
using CorehrAut.Navigation;
using CorehrAut.Interfaces;
using CorehrAut.Configuration;
using CorehrAut.Keywords;
using CorehrAut.Settings;
using OpenQA.Selenium.Support.PageObjects;


namespace CorehrAut.Pages
{
    public class LoginPage
    {
        //Refactor : should have a general menu system;
        public static void Goto()
        {
            IConfig config = new AppConfigReader();
            Keywords.Keywords.Driver.Manage().Window.Maximize();
            Keywords.Keywords.Driver.Navigate().GoToUrl(config.BaseUrl());
            var wait = new WebDriverWait(Keywords.Keywords.Driver, TimeSpan.FromSeconds(10));
            try
            {
                wait.Until(d => d.Title.Equals("Log In"));
            }
            catch
            {
                Console.WriteLine("Webpage not displayed");
                Keywords.Keywords.Driver.Quit();
            }
           
        }

        public static void CloseBrowser()
        {
            Keywords.Keywords.Driver.Quit();
        }

        public static LoginCommand LoginAs(string userName)
        {
            return new LoginCommand(userName);
        }
    }

    public class LoginCommand
    {
        public readonly string userName;
        public string password;
        public LoginCommand(string userName)
        {
            this.userName = userName;
        }
        
        public LoginCommand WithPassword(string password)
        {
            this.password = password;
            return this;
        }

        public void Login()
        {
            //Keywords.Keywords.userNameTextBox.SendKeys(userName);
            Commands.TypeText(Keywords.Keywords.usernameHook, userName);
            Commands.TypeText(Keywords.Keywords.passwordHook, password);
            Commands.Click(Keywords.Keywords.loginButtonhook);
            
            
         }

        
    }
}
