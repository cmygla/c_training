using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class RegistrationHelper :BaseHelper
    {

        private string baseURL;

        public RegistrationHelper(ApplicationManager manager, string baseURL) :base(manager)
        {
            this.baseURL = baseURL;
        }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitRegistration();
            //
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
        }

        private void SubmitPasswordForm()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        private void FillPasswordForm(string url, AccountData account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("realname")).SendKeys(account.Name);
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        private string GetConfirmationUrl(AccountData account)
        {
            string message = manager.Mail.GetLastMail(account);
            Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link.pull-left")).Click();
        }

        private void SubmitRegistration()
        {
            driver.FindElement(By.XPath("//input[@type='Submit']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }

        private void OpenMainPage()
        {
            manager.Driver.Url = baseURL;
        }
    }
}
