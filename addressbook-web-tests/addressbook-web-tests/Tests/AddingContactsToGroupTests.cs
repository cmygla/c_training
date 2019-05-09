using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AddingContactsToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = new GroupData("Default");
            ContactData contact = new ContactData("Default", "Default", "Default");
            List<ContactData> oldList = new List<ContactData>();

            bool createNewContact = false;

            int group_amount = GroupData.GetAll().Count;
            if (group_amount == 0)
            {
                app.Groups.Create(group);
                group = GroupData.GetAll().First();
                group_amount++;
            }
            for (int i = 0; i < group_amount; i++)
            {
                group = GroupData.GetAll()[i];
                oldList = group.GetContacts();
                List<ContactData> contactsNotInGroup = ContactData.GetAll().Except(oldList).ToList();
                if (contactsNotInGroup.Count != 0)
                {
                    contact = contactsNotInGroup.First();
                    createNewContact = false;
                    break;
                }
                else
                {
                    createNewContact = true;
                    continue;
                }
            }

            if (createNewContact == true || ContactData.GetAll().Count() == 0)
            {
                app.Contacts.Create(contact);
                contact = ContactData.GetAll().Last();
            }

            //actions
            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
