using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests:AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("First name1", "Last Name1", "Address company1");
            contact.Middlename = "Middle name";
            contact.Nickname = "Nickname";
            contact.Photo = "";
            contact.Title = "Title";
            contact.Company = "Company";
            contact.Address = "Address company";
            contact.Telhome = "Tel home";
            contact.Telmobile = "Tel mobile";
            contact.Telwork = "Tel work";
            contact.Telfax = "Tel fax";
            contact.Email1 = "email1";
            contact.Email2 = "email2";
            contact.Email3 = "email3";
            contact.Homepage = "homepage";
            contact.Bday = "1";
            contact.Bmonth = "January";
            contact.Byear = "1988";
            contact.Aday = "1";
            contact.Amonth = "January";
            contact.Ayear = "2008";
            contact.Newgroup = "[none]";
            contact.Address2 = "adress sec";
            contact.Phone2 = "home sec";
            contact.Notes = "notes sec";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }


    }
}
