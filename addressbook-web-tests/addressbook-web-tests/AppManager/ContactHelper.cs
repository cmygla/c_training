using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace addressbook_web_tests
{
    public class ContactHelper:BaseHelper
    {

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        // реализация кеширования в виде свойства
        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();

                manager.Navigator.ReturnToContactsPage();

                ICollection <IWebElement> rows = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in rows)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));

                    contactCache.Add(new ContactData(cells[2].Text, cells[1].Text, "")
                    {   // получить атрибут ID
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            //возвратить новый список , построенный из старого для избежания модификации списка извне

            return new List<ContactData>(contactCache);
        }

        internal int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
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

        public bool ContactExists(int i)
        {
            if (IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + (i+2) + "]")))
            {
                return true;
            }
            return false;
        }

        public ContactHelper Remove(int i)
        {
            manager.Navigator.ReturnToContactsPage();
            ContactSelection(i);
            ContactDeletion();
            manager.Navigator.ReturnToContactsPage();
            return this;
        }

        public ContactHelper Modify(int i, ContactData contact)
        {
            manager.Navigator.ReturnToContactsPage();
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
            contactCache = null;
            return this;
        }

        public ContactHelper ContactDeletion()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();

            for (int second = 0; ; second++)
            {
                if (second >= 60) break;
                try
                {
                    if (IsElementPresent(By.XPath("//input[@value='Delete']"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            contactCache = null;
            return this;
        }

        public ContactHelper ContactSelection(int i)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+(i+2)+"]/td/input")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int i)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+(i+2)+"]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }
    }
}
