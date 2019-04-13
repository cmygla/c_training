using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifyTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            int num = 0;
            GroupData newData = new GroupData("modified group");
            newData.Header = "modified group";
            newData.Footer = "modified group";

            if (!app.Groups.GroupExists(num))
            {
                GroupData group = new GroupData("");
                app.Groups.Create(group);
                num = 0;
            }
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[num];

            app.Groups.Modify(num, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[num].Name= newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }


    }
}

