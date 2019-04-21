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

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Photo = "",
                    Title = GenerateRandomString(30),
                    Company = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    Telhome = GenerateRandomString(30),
                    Telmobile = GenerateRandomString(30),
                    Telwork = GenerateRandomString(30),
                    Telfax = GenerateRandomString(30),
                    Email1 = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30),
                    Homepage = GenerateRandomString(30),
                    Bday = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 28)),
                    Bmonth = "January",
                    Byear = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 9999)),
                    Aday = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 28)),
                    Amonth = "January",
                    Ayear = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 9999)),
                    Newgroup = "[none]",
                    Address2 = GenerateRandomString(30),
                    Phone2 = GenerateRandomString(30),
                    Notes = GenerateRandomString(30)

                });
            }
            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
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
