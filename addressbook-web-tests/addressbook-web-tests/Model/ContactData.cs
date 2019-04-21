using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        //fields
        private string bday = "1";
        private string bmonth = "January";
        private string byear = "1900";
        private string aday = "1";
        private string amonth = "January";
        private string ayear = "1900";
        private string newgroup = "[none]";
        private string allPhones;
        private string allEmails;
        private string collapsedInfo;

        public ContactData (string firstname, string lastname, string companyaddress)
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = companyaddress;
        }

        //функция реализующая сравнение
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (Firstname == other.Firstname)&&(Lastname == other.Lastname);
        }

        //сравнение имен
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            else
            {
                return Lastname.CompareTo(other.Lastname);
            }

        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "Id=" + Id;
        }

        public string Firstname { get; set; }

        public string Middlename { get; set; }

        public string Lastname { get; set; }

        public string Nickname { get; set; }

        public string Photo { get; set; }

        public string Title { get; set; }

        public string Company { get; set; }

        public string Address { get; set; }

        public string Telhome { get; set; }

        public string Telmobile { get; set; }

        public string Telwork { get; set; }

        public string Telfax { get; set; }

        public string Email1 { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }

        public string Homepage { get; set; }

        public string Address2 { get; set; }

        public string Phone2 { get; set; }

        public string Notes { get; set; }

        public string Id { get; set; }

        public string Aday { get => aday; set => aday = value; }

        public string Amonth { get => amonth; set => amonth = value; }

        public string Ayear { get => ayear; set => ayear = value; }

        public string Bday { get => bday; set => bday = value; }

        public string Bmonth { get => bmonth; set => bmonth = value; }

        public string Byear { get => byear; set => byear = value; }

        public string Newgroup { get => newgroup; set => newgroup = value; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUpPhone(Telhome) + CleanUpPhone(Telmobile) + CleanUpPhone(Telwork)+ CleanUpPhone(Phone2)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUpPhone(string phone)
        {
            if ( phone == null || phone == "")
            {
                return "";
            }
            else
            {
                return Regex.Replace(phone,"[ -()]","") + "\r\n";
            }
        }

        private string CleanUpText(string text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                return text + "\r\n";
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUpText(Email1) + CleanUpText(Email2) + CleanUpText(Email3)).Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }



        public string CollapsedInfo
        {
            get
            {
                if (collapsedInfo != null)
                {
                    return collapsedInfo;
                }
                else
                {
                    string text = "";
                    if (Firstname != null && Firstname != "")
                    {
                        text = text + Firstname;
                    };
                    if (Middlename != null && Middlename != "")
                    {
                        text = text + " " + Middlename;
                    };
                    if (Lastname != null && Lastname != "")
                    {
                        text = text + " " + Lastname;
                    };
                    text = text + "\r\n";

                    if (Nickname != null && Nickname != "")
                    {
                        text = text + Nickname + "\r\n";
                    };
                    if (Title != null && Title != "")
                    {
                        text = text + Title + "\r\n";
                    };
                    if (Company != null && Company != "")
                    {
                        text = text + Company + "\r\n";
                    };
                    if (Address != null && Address != "")
                    {
                        text = text + Address + "\r\n";
                    };


                    if (Telhome != null && Telhome != "")
                    {
                        text = text + "H: " + Telhome + "\r\n";
                    };
                    if (Telmobile != null && Telmobile != "")
                    {
                        text = text + "M: " + Telmobile + "\r\n";
                    };
                    if (Telwork != null && Telwork != "")
                    {
                        text = text + "W: " + Telwork + "\r\n";
                    };
                    if (Telfax != null && Telfax != "")
                    {
                        text = text + "F: " + Telfax + "\r\n";
                    };

                    if (Email1 != null && Email1 != "")
                    {
                        text = text + Email1 + "\r\n";
                    };
                    if (Email2 != null && Email2 != "")
                    {
                        text = text + Email2 + "\r\n";
                    };
                    if (Email3 != null && Email3 != "")
                    {
                        text = text + Email3 + "\r\n";
                    };

                    if (Homepage != null && Homepage != "")
                    {
                        text = text + "Homepage:" + "\r\n" + Homepage + "\r\n";
                    };
                    if (Bday != null && Bmonth != null && Byear != null && Bday != "" && Bmonth != "" && Byear != "")
                    {
                        text = text + "Birthday " + Bday + ". " + Bmonth + " " + Byear + " (" + (System.DateTime.Today.Year - Convert.ToInt32(Byear)) + ")\r\n";
                    };
                    if (Aday != null && Amonth != null && Ayear != null && Aday != "" && Amonth != "" && Ayear != "")
                    {
                        text = text + "Anniversary " + Aday + ". " + Amonth + " " + Ayear + " (" + (System.DateTime.Today.Year - Convert.ToInt32(Ayear)) + ")\r\n";
                    };

                    if (Address2 != null && Address2 != "")
                    {
                        text = text + Address2 + "\r\n";
                    };
                    if (Phone2 != null && Phone2 != "")
                    {
                        text = text + "P: " + Phone2 + "\r\n";
                    };
                    if (Notes != null && Notes != "")
                    {
                        text = text + Notes;
                    };

                    return text;

                }
            }
            set
            {
                collapsedInfo = value;
            }
        }

    }
}
