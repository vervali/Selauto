using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorehrAut.Interfaces;
using System.Configuration;
using CorehrAut.Settings;
using CorehrAut;

namespace CorehrAut.Configuration

{
    public class AppConfigReader : IConfig
    {
        public string BaseUrl()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.BaseUrl);
        }

        public string DriverLocation()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.DriverLocation);
        }

        public BrowserType GetBrowser()
        {
           string browser =   ConfigurationManager.AppSettings.Get(AppConfigKeys.Browser);
           return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
        }

        public int GetExplicitElementLoadTimeout()
        {
            throw new NotImplementedException();
        }

        public int GetImplicitElementLoadTimeout()
        {
            throw new NotImplementedException();
        }

        public int GetPageLoadTimeOut()
        {
            throw new NotImplementedException();
        }

        public string GetPassword()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Password);
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings.Get(AppConfigKeys.Username);
        }

        
    }
}
