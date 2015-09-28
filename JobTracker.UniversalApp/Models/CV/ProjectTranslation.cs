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
        protected ProjectTranslation() :base() { }
        public ProjectTranslation(string languageTag) : base(languageTag) { }

        [XmlAttribute("Title")]
        public string Title { get { return title; } set { Set(ref title, value); } }
        private string title;

        [XmlAttribute("Description")]
        public string Description { get { return description; } set { Set(ref description, value); } }
        private string description;

    }
}
