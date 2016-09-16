using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public class PeriodicalTranslatedItem<TTranslation> : PeriodicalItem, ISectionItem<TTranslation> where TTranslation : ITranslation
    {
        [XmlArray("Translations")]
        public TranslationCollection<TTranslation> Translations { get { return translations; } set { Set(ref translations, value); } }
        private TranslationCollection<TTranslation> translations = new TranslationCollection<TTranslation>();
        ITranslationCollection<TTranslation> IWithTranslation<TTranslation>.Translations { get { return Translations; } }
        public bool HasTranslation(string languageTag) { return Translations.Contains(languageTag); }

    }
}
