using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    public class ContactData
    {
        private string firstname;
        private string middlename ="";
        private string lastname;
        private string nickname="";
        private string photo = "";
        private string title = "";

        private string company="";
        private string address;
        private string telhome = "";
        private string telmobile="";
        private string telwork="";
        private string telfax="";

        private string email1="";
        private string email2="";
        private string email3="";
        private string homepage="";

        private string bday="1";
        private string bmonth="January";
        private string byear="1900";

        private string aday="1";
        private string amonth="January";
        private string ayear="1900";

        private string newgroup="[none]";

        private string address2="";
        private string phone2="";
        private string notes="";

        public ContactData (string firstname, string lastname, string companyaddress)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = companyaddress;
        }

        public string Firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                this.firstname = value;
            }
        }
        public string Middlename
        {
            get
            {
                return middlename;
            }

            set
            {
                this.middlename = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                this.lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }

            set
            {
                this.nickname = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }

            set
            {
                this.photo = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                this.title = value;
            }
        }
        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                this.company = value;
            }
        }
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                this.address = value;
            }
        }
        public string Telhome
        {
            get
            {
                return telhome;
            }

            set
            {
                this.telhome = value;
            }
        }
        public string Telmobile
        {
            get
            {
                return telmobile;
            }

            set
            {
                this.telmobile = value;
            }
        }
        public string Telwork
        {
            get
            {
                return telwork;
            }

            set
            {
                this.telwork = value;
            }
        }
        public string Telfax
        {
            get
            {
                return telfax;
            }

            set
            {
                this.telfax = value;
            }
        }
        public string Email1
        {
            get
            {
                return email1;
            }

            set
            {
                this.email1 = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                this.email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                this.email3 = value;
            }
        }

        public string Homepage
        {
            get
            {
                return homepage;
            }

            set
            {
                this.homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }

            set
            {
                this.bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }

            set
            {
                this.bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }

            set
            {
                this.byear = value;
            }
        }
        public string Aday
        {
            get
            {
                return aday;
            }

            set
            {
                this.aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }

            set
            {
                this.amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }

            set
            {
                this.ayear = value;
            }
        }
        public string Newgroup
        {
            get
            {
                return newgroup;
            }

            set
            {
                this.newgroup = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                this.address2 = value;
            }
        }
        public string Phone2
        {
            get
            {
                return phone2;
            }

            set
            {
                this.phone2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                this.notes = value;
            }
        }

    }
}
