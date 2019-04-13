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
            ContactData newData = new ContactData("First name4", "Last Name4", "Address company4");
            newData.Middlename = "Middle name2";
            newData.Nickname = "Nickname2";
            newData.Photo = "";
            newData.Title = "Title2";
            newData.Company = "Company2";
            newData.Address = "Address company2";
            newData.Telhome = "Tel home2";
            newData.Telmobile = "Tel mobile2";
            newData.Telwork = "Tel work2";
            newData.Telfax = "Tel fax2";
            newData.Email1 = "email12";
            newData.Email2 = "email22";
            newData.Email3 = "email32";
            newData.Homepage = "homepage";
            newData.Bday = "2";
            newData.Bmonth = "January";
            newData.Byear = "1989";
            newData.Aday = "2";
            newData.Amonth = "January";
            newData.Ayear = "2009";
            newData.Address2 = "adress sec2";
            newData.Phone2 = "home sec2";
            newData.Notes = "notes sec2";

            int num = 0;
            if (!app.Contacts.ContactExists(num))
            {
                ContactData contact1 = new ContactData("","","");
                app.Contacts.Create(contact1);
                num = 0;
            }

            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[num];

            app.Contacts.Modify(num, newData);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[num].Firstname = newData.Firstname;
            oldContacts[num].Lastname = newData.Lastname;
            oldContacts[num].Address = newData.Address;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData, contact);
                }
            }
        }
    }
}
