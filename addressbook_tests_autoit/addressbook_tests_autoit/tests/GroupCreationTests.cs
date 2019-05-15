using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests:TestBase
    {
        [Test]
        public void TestGroupCreation()
        {
            List<GroupData> oldGroups = app.Groups.CheckGroupDialog();
            GroupData newGroup = new GroupData()
            {
                Name = "Test"
            };
            app.Groups.AddGroupDialog(newGroup);
            List<GroupData> newGroups = app.Groups.CheckGroupDialog();
            oldGroups.Add(newGroup);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups,newGroups);

        }
    }
}
