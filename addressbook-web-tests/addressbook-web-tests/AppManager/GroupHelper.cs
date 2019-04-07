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
    public class GroupHelper : BaseHelper
    {
        private GroupData defaultGroup = new GroupData("TestGroup0");


        public GroupHelper(ApplicationManager manager) : base(manager)
        {
            defaultGroup.Header = "TestGroup0";
            defaultGroup.Footer = "TestGroup0";
        }

        private int GroupExists(int i)
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + i + "]")))
            {
                InitGroupCreation();
                FillGroupForm(defaultGroup);
                SubmitGroupCreation();
                ReturnToGroupsPage();
                i = 1;
            }
            return i;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int num, GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            num = GroupExists(num);
            GroupSelection(num);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int num)
        {
            manager.Navigator.GoToGroupsPage();
            num = GroupExists(num);
            GroupSelection(num);
            GroupDeletion();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper GroupDeletion()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public GroupHelper GroupSelection(int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + i +"]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
