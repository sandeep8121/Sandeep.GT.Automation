using Framework.Base;


namespace Framework.Configuration
{
   public class Settings
    {
        public static int Timeout { get; set; }        
        
        public static string AUT { get; set; }        

        public static BrowserType BrowserType { get ; set; }      

        public static string IsLog { get; set; }

        public static string LogPath { get; set; }

        public static string ScreenShotPath { get; set; }

        public static string IsScreenShot { get; set; }        
    }
}
