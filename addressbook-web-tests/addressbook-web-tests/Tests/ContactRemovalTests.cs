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
            int num = 0;
            if (!app.Contacts.ContactExists(num))
            {
                ContactData contact = new ContactData("", "", "");
                app.Contacts.Create(contact);
                num = 0;
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(num);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            //Так всегда удаляют первый элемент
            ContactData toBeRemoved = oldContacts[num];
            oldContacts.RemoveAt(num);
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}