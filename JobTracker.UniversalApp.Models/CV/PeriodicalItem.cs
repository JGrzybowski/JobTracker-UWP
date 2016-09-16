using System.Globalization;
using System.Xml.Serialization;

namespace JobTracker.Models.CV
{
    public abstract class PeriodicalItem : SectionItem
    {
        public const string TimePeriodPropertyName = "TimePeriod";
        
        [XmlElement("TimePeriod")]
        public Period TimePeriod { get { return _TimePeriod; } set { Set(ref _TimePeriod, value); } }
        private Period _TimePeriod;
        
        public PeriodicalItem()
        {
            TimePeriod = new Period();
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            PeriodicalItem theOther = obj as PeriodicalItem;
            return this.TimePeriod.Equals(theOther.TimePeriod);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            int hash = 1;
            hash = hash * 7 + TimePeriod.GetHashCode();
            return hash;
        }
    }
}
