using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class CasinoPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//nav[@id = 'navigation-main']//ul//li/a[contains(@href, 'poker')]")]
        public IWebElement tabPokerPage { get; set; }


        public PokerPage NavigateToPokerPage()
        {
            tabPokerPage.ScrollToClick();
            return new PokerPage();
        }
    }
}
