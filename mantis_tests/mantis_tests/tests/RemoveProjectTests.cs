using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class RemoveProjectTests : AuthTestBase
    {

        [Test]
        public void ProjectRemovalTest()
        {
            List<ProjectData> oldProjectsList = app.Projects.APIGetProjects();

            if (oldProjectsList.Count == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = GenerateRandomString(20)
                };
                app.Projects.APIAdd(project);

                oldProjectsList = app.Projects.APIGetProjects();
            }
            
            app.Projects.Remove(0);

            List<ProjectData> newProjectsList = app.Projects.APIGetProjects();

            Assert.AreEqual(oldProjectsList.Count - 1, newProjectsList.Count);
            oldProjectsList.RemoveAt(0);
            newProjectsList.Sort();
            oldProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }

}