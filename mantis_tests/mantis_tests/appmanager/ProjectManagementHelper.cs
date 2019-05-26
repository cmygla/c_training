using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;


namespace mantis_tests
{
    public class ProjectManagementHelper : BaseHelper

    {
        private AccountData AdminAuth;
        
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) {

            AdminAuth = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            };
        }
        

        public ProjectManagementHelper Create(ProjectData project)
        {
            manager.Menu.OpenProjectManagementPage();
            InitProjectCreation();
            FillProjectForm(project);
            SubmitProjectCreation();
            manager.Menu.OpenProjectManagementPage();
            return this;
        }

        private void SubmitProjectCreation()
        {

            driver.FindElement(By.XPath("//input[@type='submit']")).Click();

        }

        private void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
        }

        private void InitProjectCreation()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }

        public ProjectManagementHelper Remove(int num)
        {
            manager.Menu.OpenProjectManagementPage();
            SelectProject(num);
            SubmitRemovalProject();
            SubmitRemovalProject();
            manager.Menu.OpenProjectManagementPage();
            return this;
        }


        public List<ProjectData> GetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();

            manager.Menu.OpenProjectManagementPage();

            IList<IWebElement> rows = driver.FindElement(By.ClassName("table-responsive")).FindElements(By.TagName("tr"));
            foreach (IWebElement row in rows)
            {
                if (row != rows[0])
                {
                    IWebElement link = row.FindElement(By.TagName("a"));
                    string name = link.Text;
                    string href = link.GetAttribute("href");
                    Match m = Regex.Match(href, @"\d+$");
                    string id = m.Value;

                    projects.Add(new ProjectData()
                    {
                        Name = name,
                        Id = id
                    });
                }
            }
            return projects;
        }


        public ProjectManagementHelper APIAdd(ProjectData project)
        {

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData APIProject = new Mantis.ProjectData
            {
                name = project.Name,
            };

            client.mc_project_add(AdminAuth.Name, AdminAuth.Password, APIProject);
            return this;
        }

        public List<ProjectData> APIGetProjects()
        {
            List<ProjectData> projects = new List<ProjectData>();

            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[]  APIProjects = client.mc_projects_get_user_accessible(AdminAuth.Name, AdminAuth.Password);

            foreach (Mantis.ProjectData APIProject in APIProjects)
            {
                    projects.Add(new ProjectData()
                    {
                        Name = APIProject.name,
                        Id = APIProject.id
                    });
            }
            return projects;
        }


        private void SubmitRemovalProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        private void SelectProject(int num)
        {
            driver.FindElements(By.TagName("td"))[num].FindElement(By.TagName("a")).Click();
        }
    }
}