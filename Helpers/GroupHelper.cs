using System;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public const string GROUPWINTITLE = "Group editor";
        public const string DELETEGROUPWINTITLE = "Delete group";
        public GroupHelper(ApplicationManager applicationManager) : base(applicationManager)
        {

        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = ApplicationManager.Aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = ApplicationManager.Aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetText", $"#0|#{i}", "");
                list.Add(new GroupData(item));
            }
            CloseGroupsDialogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            ApplicationManager.Aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            ApplicationManager.Aux.Send(newGroup.Name);
            ApplicationManager.Aux.Send("{ENTER}");
            CloseGroupsDialogue();
        }

        public void Delete(int groupNumber)
        {
            OpenGroupsDialogue();
            ApplicationManager.Aux.ControlTreeView(GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", $"#0|#{groupNumber}", "");
            ApplicationManager.Aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            ApplicationManager.Aux.WinWait(DELETEGROUPWINTITLE);
            ApplicationManager.Aux.ControlClick(DELETEGROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            ApplicationManager.Aux.WinWaitClose(DELETEGROUPWINTITLE);
            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            ApplicationManager.Aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
            ApplicationManager.Aux.WinWaitClose(GROUPWINTITLE);
        }

        private void OpenGroupsDialogue()
        {
            ApplicationManager.Aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            ApplicationManager.Aux.WinWait(GROUPWINTITLE);
        }
    }
}