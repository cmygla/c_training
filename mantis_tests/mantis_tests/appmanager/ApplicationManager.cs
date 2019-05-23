using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        public string baseURL;

        public RegistrationHelper Registration { get; private set; }
        public FTPHelper Ftp { get; private set; }
        public JamesHelper JamesHelper { get; private set; }
        public MailHelper Mail { get; private set; }
        public ProjectManagementHelper Projects { get; set; }
        public ManagementMenuHelper Menu { get; set; }
        public LoginHelper Auth { get; set; }
        public AdminHelper Admin { get; set; }

        //устанавливает соответствие между текущим потом и объектом application manager
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        //constructor
        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.21.0";
            Registration = new RegistrationHelper(this, baseURL);
            Ftp = new FTPHelper(this);
            JamesHelper = new JamesHelper(this);
            Mail = new MailHelper(this);
            Projects = new ProjectManagementHelper(this);
            Menu = new ManagementMenuHelper(this, baseURL);
            Auth = new LoginHelper(this);
            Admin = new AdminHelper(this, baseURL);

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
                    newInstance.Driver.Url = newInstance.baseURL+"/login_page.php";
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
    }
}
