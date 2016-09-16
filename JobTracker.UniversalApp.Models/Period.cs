using System;
using System.Globalization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Template10.Mvvm;

namespace JobTracker.Models
{

    [Flags]
    public enum TimeUnit
    {
        Days = 1,
        Months = 2,
        Years = 4,
        DayAndMonth = Days | Months,
        MonthAndYear = Months | Years,
        Full = Days | Months | Years
    }
    public enum DatesVisibility { Single, Both }

    public class Period : BindableBase//, IXmlSerializable
    {
        [XmlAttribute("From")]
        public DateTime From { get { return _From; } set { Set(ref _From, value); } }
        private DateTime _From = DateTime.Today;

        [XmlAttribute("To")]
        public DateTime To { get { return _To; } set { Set(ref _To, value); } }
        private DateTime _To = DateTime.Today;

        [XmlAttribute("TillNow")]
        public bool TillNow { get { return _TillNow; } set { Set(ref _TillNow, value); } }
        private bool _TillNow = false;

        [XmlAttribute("DatesVisibility")]
        public DatesVisibility DatesVisibility { get { return _DatesVisibility; } set { Set(ref _DatesVisibility, value); } }
        private DatesVisibility _DatesVisibility = DatesVisibility.Both;

        [XmlAttribute("DatesPartsVisibility")]
        public TimeUnit DatesPartsVisibility { get { return _DatesPartsVisibility; } set { Set(ref _DatesPartsVisibility, value); } }
        private TimeUnit _DatesPartsVisibility = TimeUnit.MonthAndYear;
        
        public const string NowFieldName = "Now";

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Period theOther = obj as Period;
            return this.From.Equals(theOther.From) && this.TillNow.Equals(theOther.TillNow) && this.To.Equals(theOther.To);    
        }

        // override object.ToString()
        public override string ToString()
        {
            return From.ToString() + " - " + To.ToString();
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
