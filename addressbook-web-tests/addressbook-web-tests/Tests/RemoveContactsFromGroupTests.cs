using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    class RemoveContactsFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();

            ContactData contact = ContactData.GetAll().Intersect(oldList).First();
            oldList.Remove(contact);
            oldList.Sort();

            //actions
            app.Contacts.RemoveContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}