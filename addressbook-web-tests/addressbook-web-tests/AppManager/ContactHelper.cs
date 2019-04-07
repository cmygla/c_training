using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ContactHelper:BaseHelper
    {

        private ContactData defaultContact = new ContactData("First name0", "Last Name0", "Address company0");

        public ContactHelper(ApplicationManager manager) : base(manager)
        {

            defaultContact.Middlename = "Middle name";
            defaultContact.Nickname = "Nickname";
            defaultContact.Photo = "";
            defaultContact.Title = "Title";
            defaultContact.Company = "Company";
            defaultContact.Address = "Address company";
            defaultContact.Telhome = "Tel home";
            defaultContact.Telmobile = "Tel mobile";
            defaultContact.Telwork = "Tel work";
            defaultContact.Telfax = "Tel fax";
            defaultContact.Email1 = "email1";
            defaultContact.Email2 = "email2";
            defaultContact.Email3 = "email3";
            defaultContact.Homepage = "homepage";
            defaultContact.Bday = "3";
            defaultContact.Bmonth = "January";
            defaultContact.Byear = "1987";
            defaultContact.Aday = "3";
            defaultContact.Amonth = "January";
            defaultContact.Ayear = "2007";
            defaultContact.Newgroup = "[none]";
            defaultContact.Address2 = "adress sec";
            defaultContact.Phone2 = "home sec";
            defaultContact.Notes = "notes sec";
        }

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigator.ReturnToContactsPage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        private int ContactExists(int i)
        {
            i = i + 1;
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]")))
            {
                InitContactCreation();
                FillContactForm(defaultContact);
                SubmitContactCreation();
                manager.Navigator.ReturnToContactsPage();
                i = 2;
            }
            return i;
        }

        public ContactHelper Remove(int i)
        {
            manager.Navigator.ReturnToContactsPage();
            i = ContactExists(i);
            ContactSelection(i);
            ContactDeletion();
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        public ContactHelper Modify(int i, ContactData contact)
        {
            manager.Navigator.ReturnToContactsPage();
            i = ContactExists(i);
            ContactSelection(i);
            InitContactModification(i);
            ModifyContactForm(contact);
            SubmitContactModification();

            manager.Navigator.ReturnToContactsPage();
            return this;
        }



        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();

            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("home"), contact.Telhome);
            Type(By.Name("mobile"), contact.Telmobile);
            Type(By.Name("work"), contact.Telwork);
            Type(By.Name("fax"), contact.Telfax);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);

            driver.FindElement(By.Name("byear")).Click();
            Type(By.Name("byear"), contact.Byear);

            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);

            driver.FindElement(By.Name("ayear")).Click();
            Type(By.Name("ayear"), contact.Ayear);

            driver.FindElement(By.Name("new_group")).Click();
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText(contact.Newgroup);

            driver.FindElement(By.Name("address2")).Click();                                 
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
  
            return this;
        }

        public ContactHelper ModifyContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Telhome);
            Type(By.Name("mobile"), contact.Telmobile);
            Type(By.Name("work"), contact.Telwork);
            Type(By.Name("fax"), contact.Telfax);
            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);

            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);

            driver.FindElement(By.Name("byear")).Click();
            Type(By.Name("byear"), contact.Byear);

            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);

            driver.FindElement(By.Name("ayear")).Click();
            Type(By.Name("ayear"), contact.Ayear);

            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);

            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper ContactDeletion()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper ContactSelection(int i)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+i+"]/td/input")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int i)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+i+"]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
