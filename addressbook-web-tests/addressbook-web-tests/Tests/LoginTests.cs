using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTests :TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("admin", "secret");
            //preparation
            app.Auth.Logout();

            //action
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            AccountData account = new AccountData("admin", "123456");
            //preparation
            app.Auth.Logout();

            //action
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn());
        }
    }
}
