using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using Framework.Helpers;
using UI_Automation.Pages;
using UI_Automation.Implementation;


namespace UI_Automation.Steps
{
    [Binding]
    public class GameTwistSteps : GameTwistImpl
    {
        [Given(@"A browser is on Game twist HomePage")]
        public void GivenABrowserIsOnGameTwistHomePage()
        {
            try
            {
                NavigateToSite();
                CurrentPage = GetInstance<HomePage>();
                Assert.True(ClickOnCookiesOk(), "Click on the cookies OK failed");                
            }
            catch(Exception e)
            {
                CommonHelper.TakeScreenShot();
                throw e;
            }
        }

        [Given(@"User clicks on Register and completes the Registration with ""(.*)"" and ""(.*)""")]
        public void GivenUserClicksOnRegisterAndCompletesTheRegistrationWithAnd(string Email, string NickName)
        {
            try
            {
                Assert.True(ClickOnRegister(), "Click on the Register buttom failed");
                CompleteRegistration(Email, NickName);
                ClosePopUpsAfterLogin();
            }
            catch (Exception e)
            {
                CommonHelper.TakeScreenShot();
                throw e;
            }
        }         

        [Given(@"User does a successful Login with ""(.*)""")]
        public void GivenUserDoesASuccessfulLoginWith(string nickName)
        {
            try
            {
                Login(nickName);
                ClosePopUpsAfterLogin();
                Assert.True(IsLoginSuccessful(nickName));
            }
            catch (Exception e)
            {
                CommonHelper.TakeScreenShot();
                throw e;
            }
        }

        [Given(@"User navigates through the pages Slots,Bingo,Casino and Poker")]
        public void GivenUserNavigatesThroughThePagesSlotsBingoCasinoAndPoker()
        {
            try
            {
                Assert.True(ClickOnSlotsPage());
                Assert.True(ClickOnBingoPage());
                Assert.True(ClickOnCasinoPage());
                Assert.True(ClickOnPokerPage());
            }
            catch(Exception e)
            {
                CommonHelper.TakeScreenShot();
                throw e;
            }
        }

        [When(@"A search is done for a ""(.*)"" and confirmed that a right game is selected")]
        public void WhenASearchIsDoneForAAndConfirmedThatARightGameIsSelected(string gameToSearch)
        {
            try
            {
                Assert.AreEqual(5, SearchForGameAndCheckCount(gameToSearch));
                Assert.True(ClickOnSearchedGame());
            }
            catch(Exception e)
            {
                CommonHelper.TakeScreenShot();
                throw e;
            }
        }

        [Then(@"User changes the ""(.*)"" and does a successful logout")]
        public void ThenUserChangesTheAndDoesASuccessfulLogout(string languageToChange)
        {
            try
            {
                Assert.True(ChangeLanguage(languageToChange), "Change Language failed");
                Assert.True(LogOut(), "Logout failed");
            }
            catch (Exception e)
            {
                CommonHelper.TakeScreenShot();
                throw e;
            }
        }


    }
}
