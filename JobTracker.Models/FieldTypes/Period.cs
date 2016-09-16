using Prism.Mvvm;
using System;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace JobTracker.Models.FieldTypes
{
    [Flags]
    public enum TimeUnit
    {
        Day = 1,
        Month = 2,
        Year = 4,
        DayMonth = Day | Month,
        MonthYear = Month | Year,
        DayMonthYear = Day | Month | Year
    }
    public enum DatesVisibility { Single, Both }

    public class Period : BindableBase//, IXmlSerializable
    {
        [XmlAttribute("From")]
        public DateTime From
        {
            get { return _From; }
            set
            {
                if (value <= To)
                    SetProperty(ref _From, value);
                else
                    throw new ArgumentException("\"From\" date must be before \"To\" date.");
            }
        }
        private DateTime _From;

        [XmlAttribute("To")]
        public DateTime To
        {
            get { return _To; }
            set
            {
                if (value >= From)
                    SetProperty(ref _To, value);
                else
                    throw new ArgumentException("\"To\" date must be after \"From\" date.");
            }
        }
        private DateTime _To;

        [XmlAttribute("TillNow")]
        public bool TillNow { get { return _TillNow; } set { SetProperty(ref _TillNow, value); } }
        private bool _TillNow = false;

        [XmlAttribute("DatesVisibility")]
        public DatesVisibility DatesVisibility { get { return _DatesVisibility; } set { SetProperty(ref _DatesVisibility, value); } }
        private DatesVisibility _DatesVisibility = DatesVisibility.Both;

        [XmlAttribute("DatesPartsVisibility")]
        public TimeUnit DatesPartsVisibility { get { return _DatesPartsVisibility; } set { SetProperty(ref _DatesPartsVisibility, value); } }
        private TimeUnit _DatesPartsVisibility = TimeUnit.MonthYear;
        
        public const string NowFieldName = "Now";

        public Period()
        {
            this.To = DateTime.Today;
            this.From = DateTime.Today;
        }
        public Period(DateTime from, DateTime to)
        {
            this._To = to;
            this._From = from;
        }


        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Period theOther = obj as Period;
            return this.From.Equals(theOther.From) 
                && this.TillNow.Equals(theOther.TillNow) 
                && this.To.Equals(theOther.To);    
        }

        public override int GetHashCode()
        {
            var hash = From.GetHashCode();
            hash = hash * 11 + To.GetHashCode();
            return hash;
        }

        // override object.ToString()
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(From.ToString());
            sb.Append(" - ");
            sb.Append(To.ToString());
            if (TillNow)
                sb.Append("[Till now]");
            return sb.ToString();
        }

        //// Xml Serialization Infrastructure 
        //public void WriteXml(XmlWriter writer)
        //{
        //    if (From!= DateTime.MinValue)
        //        writer.WriteAttributeString("From", From.ToString("yyyy-MM-dd"));
        //    if(TillNow)
        //        writer.WriteAttributeString("TillNow", this.TillNow.ToString());
        //    else if (To != DateTime.MinValue)
        //        writer.WriteAttributeString("To", To.ToString("yyyy-MM-dd"));
        //}
        //public void ReadXml(XmlReader reader)
        //{
        //    reader.MoveToContent();
        //    bool tillNow = false;
        //    Boolean.TryParse(reader.GetAttribute("TillNow"), out tillNow);
        //    this.TillNow = tillNow;
        //    this.DatesVisibility = (DatesVisibility)Enum.Parse(typeof(DatesVisibility), reader.GetAttribute(nameof(DatesVisibility)));
        //    this.DatesPartsVisibility = (TimeUnit)Enum.Parse(typeof(TimeUnit), reader.GetAttribute(nameof(DatesPartsVisibility)));
        //    this.From= DateTime.ParseExact(reader.GetAttribute("From"), "yyyy-MM-dd", null);
        //    if (!TillNow)
        //        this.To = DateTime.ParseExact(reader.GetAttribute("To"), "yyyy-MM-dd", null);
        //}
        //public XmlSchema GetSchema() { return (null); }

    }
}
