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
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

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