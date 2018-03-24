using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class PokerPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "ctl00_cphNavAndSearch_ctl01_gameSearch")]
        public IWebElement txtSearch { get; set; }

        [FindsBy(How = How.XPath, Using = ".//ul[contains(@class, 'game-search__list')]//li[@data-id]")]
        public IList<IWebElement> listSearchResults { get; set; }

        [FindsBy(How = How.XPath, Using = "(.//ul[contains(@class, 'game-search__list')]//li//span[@class = 'header'])")]
        public IList<IWebElement> txtOfSelectedGame { get; set; }


        public PartyGamesPage NavigateToPartyGamesPage()
        {
            listSearchResults[2].ScrollToClick();
            return new PartyGamesPage();
        }
    }
}
