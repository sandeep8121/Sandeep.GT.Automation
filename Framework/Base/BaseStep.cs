using System;
using Framework.Configuration;
using Framework.Extensions;

namespace Framework.Base
{
    public class BaseStep : Base
    {
        public virtual void NavigateToSite()
        {
            InitializeTest.OpenBrowser(Settings.BrowserType);            
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT); 
            if(!Settings.BrowserType.Equals(BrowserType.FireFox))               
               DriverContext.Driver.Manage().Window.Maximize();            
        }
    }
}

