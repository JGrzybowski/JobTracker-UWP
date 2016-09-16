using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models
{
    public class Address : BindableBase
    {
        [XmlAttribute("Line1")]
        public string Line1 { get { return _Line1; } set { Set(ref _Line1, value); } }
        private string _Line1;

        [XmlAttribute("Line2")]
        public string Line2 { get { return _Line2; } set { Set(ref _Line2, value); } }
        private string _Line2;

        [XmlAttribute("ZipCode")]
        public string ZipCode { get { return _ZipCode; } set { Set(ref _ZipCode, value); } }
        private string _ZipCode;
        
        [XmlAttribute("City")]
        public string City { get { return _City; } set { Set(ref _City, value); } }
        private string _City;

        [XmlAttribute("Country")]
        public string Country { get { return _Country; } set { Set(ref _Country, value); } }
        private string _Country;

        public override string ToString()
        {
            var sb = new StringBuilder();
            if (!String.IsNullOrEmpty(Line1))
                sb.AppendLine(Line1);
            if (!String.IsNullOrEmpty(Line2))
                sb.AppendLine(Line2);
            if (!String.IsNullOrEmpty(ZipCode))
                sb.AppendFormat("{0} ", ZipCode);
            if (!String.IsNullOrEmpty(City))
                sb.AppendLine(City);
            if (!String.IsNullOrEmpty(Country))
                sb.Append(Country);
            return sb.ToString();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var theOther = obj as Address;
            return (string.Equals(this.Line1,theOther.Line1)
                && string.Equals(this.Line2,theOther.Line2)
                && string.Equals(this.ZipCode,theOther.ZipCode)
                && string.Equals(this.City, theOther.City)
                && string.Equals(this.Country,theOther.Country));
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 1;
            hash = hash * 7 + this.Line1.GetHashCode();
            hash = hash * 11 + this.Line2.GetHashCode();
            hash = hash * 13 + this.Country.GetHashCode();
            hash = hash * 17 + this.City.GetHashCode();
            hash = hash * 19 + this.ZipCode.GetHashCode();
            return hash;
        }
    }
}
