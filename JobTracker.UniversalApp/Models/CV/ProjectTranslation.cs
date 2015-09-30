using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public class ProjectTranslation : TranslationBase
    {
        public ProjectTranslation() : base() { }
        public ProjectTranslation(string languageTag) : base(languageTag) { }

        [XmlAttribute("Name")]
        public string Name { get { return name; } set { Set(ref name, value); } }
        private string name;

        [XmlAttribute("Description")]
        public string Description { get { return description; } set { Set(ref description, value); } }
        private string description;

    }
}
