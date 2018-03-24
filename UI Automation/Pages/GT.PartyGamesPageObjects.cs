using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class PartyGamesPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//div[@id = 'change_email_confirm']//button[contains(text(), 'Close')]")]
        public IWebElement btnCloseEmailConfirmation { get; set; }


        public RegisterSuccessPage CloseEmailConfirmation()
        {
            btnCloseEmailConfirmation.ScrollToClick();
            return new RegisterSuccessPage();
        }
    }
}
