using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace mantis_tests
{

    [TestFixture]
    public class UnitTest1:TestBase
    {

        [Test]
        public void TestMethod1()
        {
            AccountData account = new AccountData()
            {
                Name = "xxx",
                Password = "yyy"
            };
            Assert.IsFalse(app.JamesHelper.Verify(account));
            app.JamesHelper.Add(account);
            Assert.IsTrue(app.JamesHelper.Verify(account));
            app.JamesHelper.Delete(account);
            Assert.IsFalse(app.JamesHelper.Verify(account));
        }
    }
}
