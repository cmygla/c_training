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

            List<ProjectData> oldProjectsList = app.Projects.APIGetProjects();

            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(20)
            };

            app.Projects.Create(project);
            List<ProjectData> newProjectsList = app.Projects.APIGetProjects();

            Assert.AreEqual(oldProjectsList.Count + 1, newProjectsList.Count);
            oldProjectsList.Add(project);
            newProjectsList.Sort();
            oldProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }
}