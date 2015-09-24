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
            ////TODO cache titles in LanguageManager!
            //this.resourceStringName = resourceStringName;
            //var title = new TranslatableString();
            
            //foreach (CultureInfo culture in stringsProvider.AvaliableLanguages)
            //{
            //    title.Add(culture, stringsProvider.GetString(resourceStringName, culture));
            //}
            //Title = title;
        }

        //public Section<T>() where T : ISectionItem
        //{
        //    Title = new TranslatableString();
        //    //foreach(CultureInfo ci )
        //    //{
        //    //    foreach()
        //    //}
        //}

        //public ITranslatable Title { get;  set; }
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

        //public IEnumerator<T> GetEnumerator()
        //{
        //    return Items.GetEnumerator();
        //}

        //System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}
    }
}
