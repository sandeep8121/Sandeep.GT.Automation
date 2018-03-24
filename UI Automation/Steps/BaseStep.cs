using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UI_Automation.Browser;

namespace UI_Automation.StepDef
{
    public class BaseStep
    {

        public static void LoadApplication()
        {
            BrowserHandler.InitBrowser("Firefox");
            BrowserHandler.Driver.Navigate().GoToUrl("URL"); // add url from app.config
        }

        [AfterScenario]
        public static void CloseApplication()
        {
            BrowserHandler.CloseAllDrivers();
        }
    }
}
