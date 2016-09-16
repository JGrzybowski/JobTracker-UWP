using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public class JobTranslation : TranslationBase
    {
        public JobTranslation() : base() { }
        public JobTranslation(string languageTag) : base(languageTag) { }

        [XmlAttribute("CompanyName")]
        public string CompanyName { get { return companyName; } set { Set(ref companyName, value); } }
        private string companyName;

        [XmlAttribute("Position")]
        public string Position { get { return position; } set { Set(ref position, value); } }
        private string position;

        [XmlAttribute("Responsibilities")]
        public string Responsibilities { get { return responsibilities; } set { Set(ref responsibilities, value); } }
        private string responsibilities;
    }
}
