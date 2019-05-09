using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests: ContactTestBase
    {

        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30), GenerateRandomString(30))
                {
                    Middlename = GenerateRandomString(30),
                    Nickname = GenerateRandomString(30),
                    Photo = "",
                    Title = GenerateRandomString(30),
                    Company = GenerateRandomString(30),
                    Address = GenerateRandomString(30),
                    Telhome = GenerateRandomString(30),
                    Telmobile = GenerateRandomString(30),
                    Telwork = GenerateRandomString(30),
                    Telfax = GenerateRandomString(30),
                    Email1 = GenerateRandomString(30),
                    Email2 = GenerateRandomString(30),
                    Email3 = GenerateRandomString(30),
                    Homepage = GenerateRandomString(30),
                    Bday = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 28)),
                    Bmonth = "January",
                    Byear = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 9999)),
                    Aday = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 28)),
                    Amonth = "January",
                    Ayear = Convert.ToString(Convert.ToInt32(rnd.NextDouble() * 9999)),
                    Newgroup = "[none]",
                    Address2 = GenerateRandomString(30),
                    Phone2 = GenerateRandomString(30),
                    Notes = GenerateRandomString(30)

                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromCSVFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");

            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData()
                {
                    Firstname = parts[0],
                    Lastname = parts[1],
                    Address = parts[2]
                });
            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXMLFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            // приведение типа
            return (List<ContactData>)
            new XmlSerializer(typeof(List<ContactData>))
                .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJSONFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json")
                );

        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            app.Visible = true;
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                contacts.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 2].Value,
                    Address = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromExcelFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Create(contact);
            contact.Id = ContactData.GetAll().Last().Id;

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
