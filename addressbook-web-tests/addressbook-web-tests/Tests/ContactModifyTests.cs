using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class ContactModifyTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactData contact = new ContactData("First name4", "Last Name4", "Address company4");
            contact.Middlename = "Middle name2";
            contact.Nickname = "Nickname2";
            contact.Photo = "";
            contact.Title = "Title2";
            contact.Company = "Company2";
            contact.Address = "Address company2";
            contact.Telhome = "Tel home2";
            contact.Telmobile = "Tel mobile2";
            contact.Telwork = "Tel work2";
            contact.Telfax = "Tel fax2";
            contact.Email1 = "email12";
            contact.Email2 = "email22";
            contact.Email3 = "email32";
            contact.Homepage = "homepage";
            contact.Bday = "2";
            contact.Bmonth = "January";
            contact.Byear = "1989";
            contact.Aday = "2";
            contact.Amonth = "January";
            contact.Ayear = "2009";
            contact.Address2 = "adress sec2";
            contact.Phone2 = "home sec2";
            contact.Notes = "notes sec2";

            app.Contacts.Modify(1, contact);
        }
    }
}
