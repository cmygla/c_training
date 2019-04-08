using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            int num = 1;
            if (!app.Groups.GroupExists(num))
            {
                GroupData group = new GroupData("");
                app.Groups.Create(group);
                num = 1;
            }
            app.Groups.Remove(num);
        }
    }
}
