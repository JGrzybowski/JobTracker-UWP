using System;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models.CV
{
    public class EducationTranslation : BindableBase, ITranslation
    {
        private EducationTranslation() : base() { }
        public EducationTranslation(string languageTag) : base()
        {
            if (!Windows.Globalization.Language.IsWellFormed(languageTag))
                throw new ArgumentException("Impropper languageTag");
            this.languageTag = languageTag;
        }

        [XmlAttribute("Lang")]
        public string LanguageTag { get { return languageTag; } set { }  }
        private readonly string languageTag;

        [XmlAttribute("SchoolName")]
        public string SchoolName { get { return schoolName; } set { Set(ref schoolName, value); } }
        private string schoolName;

        [XmlAttribute("Domain")]
        public string Domain { get { return domain; } set { Set(ref domain, value); } }
        private string domain;

        [XmlAttribute("Description")]
        public string Description { get { return description; } set { Set(ref description, value); } }
        private string description;

        public override int GetHashCode()
        {
            return LanguageTag.GetHashCode();
        }
    }
}
