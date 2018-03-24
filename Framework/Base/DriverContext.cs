using OpenQA.Selenium;
using Protractor;

namespace Framework.Base
{
/// <summary>
/// This is class is designed to handle the WebDriver Object in one place
/// </summary>

    public static class DriverContext
    {
        private static IWebDriver _driver;
        private static NgWebDriver _ngDriver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }

            set
            {
                _driver = value;
            }
        }

        public static NgWebDriver NgDriver
        {
            get;
            set;
        }
    }    
}
