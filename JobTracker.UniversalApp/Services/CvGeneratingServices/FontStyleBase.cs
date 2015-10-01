using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.UniversalApp.Services.CvGeneratingServices
{
    public class FontStyleBase
    {
        public IWParagraphStyle Names { get; set; }
        public IWParagraphStyle ContactDataLabels { get; set; }
        public IWParagraphStyle ContactDataContent { get; set; }
        public IWParagraphStyle SectionHeader { get; set; }
        public IWParagraphStyle ItemName { get; set; }
        public IWParagraphStyle ItemDescription { get; set; }
        public IWParagraphStyle Period{ get; set; }
        public IWParagraphStyle Footer { get; set; }

        public FontStyleBase(IWordDocument document)
        {
            Names = document.AddParagraphStyle("Names");
            Names.CharacterFormat.UnderlineStyle = UnderlineStyle.Dash;
            Names.CharacterFormat.FontSize = 22;

        }
    }
}
