using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = app.Groups.CheckGroupDialog();
            List<GroupData> newGroups = new List<GroupData>();

            if (oldGroups.Count == 1)
            {
                app.Groups.AddGroupDialog(new GroupData()
                {
                    Name = "AnyGroup"
                });

                oldGroups = app.Groups.CheckGroupDialog();
            }

            app.Groups.RemoveGroupDialog(0);
            newGroups = app.Groups.CheckGroupDialog();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
