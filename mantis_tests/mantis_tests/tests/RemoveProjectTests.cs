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
            List<ProjectData> oldProjectsList = app.Projects.GetProjects();
            app.Projects.Remove(0);

            List<ProjectData> newProjectsList = app.Projects.GetProjects();
            Assert.AreEqual(oldProjectsList.Count - 1, newProjectsList.Count);
            oldProjectsList.RemoveAt(0);
            newProjectsList.Sort();
            oldProjectsList.Sort();
            Assert.AreEqual(oldProjectsList, newProjectsList);
        }
    }

}