using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Globalization;

namespace JobTracker.Models.CV
{
    public interface ITranslation
    {
        [XmlAttribute("Lang")]
        string LanguageTag{ get; }
    }
}