using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests:TestBase
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

            app.Contacts.Create(contact);

        }


    }
}
