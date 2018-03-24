using System;

namespace Framework.Base
{
    public class BrowserFactory
    {        
        public BrowserType Type { get; set; }    
        
    }

    public enum BrowserType
    {
        InternetExplorer,
        FireFox,
        Chrome
    }
}
