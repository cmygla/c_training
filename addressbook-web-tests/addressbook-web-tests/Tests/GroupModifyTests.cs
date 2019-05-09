using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupModifyTests : GroupTestBase
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
                GroupData group = new GroupData("Default");
                app.Groups.Create(group);
                num = 0;
            }
            List<GroupData> oldGroups = GroupData.GetAll();
            oldGroups.Sort();
            GroupData oldData = oldGroups[num];
            oldGroups[num].Name = newData.Name;
            oldGroups[num].Header = newData.Header;
            oldGroups[num].Footer = newData.Footer;
            oldGroups.Sort();

            app.Groups.Modify(num, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            List<GroupData> newGroups = GroupData.GetAll();
            newGroups.Sort();
            //Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                    Assert.AreEqual(newData.Header, group.Header);
                    Assert.AreEqual(newData.Footer, group.Footer);
                }
            }
        }


    }
}

