using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class RegisterPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "register__nickname")]
        public IWebElement txtNickName { get; set; }

        [FindsBy(How = How.Id, Using = "register__email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "register__password")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "register__repeatPassword")]
        public IWebElement txtRepeatPassword { get; set; }

        [FindsBy(How = How.XPath, Using = ".//input[@id = 'register__termsAccept']/..//label")]
        public IWebElement chkAgree { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@id = 'recaptcha-anchor']//div[contains(@class, 'checkmark')]")]
        public IWebElement chkCaptcha { get; set; }

        [FindsBy(How = How.XPath, Using = ".//span[@id = 'recaptcha-anchor' and @aria-checked = 'true']")]
        public IWebElement chkClickedCaptcha { get; set; }

        [FindsBy(How = How.XPath, Using = ".//iframe[@role = 'presentation']")]
        public IWebElement frameRegister { get; set; }

        [FindsBy(How = How.Id, Using = "user_registration_save_button")]
        public IWebElement btnSaveRegister { get; set; }


        public RegisterSuccessPage ClickOnSaveRegistration()
        {
            btnSaveRegister.ScrollToClick();
            return new RegisterSuccessPage();
        }
    }
}
