using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setupConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            // после прочтения stream автоматически закроется
            using (Stream localFile = File.Open("/config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }           
        }

        [Test]
        public void TestAccountRegistration()
        {
                 AccountData account = new AccountData() {
                Name = "testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };

            List<AccountData> accounts = app.Admin.GetAllAccounts();
            AccountData existingAccount = accounts.Find(x => x.Name == account.Name);
            if (existingAccount != null)
            {
                app.Admin.DeleteAccount(existingAccount);
            }
            //Work with Telnet
            //app.JamesHelper.Delete(account);
            //app.JamesHelper.Add(account);

            app.Registration.Register(account);
        }

        [OneTimeTearDown]
        public void  restoreConfig()
            {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
