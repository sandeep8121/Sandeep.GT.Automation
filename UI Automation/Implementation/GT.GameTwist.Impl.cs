using System;
using System.Collections.Generic;
using Framework.Base;
using Framework.Extensions;
using UI_Automation.Pages;
using OpenQA.Selenium;
using Framework.Helpers;
using Protractor;

namespace UI_Automation.Implementation
{
    public class GameTwistImpl : BaseStep
    {
        public Boolean ClickOnCookiesOk()
        {
            Boolean clickOk = false;
            try
            {
                // This is using Protractor
                //DriverContext.NgDriver.WaitForAngular();
                CurrentPage.As<HomePage>().btnCookiesOk.ScrollToClick();
                clickOk = true;
            }

            catch (Exception e)
            {
                throw e;
            }
            return clickOk;
        }

        public Boolean ClickOnRegister()
        {
            Boolean clickOk = false;
            try
            {
                CurrentPage = CurrentPage.As<HomePage>().ClickOnRegister();
                //DriverContext.Driver.WaitForPageLoad();
                if(DriverContext.Driver.Title.Equals("Registration",StringComparison.OrdinalIgnoreCase))
                clickOk = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return clickOk;
        }

        public void CompleteRegistration(string email, string nickName)
        {
            string password = "22Twentytwo";                      
            try
            {
                DriverContext.Driver.WaitForDOMReady();
                CurrentPage.As<RegisterPage>().txtNickName.EnterText(nickName);
                CurrentPage.As<RegisterPage>().txtEmail.EnterText(email);
                CurrentPage.As<RegisterPage>().txtPassword.EnterText(password);
                CurrentPage.As<RegisterPage>().txtRepeatPassword.EnterText(password);
                CurrentPage.As<RegisterPage>().chkAgree.ScrollToClick();
                DriverContext.Driver.SwitchToFrame(CurrentPage.As<RegisterPage>().frameRegister);
                CurrentPage.As<RegisterPage>().chkCaptcha.ScrollToClick();
                DriverContext.Driver.WaitForElementToBeVisible(CurrentPage.As<RegisterPage>().chkClickedCaptcha, 30);
                DriverContext.Driver.SwitchTo().ParentFrame();
                CurrentPage = CurrentPage.As<RegisterPage>().ClickOnSaveRegistration();
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        public void Login(string shortName)
        {            
            string password = "22Twentytwo";
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<HomePage>().txtNickName, 40);
                CurrentPage.As<HomePage>().txtNickName.EnterText(shortName);
                CurrentPage.As<HomePage>().txtPassword.SendKeys(password);
                CurrentPage =  CurrentPage.As<HomePage>().ClickOnLogin();                
            }
            catch (Exception e)
            {
                throw e;
            }           
        }

        public Boolean IsLoginSuccessful(string shortName)
        {
            bool loginOk = false;
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<RegisterSuccessPage>().tabSlotPage, 40);
                if (shortName.Equals(CurrentPage.As<RegisterSuccessPage>().iconNickName.Text.Trim()))
                    loginOk = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return loginOk;
        }

