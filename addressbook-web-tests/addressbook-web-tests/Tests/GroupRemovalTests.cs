using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            int num = 0;
            if (!app.Groups.GroupExists(num))
            {
                GroupData group = new GroupData("");
                app.Groups.Create(group);
                num = 0;
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(num);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //Так всегда удаляют первый элемент
            GroupData toBeRemoved = oldGroups[num];
            oldGroups.RemoveAt(num);
            Assert.AreEqual(oldGroups, newGroups);
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }
    }
}
