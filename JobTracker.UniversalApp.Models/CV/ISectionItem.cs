using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public interface ISectionItem
    {
        [XmlAttribute("Name")]
        string Name { get; set; }

    }

    public interface ISectionItem<TTranslation> : ISectionItem, IWithTranslation<TTranslation> where TTranslation : ITranslation { }
}
