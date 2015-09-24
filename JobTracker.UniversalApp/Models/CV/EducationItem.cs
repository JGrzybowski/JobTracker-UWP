using JobTracker.UniversalApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public enum EducationLevel {HighSchool, Bsc, Msc, Phd, Prof, Other, None};
    public class EducationItem : PeriodicalItem
    {
        public EducationItem(): base()
        {
            Level = EducationLevel.None;
            Translations = new TranslationCollection<EducationTranslation>();
        }
        public EducationItem(string languageTag) : base()
        {
            Translations = new TranslationCollection<EducationTranslation>() { new EducationTranslation(languageTag) };
            Level = EducationLevel.None;
        }

        [XmlAttribute("EducationLevel")]
        public EducationLevel Level { get; set; }

        [XmlArray("Translations")]
        public TranslationCollection<EducationTranslation> Translations { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            
            var theOther = obj as EducationItem;
            return (this.Translations.Equals(theOther.Translations)
                && this.Level.Equals(theOther.Level)
                && this.TimePeriod.Equals(theOther.TimePeriod));
        }
        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 1;
            hash = hash * 7 + this.Translations.GetHashCode();
            hash = hash * 11 + this.Level.GetHashCode();
            hash = hash * 17 + this.TimePeriod.GetHashCode();
            return hash;
        }
    }
}
