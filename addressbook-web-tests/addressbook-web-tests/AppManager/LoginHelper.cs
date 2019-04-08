﻿using System;
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
    public class LoginHelper : BaseHelper
    {
        public LoginHelper (ApplicationManager manager) : base(manager)
        { }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }


            for (int second = 0; ; second++)
            {
                if (second >= 60) break;
                try
                {
                    if (IsElementPresent(By.XPath("//input[@value='Login']"))) break;
                }
                catch (Exception)
                { }
                Thread.Sleep(1000);
            }

            Type(By.Name("user"),account.Username);
            Type(By.Name("pass"),account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text
                == "(" + account.Username + ")";
        }
    }
}
