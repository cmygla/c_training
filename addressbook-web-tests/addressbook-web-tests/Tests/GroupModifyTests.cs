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
            int num = 1;
            GroupData newdata = new GroupData("modified group");
            newdata.Header = "modified group";
            newdata.Footer = "modified group";

            if (!app.Groups.GroupExists(num))
            {
                GroupData group = new GroupData("");
                app.Groups.Create(group);
                num = 1;
            }
            app.Groups.Modify(num, newdata);
        }


    }
}