        public void ClosePopUpsAfterLogin()
        {            
            try
            {
                DriverContext.Driver.WaitForDOMReady();
                if (CurrentPage.As<RegisterSuccessPage>().isPresentPopupCollectBonus.Count > 0)
                {
                    DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<RegisterSuccessPage>().popupCollectBonus, 30);
                    CurrentPage.As<RegisterSuccessPage>().popupCollectBonus.Click();
                }

                 CommonHelper.IntroduceSleep(2000); //Sorry for this blunder :(
                //DriverContext.Driver.WaitForDOMReady();
                if (CurrentPage.As<RegisterSuccessPage>().isPresentIconWofPopUpClose.Count > 0)
                {
                    DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<RegisterSuccessPage>().popupWheel, 30);
                    CurrentPage.As<RegisterSuccessPage>().iconWofPopUpClose.Click();
                    DriverContext.Driver.WaitForElementToBeInVisible(By.XPath(".//div[@class = 'WOF-popup']"), 40);
                }                
            }
            catch (Exception e)
            {
                throw e;
            }
        }        

        public Boolean ClickOnSlotsPage()
        {
            Boolean pageOk = false;
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<RegisterSuccessPage>().tabSlotPage, 40);
                CurrentPage = CurrentPage.As<RegisterSuccessPage>().NavigateToSlotPage();
                DriverContext.Driver.WaitForDOMReady();
                pageOk = VerifyPageTitle(DriverContext.Driver.Title);
                if (!pageOk)
                {
                    throw new Exception("The Slot Page verificaiton failed");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return pageOk;
        }

        public Boolean ClickOnBingoPage()
        {
            Boolean pageOk = false;
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<SlotPage>().tabBingoPage, 40);
                CurrentPage = CurrentPage.As<SlotPage>().NavigateToBingoPage();
                DriverContext.Driver.WaitForDOMReady();
                pageOk = VerifyPageTitle(DriverContext.Driver.Title);
                if (!pageOk)
                {
                    throw new Exception("The Bingo Page verificaiton failed");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return pageOk;
        }

        public Boolean ClickOnCasinoPage()
        {
            Boolean pageOk = false;
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<BingoPage>().tabCasinoPage, 40);
                CurrentPage = CurrentPage.As<BingoPage>().NavigateToCasinoPage();
                DriverContext.Driver.WaitForDOMReady();
                pageOk = VerifyPageTitle(DriverContext.Driver.Title);
                if (!pageOk)
                {
                    throw new Exception("The Casino Page verificaiton failed");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return pageOk;
        }

        public Boolean ClickOnPokerPage()
        {
            Boolean pageOk = false;
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<CasinoPage>().tabPokerPage, 40);
                CurrentPage = CurrentPage.As<CasinoPage>().NavigateToPokerPage();
                DriverContext.Driver.WaitForDOMReady();
                pageOk = VerifyPageTitle(DriverContext.Driver.Title);
                if (!pageOk)
                {
                    throw new Exception("The Poker Page verificaiton failed");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return pageOk;
        }

        public Boolean VerifyPageTitle(string driverTitle)
        {
            Boolean verifyOk = false;
            try
            {
                List<object> expectedPageTitle = new List<object>();
                expectedPageTitle.Add("Free Slot Games online | Play for Free at GameTwist");
                expectedPageTitle.Add("Free Bingo Games | Play now for Free at GameTwist");
                expectedPageTitle.Add("Free Casino Games Online | Play for Free at GameTwist");
                expectedPageTitle.Add("Poker Free Online Play | GameTwist Casino");

                if (expectedPageTitle.Contains(driverTitle))
                {
                    verifyOk = true;
                }                    
                               
            }
            catch (Exception e)
            {
                throw e;
            }
            return verifyOk;
        }

        public object SearchForGameAndCheckCount(string game)
        {
            int numberOfGames;
            try
            {
                DriverContext.Driver.WaitForElementToBeClickable(CurrentPage.As<PokerPage>().txtSearch, 40);
                CurrentPage.As<PokerPage>().txtSearch.ScrollToClick();
                CurrentPage.As<PokerPage>().txtSearch.EnterText(game);
                DriverContext.Driver.WaitForElementToBeLoaded(By.XPath(".//ul[contains(@class, 'game-search__list')]//li[@data-id]"), 30);
                numberOfGames = CurrentPage.As<PokerPage>().listSearchResults.Count;
            }
            catch (Exception e)
            {
                throw e;
            }
            return numberOfGames;
        }

        public Boolean ClickOnSearchedGame()
        {
            string pageTitle;
            bool gameSearchOk = false;
            try
            {
                DriverContext.Driver.WaitForDOMReady();
                var selectedGame = CurrentPage.As<PokerPage>().txtOfSelectedGame[2].Text;
                CurrentPage = CurrentPage.As<PokerPage>().NavigateToPartyGamesPage();
                pageTitle = DriverContext.Driver.Title;
                CurrentPage = CurrentPage.As<PartyGamesPage>().CloseEmailConfirmation();

                if (pageTitle.CaseContains(selectedGame, StringComparison.OrdinalIgnoreCase))
                    gameSearchOk = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return gameSearchOk;
        }

        public Boolean ChangeLanguage(string language)
        {
            Boolean langChangeOk = false;
            try
            {
                DriverContext.Driver.WaitForDOMReady();
                CurrentPage.As<RegisterSuccessPage>().iconChangeLanguage.Hover();
                DriverContext.Driver.FindElement(By.XPath($".//li[@class = 'branding__language-and-help']//span[contains(text(), '{language}')]")).ScrollToClick();               
                langChangeOk = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return langChangeOk;
        }

        public Boolean LogOut()
        {
            Boolean logOutOk = false;
            try
            {
                DriverContext.Driver.WaitForDOMReady();               
                CurrentPage.As<RegisterSuccessPage>().iconNickName.ScrollToClick();                
                CurrentPage = CurrentPage.As<RegisterSuccessPage>().NavigateToHomePage();
                DriverContext.Driver.WaitForDOMReady();                
                DriverContext.Driver.WaitForElementToVisible(By.Id("phLogin_login_button"), 60);
                if (CurrentPage.As<HomePage>().btnLogin.Displayed)
                logOutOk = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return logOutOk;
        }


    }
}
