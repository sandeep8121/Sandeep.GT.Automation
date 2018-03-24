using System;
using Framework.Configuration;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using Protractor;

namespace Framework.Base
{
    public abstract class InitializeTest : Base
    {
        public static void InitializeSettings()
        {
            //Set all the settings for framework
            ConfigReader.SetFrameworkSettings();

        }
        

        public static void OpenBrowser(BrowserType browserType)
        {
            try
            {
                switch (browserType)
                {
                    case BrowserType.InternetExplorer:
                        DriverContext.Driver = new InternetExplorerDriver();
                        break;

                    case BrowserType.FireFox:
                        DriverContext.Driver = new FirefoxDriver();
                        DriverContext.NgDriver = new NgWebDriver(DriverContext.Driver);
                        break;

                    case BrowserType.Chrome:
                        DriverContext.Driver = new ChromeDriver();
                        DriverContext.NgDriver = new NgWebDriver(DriverContext.Driver);
                        break;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
    


