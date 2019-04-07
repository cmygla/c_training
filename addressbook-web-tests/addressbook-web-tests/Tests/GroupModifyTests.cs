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
            GroupData newdata = new GroupData("modified group");
            newdata.Header = "modified group";
            newdata.Footer = "modified group";
            app.Groups.Modify(1,newdata);
        }


    }
}

