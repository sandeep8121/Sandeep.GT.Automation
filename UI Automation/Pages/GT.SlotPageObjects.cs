using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;


namespace UI_Automation.Pages
{
    public class SlotPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//nav[@id = 'navigation-main']//ul//li/a[contains(@href, 'bingo')]")]
        public IWebElement tabBingoPage { get; set; }


        public BingoPage NavigateToBingoPage()
        {
            tabBingoPage.ScrollToClick();
            return new BingoPage();
        }
    }
}
