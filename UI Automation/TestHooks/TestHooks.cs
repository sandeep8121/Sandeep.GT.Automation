using System;
using TechTalk.SpecFlow;
using Framework.Base;
using NUnit.Framework;
using System.Configuration;


namespace UI_Automation.TestHooks
{
    [Binding]
    public class TestHooks : InitializeTest
    {
        [BeforeFeature]
        public static void StartSetUp()
        {
            Console.WriteLine("Entering Feature setup");
            InitializeSettings();          
        }

        [BeforeScenario("Dev","Test")]
        public void CheckTestData()
        {
            Console.WriteLine("Entering Scenario setup setup");
            var tagsList = ScenarioContext.Current.ScenarioInfo.Tags;
            if (tagsList.Length > 0)
            {
                var tagInfo = tagsList[0].ToString().ToUpper();
                if (tagInfo != ConfigurationSettings.AppSettings["Env"].ToUpper())
                {

                    Assert.Ignore("These are environment specific tests, hence IGNORED");
                }
            }


        }  

        [AfterScenario]
        public static void EndBrowser()
        {            
            DriverContext.Driver.Quit();
            DriverContext.Driver.Dispose();
        }
    }
}
