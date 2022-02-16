using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupTests : TestBase
    {
        [Test]
        public void NewGroupTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            GroupData newGroup = new GroupData("test");
            app.GroupHelper.Add(newGroup);
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void DeleteGroupTest()
        {
            List<GroupData> oldGroups = app.GroupHelper.GetGroupList();
            if (oldGroups.Count == 0)
            {
                GroupData newGroup = new GroupData("test");
                app.GroupHelper.Add(newGroup);
                oldGroups.Add(newGroup);
            }
            app.GroupHelper.Delete(0);
            oldGroups.RemoveAt(0);
            List<GroupData> newGroups = app.GroupHelper.GetGroupList();
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
