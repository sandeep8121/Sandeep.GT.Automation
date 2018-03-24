using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Framework.Base;
using Framework.Helpers;

namespace Framework.Extensions
{
    public static class WebElementExtensions
    {

        public static void ScrollToElement(IWebElement element)
        {
            try
            {
                Actions actions = new Actions(DriverContext.Driver);

                var coordinateX = ((ILocatable)element).Coordinates.LocationInViewport.X;
                var coordinateY = ((ILocatable)element).Coordinates.LocationInViewport.Y;

                actions.MoveToElement(element).MoveByOffset(coordinateX, coordinateY);
                
                actions.Build().Perform();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ScrollToClick(this IWebElement element)
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    element.Click();
                    return;
                }
                catch (Exception)
                {
                    try
                    {
                        ScrollToElementNotInView(element);
                        element.Click();
                        return;
                    }
                    catch (Exception)
                    {
                        try
                        {
                            ScrollToElementLongList(element, -100);
                            element.Click();
                            return;
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            throw new Exception("The ScrollClick function failed");
        }              
            

        public static object ScrollToElementNotInView(IWebElement element)
        {
            try
            {                
                return ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);                
            }
            catch (Exception)
            {
                throw;
            }
        }       
       

        public static void ScrollToElementLongList(this IWebElement element, int scrollSize)
        {
            try
            {              

                ((IJavaScriptExecutor)DriverContext.Driver).ExecuteScript($"arguments[0].scrollIntoView(true);window.scrollBy(0,{scrollSize});", element);
                CommonHelper.IntroduceSleep(100);
            }
            catch (Exception)
            {
                throw;
            }
        }        
        
        public static bool CaseContains(this string baseString, string textToSearch, StringComparison comparisonMode)
        {
            try
            {
                return (baseString.IndexOf(textToSearch, comparisonMode) != -1);
            }
            catch(Exception e)
            {
                throw e;
            }
        }      


        public static IList<IWebElement> GetSelectedListOptions(this IWebElement element)
        {
            SelectElement ddl = new SelectElement(element);

            return ddl.AllSelectedOptions;
        }


        public static IList<IWebElement> GetNgModalDropDownValues(this IList<IWebElement> element)
        {
            try
            {
                IList<IWebElement> allDropDownValues = new List<IWebElement>();
                foreach (IWebElement item in element)
                {
                    if (item.Text != "")
                    {
                        allDropDownValues.Add(item);
                    }
                }

                return allDropDownValues;
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

        public static void EnterText(this IWebElement element, string text)
        {
            try
            {
                ScrollToElementNotInView(element);
                element.Clear();
                element.SendKeys(text);
            }
            catch(Exception e)
            {
                throw e;
            }
        }     


        public static string GetText(this IWebElement element)
        {
            try
            {                
                return element.Text;                
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static void Hover(this IWebElement element)
        {
            Actions actions = new Actions(DriverContext.Driver);
            actions.MoveToElement(element).Build().Perform();
        }          

        private static bool IsElementPresent(this IWebElement element)
        {
            try
            {
                bool ele = element.Displayed;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
