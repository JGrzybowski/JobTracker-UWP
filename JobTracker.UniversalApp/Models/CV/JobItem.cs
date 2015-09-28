using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public class JobItem : PeriodicalItem
    {
        public JobItem() : base() { }

        [XmlArray("Translations")]
        public TranslationCollection<JobTranslation> Translations { get; set; }
    }
}
