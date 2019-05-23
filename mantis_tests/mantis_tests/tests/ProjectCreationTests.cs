using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;



namespace mantis_tests

{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {


        [Test]
        public void ProjectCreationTest()
        {


            List<ProjectData> oldProjectsList = app.Projects.GetProjects();

            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(20)
            };

            app.Projects.Create(project);

            Assert.AreEqual(oldProjectsList.Count + 1, app.Projects.GetProjects().Count);

            List<ProjectData> newProjectsList = app.Projects.GetProjects();
            oldProjectsList.Add(project);
            newProjectsList.Sort();
            oldProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}