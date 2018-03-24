using System;
using OpenQA.Selenium;
using Framework.Base;
using System.Diagnostics;
using OpenQA.Selenium.Support.UI;
using System.Linq.Expressions;
using OpenQA.Selenium.Interactions;

namespace Framework.Extensions
{
    public static class WebDriverExtensions
    {
        public static void WaitForDOMReady(this IWebDriver driver)
        {
            driver.WaitForCondition(dri =>
            {
                string state = dri.ExecuteJs("return document.readyState").ToString();
                return state == "complete";
            }, 60);
        }

        public static void WaitForCondition<T>(this T obj, Func<T, bool> condition, int timeOut)
        {
            Func<T, bool> execute =
                (arg) =>
                {
                    try
                    {
                        return condition(arg);
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                };

            var stopWatch = Stopwatch.StartNew();
            while (stopWatch.ElapsedMilliseconds < timeOut)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }       


        public static object ExecuteJs(this IWebDriver driver, string script)
        {
            return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript(script);
        }       

        public static void WaitForPageLoad(this IWebDriver driver)
        {
            DriverContext.Driver.Manage().Timeouts().AsynchronousJavaScript.Seconds.Equals(30);
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(20));
            wait.Until((d) => { return DriverContext.Driver.AngularHasFinishedProcessing(); });
        }

        private static bool AngularHasFinishedProcessing(this IWebDriver driver)
        {
            string HasAngularFinishedScript =
                @"var callback = arguments[arguments.length - 1];
            var el = document.querySelector('html');
            if (!window.angular) {
                callback('False')
            }
            if (angular.getTestability) {
                angular.getTestability(el).whenStable(function(){callback('True')});
            } else {
                if (!angular.element(el).injector()) {
                    callback('False')
                }
                var browser = angular.element(el).injector().get('$browser');
                browser.notifyWhenNoOutstandingRequests(function(){callback('True')});
            }";
            IJavaScriptExecutor javascriptExecutor = (IJavaScriptExecutor)driver;
            return Convert.ToBoolean(javascriptExecutor.ExecuteAsyncScript(HasAngularFinishedScript));
        }        

        public static void SwitchToFrame(this IWebDriver driver, IWebElement element)
        {
            try
            {
                driver.SwitchTo().Frame(element);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Boolean WaitForElementToBeVisible(this IWebDriver driver, IWebElement element, int timeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeOut));
                wait.Until(d => (bool)(element as IWebElement).Displayed);
                return true;
            }
            catch (NoSuchElementException e)
            {
                throw e;
            }
        }

        public static void WaitForElementToBeInVisible(this IWebDriver driver, By locator, int timeOut)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void WaitForElementToVisible(this IWebDriver driver, By locator, int timeOut)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        }        

        public static void WaitForElementToBeLoaded(this IWebDriver driver, By locator, int timeOut)
        {
            WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            webDriverWait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public static object WaitForElementToBeClickable(this IWebDriver driver, IWebElement element, int timeOut)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                return wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (ElementNotVisibleException e)
            {
                throw e;
            }
        }
    }
}
