using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;

        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;
        protected LoginHelper loginHelper;
        protected NavigationHelper navigationHelper;

        //устанавливает соответствие между текущим потом и объектом application manager
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        //constructor
        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);
        }

        //destructor
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }


        // singleton
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
                {
                    ApplicationManager newInstance = new ApplicationManager();
                    newInstance.Navigator.OpenHomePage();
                    app.Value = newInstance;


            }
            return app.Value;
        }

        public IWebDriver Driver {
            get
            {
                return driver;
            }
        }


        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }

        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }

        public GroupHelper Groups
        {
            get {
                return groupHelper;
                }
        }
    }
}
