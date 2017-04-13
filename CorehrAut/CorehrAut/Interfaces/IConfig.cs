using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorehrAut.Configuration;
using CorehrAut;
using System.Configuration;

namespace CorehrAut.Interfaces
{
   public  interface IConfig
    {
        BrowserType GetBrowser();
        string GetUsername();
        string GetPassword();
        string BaseUrl();
        string DriverLocation();
        int GetPageLoadTimeOut();
        int GetImplicitElementLoadTimeout();
        int GetExplicitElementLoadTimeout();
    }
}
