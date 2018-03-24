using System;
using System.Xml.XPath;
using System.IO;
using Framework.Base;
using Framework.Helpers;
using System.Configuration;


namespace Framework.Configuration
{
    class ConfigReader
    {

        public static void SetFrameworkSettings()
        {

            XPathItem aut;           
            XPathItem islog;           
            XPathItem logPath;
            XPathItem appConnection;
            XPathItem browsertype;
            XPathItem screenShotPath;
            XPathItem isScreenShot;            

            string strFilename = null;
            try
            {
                File.AppendAllText($"{CommonHelper.AssemblyDirectory}\\log.txt", $"Reading config file");

                if (ConfigurationSettings.AppSettings["Env"].ToUpper().Equals("DEV"))
                {
                    Console.WriteLine("Enterning to read ConfiDev xml");
                    strFilename = Path.Combine(CommonHelper.AssemblyDirectory, "Configuration\\ConfigDev.xml");
                    Console.WriteLine(strFilename);                    
                }
                else if (ConfigurationSettings.AppSettings["Env"].ToUpper().Equals("TEST"))
                {
                    strFilename = Path.Combine(CommonHelper.AssemblyDirectory, "Configuration\\ConfigTest.xml");
                }               
            }
            catch (Exception e)
            {                
                throw e;
            }

            FileStream stream = new FileStream(strFilename, FileMode.Open);
            XPathDocument document = new XPathDocument(stream);
            XPathNavigator navigator = document.CreateNavigator();                       

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("FrameworkConfig/RunSettings/AUT");                     
            islog = navigator.SelectSingleNode("FrameworkConfig/RunSettings/IsLog");           
            logPath = navigator.SelectSingleNode("FrameworkConfig/RunSettings/LogPath");
            screenShotPath = navigator.SelectSingleNode("FrameworkConfig/RunSettings/ScreenShotPath");
            appConnection = navigator.SelectSingleNode("FrameworkConfig/RunSettings/ApplicationDb");
            browsertype = navigator.SelectSingleNode("FrameworkConfig/RunSettings/Browser");
            isScreenShot = navigator.SelectSingleNode("FrameworkConfig/RunSettings/IsScreenShot");

            //Set XML Details in the property to be used accross FrameworkConfig
            Settings.AUT = aut.Value.ToString();                 
            Settings.IsLog = islog.Value.ToString();           
            Settings.LogPath = logPath.Value.ToString();
            Settings.ScreenShotPath = screenShotPath.Value.ToString();
            Settings.IsScreenShot = isScreenShot.Value.ToString();         
            Settings.BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType),browsertype.Value.ToString());
        }
    }
}
