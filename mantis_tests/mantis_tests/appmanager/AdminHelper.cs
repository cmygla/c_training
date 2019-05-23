using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
//using SimpleBrowser.WebDriver;

namespace mantis_tests
{
    public class AdminHelper : BaseHelper

    {

        private string baseURL;

        public AdminHelper(ApplicationManager manager, String baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public List<AccountData> GetAllAccounts()
        {

            return null;
        }
        /*
       public void DeleteAccount(AccountData account)
       {
           IWebDriver driver = OpenAppAndLogin(); 
       }
       private IWebDriver OpenAppAndLogin()
       {
           IWebDriver driver = new SimpleBrowserDriver();
           driver.Url = baseURL + "/login_page.php";
       }
       */
    }
}