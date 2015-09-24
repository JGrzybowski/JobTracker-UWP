using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models.CV
{
    public abstract class SectionItem : BindableBase, ISectionItem
    {
        public SectionItem() : base()
        {
            
        }

        [XmlAttribute("Name")]
        public string Name { get { return _Name; } set { Set(ref _Name, value); } }
        private string _Name;
    }
}
