using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int num = 1;
            if (!app.Contacts.ContactExists(num))
            {
                ContactData contact1 = new ContactData("", "", "");
                app.Contacts.Create(contact1);
                num = 1;
            }
            app.Contacts.Remove(num);
        }
    }
}