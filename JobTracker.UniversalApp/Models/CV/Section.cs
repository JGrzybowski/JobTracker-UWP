using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models.CV
{
    public class Section<T> : BindableBase, ISection<T> where T : ISectionItem, new()
    {
        protected string resourceStringName;
        public Section(string resourceStringName)
        {
            Items = new SectionItemsCollection<T>();
        }

        [XmlArray("Items")]
        public SectionItemsCollection<T> Items { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var theOther = obj as Section<T>;
            //TODO FIX SECTIONS COMPARISON
            return (this.Items.All(item => theOther.Items.Any(i => i.Equals(item))) );
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return 13 * Items.GetHashCode();
        }
    }
}
