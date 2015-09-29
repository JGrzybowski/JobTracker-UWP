using JobTracker.Models.CV;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models
{
    public class User : BindableBase
    {
        [XmlAttribute("FirstName")]
        public string FirstName { get; set; }
        [XmlAttribute("LastName")]
        public string LastName { get; set; }
        [XmlAttribute("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [XmlElement("Address")]
        public Address Address { get; set; }
        [XmlAttribute("Email")]
        public string Email { get; set; }
        [XmlAttribute("Phone")]
        public string Phone { get; set; }
        [XmlAttribute("Fax")]
        public string Fax { get; set; }


        public EducationSection Education { get; set; }
        public JobSection Jobs { get; set; }
        public ProjectSection Projects { get; set; }

        public User()
        {
            Education = new EducationSection();
            Jobs = new JobSection();
            Projects = new ProjectSection();
        }


        //[XmlIgnore]
        //public List<Section<>> Sections { get { return new List<Section<>>{ Education,Jobs, Projects }; } }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var theOther = obj as User;
            return (string.Equals(this.LastName, theOther.LastName)
                && string.Equals(this.FirstName, theOther.FirstName)
                && string.Equals(this.DateOfBirth, theOther.DateOfBirth)
                && string.Equals(this.Email, theOther.Email)
                && string.Equals(this.Fax, theOther.Fax)
                && string.Equals(this.Phone, theOther.Phone)
                && Address.Equals(this.Address, theOther.Address)
                //&& this.Sections.OrderBy(section => section).SequenceEqual(theOther.Sections.OrderBy(section => section))
                );
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 1;
           // hash = hash * 7 + this.Sections.GetHashCode();
            hash = hash * 11 + this.Address.GetHashCode();
            hash = hash * 13 + this.Phone.GetHashCode();
            hash = hash * 17 + this.Fax.GetHashCode();
            hash = hash * 19 + this.Email.GetHashCode();
            hash = hash * 23 + this.FirstName.GetHashCode();
            hash = hash * 29 + this.LastName.GetHashCode();
            hash = hash * 31 + this.DateOfBirth.GetHashCode();
            return hash;
        }
    }
}
