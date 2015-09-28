using JobTracker.Models.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models.CV
{
    public abstract class TranslationBase : BindableBase, ITranslation
    {
        protected TranslationBase() : base() { }
        public TranslationBase(string languageTag)
        {
            if (Windows.Globalization.Language.IsWellFormed(languageTag))
                this.languageTag = languageTag;

        }

        [XmlAttribute("Lang")]
        public string LanguageTag { get { return languageTag; } set { } }
        protected readonly string languageTag;
    }
}
