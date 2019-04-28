using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_web_tests;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace Addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = args[0];
            
            // количество тестовых данных, которое хотим сгенерировать
            int count = Convert.ToInt32(args[1]);
            // запись в файл

            string filename = args[2];
            string format = args[3];

            if (dataType == "groups")
            {
                List<GroupData> groups = new List<GroupData>();

                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(10),
                        Footer = TestBase.GenerateRandomString(10)
                    });

                }
                if (format == "excel")
                {
                    writeGroupsToExcelFile(groups, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeGroupsToCSVFile(groups, writer);
                    }
                    else if (format == "xml")
                    {
                        writeGroupsToXMLFile(groups, writer);
                    }
                    else if (format == "json")
                    {
                        writeGroupsToJSONFile(groups, writer);
                    }
                    else
                    {
                        System.Console.Write("Unrecognized format " + format);
                    }

                    //закрываем файл, чтобы данные попали на диск
                    writer.Close();
                }
            }
            else if (dataType == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();

                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                    });

                }
                if (format == "excel")
                {
                    writeContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(filename);
                    if (format == "csv")
                    {
                        writeContactsToCSVFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        writeContactsToXMLFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        writeContactsToJSONFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Write("Unrecognized format " + format);
                    }

                    //закрываем файл, чтобы данные попали на диск
                    writer.Close();
                }
            }
            else               
            {
                System.Console.Write("Unrecognized data type " + dataType);
            }      
            
        }

        static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

            File.Delete(fullPath);
            //если не указать полный путь, то это будет путь, который эксель считает для себя дефолтным
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCSVFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach ( GroupData group in groups)
            {
                //строка автоматически завершится переводом строки
                writer.WriteLine(String.Format("${0},${1},${2}",
                   group.Name,group.Header, group.Footer
                   ));
            }
        }

        static void writeGroupsToXMLFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer,groups);
        }

                static void writeGroupsToJSONFile(List<GroupData> groups, StreamWriter writer)
        {
            // в самом файле  []- массив, {}-объект
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }



        static void writeContactsToExcelFile(List<ContactData> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = wb.ActiveSheet;

            int row = 1;
            foreach (ContactData contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Lastname;
                sheet.Cells[row, 3] = contact.Address;
                row++;
            }
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);

            File.Delete(fullPath);
            //если не указать полный путь, то это будет путь, который эксель считает для себя дефолтным
            wb.SaveAs(fullPath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeContactsToCSVFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                //строка автоматически завершится переводом строки
                writer.WriteLine(String.Format("${0},${1},${2}",
                   contact.Firstname, contact.Lastname, contact.Address
                   ));
            }
        }

        static void writeContactsToXMLFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }


        static void writeContactsToJSONFile(List<ContactData> contacts, StreamWriter writer)
        {
            // в самом файле  []- массив, {}-объект
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }


    }
}
