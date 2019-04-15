using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {

        private string bday = "1";
        private string bmonth = "January";
        private string byear = "1900";
        private string aday = "1";
        private string amonth = "January";
        private string ayear = "1900";
        private string newgroup = "[none]";

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

    }
}
