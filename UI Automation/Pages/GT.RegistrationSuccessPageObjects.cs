using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class RegisterSuccessPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//footer[@class = 'bonus__footer']/a")]
        public IWebElement popupCollectBonus { get; set; }

        [FindsByAll FindsBy(How = How.XPath, Using = ".//footer[@class = 'bonus__footer']/a")]
        public IList<IWebElement> isPresentPopupCollectBonus { get; set; }

        [FindsByAll FindsBy(How = How.XPath, Using = ".//div[@class = 'wheel-start pulse']")]
        public IList<IWebElement> isPresentIconWofPopUpClose { get; set; }

        [FindsBy(How = How.XPath, Using = ".//div[@class = 'wheel-start pulse']")]
        public IWebElement popupWheel { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@class = 'WOF-close-x']/a")]
        public IWebElement iconWofPopUpClose { get; set; }        

        [FindsBy(How = How.XPath, Using = ".//nav[@id = 'navigation-main']//ul//li/a[contains(@href, 'slot')]")]
        public IWebElement tabSlotPage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@class = 'branding__language-and-help']//span[@title = 'Select language']/b")]
        public IWebElement iconChangeLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@class = 'branding__language-and-help']//span[contains(text(), 'Deutsch')]")]
        public IWebElement iconGermanLanguage { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@class = 'branding__user']//span[@class = 'nickname']")]
        public IWebElement iconNickName { get; set; }

        [FindsBy(How = How.XPath, Using = ".//li[@class = 'branding__user']//button[@id = 'link_log_out']")]
        public IWebElement btnLogOut { get; set; }       

        [FindsBy(How = How.XPath, Using = ".//nav[@id = 'navigation-main']//ul//li")]
        public IList<IWebElement> listGamesPages { get; set; }

        public SlotPage NavigateToSlotPage()
        {
            tabSlotPage.ScrollToClick();
            return new SlotPage();
        }

        public HomePage NavigateToHomePage()
        {
            btnLogOut.ScrollToClick();
            return new HomePage();
        }
    }
}
