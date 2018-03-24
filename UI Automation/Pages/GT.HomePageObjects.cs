using System.Collections.Generic;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;
using Framework.Base;
using Framework.Extensions;

namespace UI_Automation.Pages
{
    public class HomePage : BasePage
    {        

        [FindsBy(How = How.CssSelector, Using = ".js-cookie-accept-btn")]
        public IWebElement btnCookiesOk { get; set; }       

        [FindsBy(How = How.Id, Using = "header_register_button")]
        public IWebElement btnRegister { get; set; }

        [FindsBy(How = How.Id, Using = "login-nickname-phLogin")]
        public IWebElement txtNickName { get; set; }

        [FindsBy(How = How.Id, Using = "login-password-phLogin")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "phLogin_login_button")]
        public IWebElement btnLogin { get; set; }       

        public RegisterPage ClickOnRegister()
        {
            btnRegister.ScrollToClick();
            return new RegisterPage();
        }

        public RegisterSuccessPage ClickOnLogin()
        {
            btnLogin.ScrollToClick();
            return new RegisterSuccessPage();
        }

    }

    
}
