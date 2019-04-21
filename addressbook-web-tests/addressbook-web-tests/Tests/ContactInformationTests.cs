using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {

        [Test]
        public void ContactInformationFromMainPage()
        {
            int num = 0;
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(num);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(num);

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }

        [Test]
        public void ContactInformationFromContactDetails()
        {
            int num = 1;
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(num);
            string fromDetails = app.Contacts.GetContactInformationFromDetails(num);

            //verification
            Assert.AreEqual(fromForm.CollapsedInfo, fromDetails);

        }
    }
}
