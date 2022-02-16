using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public const string WINTITLE = "Free Address Book";
        public ApplicationManager()
        {
            Aux = new AutoItX3();
            Aux.Run(@"C:\Users\SSon\Desktop\New folder\AddressBook.exe", nShowFlag: Aux.SW_SHOW);
            Aux.WinWait(WINTITLE);
            Aux.WinActivate(WINTITLE);
            Aux.WinWaitActive(WINTITLE);
            GroupHelper = new GroupHelper(this);
        }
        public AutoItX3 Aux { get; set; }

        public GroupHelper GroupHelper { get; set; }

        public void Stop()
        {
            Aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }
    }
}
