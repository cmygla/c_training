using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class LoginHelper : BaseHelper
    {

        public LoginHelper(ApplicationManager manager)
            : base(manager)
        {

        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                Logout();
            }

            Type(By.Name("username"), account.Name);

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

            Type(By.Name("password"), account.Password);

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();


        }

        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.CssSelector("span.user-info")).Click();
                //driver.FindElement(By.LinkText("Выход")).Click();

                driver.FindElement(By.CssSelector("ace - icon fa fa-sign-out")).Click();
            }
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.CssSelector("i.fa.fa-user.home-icon.active"));
        }

    }
}