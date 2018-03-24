using TechTalk.SpecFlow;

namespace Framework.Base
{
    public class Base
    {

        public BasePage CurrentPage
        {
            get
            {
                return (BasePage)ScenarioContext.Current["currentPage"];
            }
            set
            {
                ScenarioContext.Current["currentPage"] = value;
            }
        }

        protected TPage GetInstance<TPage>() where TPage : new()
        {
            TPage pageInstance = new TPage()
            {
             
            };           
            return pageInstance;           
        }


        public TPage As<TPage>() where TPage : BasePage
        {
            return (TPage)this;
        }    
    }
}
