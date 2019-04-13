﻿using System;
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

        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public bool GroupExists(int i)
        {
            if (IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + (i+1) + "]")))
            {
                return true;
            }
            return false;
        }

        // реализация кеширования в виде свойства
        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text)
                    {   // получить атрибут ID
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            //возвратить новый список , построенный из старого для избежания модификации списка извне

            return new List<GroupData>(groupCache);
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
            GroupSelection(num);
            InitGroupModification();
            FillGroupForm(group);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        internal int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        public GroupHelper Remove(int num)
        {
            manager.Navigator.GoToGroupsPage();
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
            groupCache = null;
            return this;
        }

        public GroupHelper GroupDeletion()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public GroupHelper GroupSelection(int i)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (i+1) +"]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

    }
}
