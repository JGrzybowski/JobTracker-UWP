using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public interface ISection 
    {
        //ITranslatable Title { get; set; }
    }
    
    public interface ISection<T> : ISection
         where T : ISectionItem
    {
        [XmlArray("Items")]
        SectionItemsCollection<T> Items { get; set; }
    }
}
