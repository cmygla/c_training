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

            GroupData group = new GroupData("Default");
            ContactData contact = new ContactData("Default", "Default", "Default");
            List<ContactData> oldList = new List<ContactData>();

            bool AddContactToGroup = false;

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
                List<ContactData> contactsToDelete = ContactData.GetAll().Intersect(oldList).ToList();
                if (contactsToDelete.Count>0)
                {
                    contact = contactsToDelete.First();
                    AddContactToGroup = false;
                    break;
                }
                else
                {
                    AddContactToGroup = true;
                    continue;
                }
            }
            if (ContactData.GetAll().Count() == 0)
            {
                app.Contacts.Create(contact);                
            }

            if (AddContactToGroup == true)
            {
                contact = ContactData.GetAll().Last();
                app.Contacts.AddContactToGroup(contact, group);
            }

            //actions
            app.Contacts.RemoveContactFromGroup(contact, group);

            oldList.Remove(contact);
            oldList.Sort();
            List<ContactData> newList = group.GetContacts();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}