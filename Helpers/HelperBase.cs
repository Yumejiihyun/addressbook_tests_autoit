using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager ApplicationManager;
        protected static string WINTITLE;
        protected AutoItX3 Aux { get; set; }

        public HelperBase(ApplicationManager applicationManager)
        {
            this.ApplicationManager = applicationManager;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}