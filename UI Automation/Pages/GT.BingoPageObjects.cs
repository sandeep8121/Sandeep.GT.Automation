using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class BingoPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//nav[@id = 'navigation-main']//ul//li/a[contains(@href, 'casino')]")]
        public IWebElement tabCasinoPage { get; set; }


        public CasinoPage NavigateToCasinoPage()
        {
            tabCasinoPage.ScrollToClick();
            return new CasinoPage();
        }
    }
}
