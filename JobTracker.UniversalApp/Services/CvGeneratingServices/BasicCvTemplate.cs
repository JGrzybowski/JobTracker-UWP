using JobTracker.Models;
using JobTracker.UniversalApp.Converters;
using JobTracker.UniversalApp.Services.ResourcesServices;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace JobTracker.UniversalApp.Services.CvGeneratingServices
{
    public class BasicCvTemplate
    {
        private FontStyleBase BasicCVStyle;
        
        public async Task<bool> GenerateCV(StorageFile file, User user, string languageTag)
        {
            ReswStringsProvider stringsProvider = new ReswStringsProvider();
            WordDocument document = new WordDocument();
            IWSection section = document.AddSection();
            
            IWParagraph contactParagraph = section.AddParagraph();
            contactParagraph.AppendText(String.Format("{0} {1}", user.FirstName, user.LastName));
            contactParagraph.AppendBreak(BreakType.LineBreak);
            contactParagraph.AppendText(user.Address.ToString());
            contactParagraph.AppendBreak(BreakType.LineBreak);
            contactParagraph.AppendText(user.Phone.ToString());
            contactParagraph.AppendBreak(BreakType.LineBreak);
            contactParagraph.AppendText(user.Email.ToString());
            if (!String.IsNullOrWhiteSpace(user.Fax))
            {
                contactParagraph.AppendBreak(BreakType.LineBreak);
                contactParagraph.AppendText(user.Fax.ToString());
                contactParagraph.AppendBreak(BreakType.LineBreak);
            }

            PeriodFormater formater = new PeriodFormater();

            var eduParagraph = section.AddParagraph();
            eduParagraph.ApplyStyle(BuiltinStyle.Heading1);
            eduParagraph.AppendText(stringsProvider.GetLocalizedString(user.Education.ResourceStringName, languageTag));
            foreach (var item in user.Education.Items)
            {
                if (item.Translations.Contains(languageTag)) {
                    var txt = item.Translations[languageTag];
                    eduParagraph = section.AddParagraph();
                    eduParagraph.ApplyStyle(BuiltinStyle.ListBullet);
                    eduParagraph.AppendText(string.Format("{0} {1}", txt.SchoolName, formater.Convert(item.TimePeriod, typeof(string),null,languageTag)));
                    eduParagraph = section.AddParagraph();
                    eduParagraph.ApplyStyle(BuiltinStyle.ListContinue2);
                    eduParagraph.AppendText(string.Format("{0} {1}", txt.Domain, txt.Description));
                }
            }

            var jobParagraph = section.AddParagraph();
            jobParagraph.ApplyStyle(BuiltinStyle.Heading1);
            jobParagraph.AppendText(stringsProvider.GetLocalizedString(user.Jobs.ResourceStringName, languageTag));
            foreach (var item in user.Jobs.Items)
            {
                if (item.Translations.Contains(languageTag))
                {
                    var txt = item.Translations[languageTag];
                    jobParagraph = section.AddParagraph();
                    jobParagraph.ApplyStyle(BuiltinStyle.ListBullet);
                    jobParagraph.AppendText(string.Format("{0}, {1} {2}", txt.CompanyName, txt.Position, formater.Convert(item.TimePeriod, typeof(string), null, languageTag)));
                    jobParagraph = section.AddParagraph();
                    jobParagraph.ApplyStyle(BuiltinStyle.ListContinue2);
                    jobParagraph.AppendText(string.Format("{0}", txt.Responsibilities));
                }
            }

            var projectParagraph = section.AddParagraph();
            projectParagraph.ApplyStyle(BuiltinStyle.Heading1);
            projectParagraph.AppendText(stringsProvider.GetLocalizedString(user.Projects.ResourceStringName, languageTag));
            foreach (var item in user.Projects.Items)
            {
                if (item.Translations.Contains(languageTag))
                {
                    var txt = item.Translations[languageTag];
                    projectParagraph = section.AddParagraph();
                    projectParagraph.ApplyStyle(BuiltinStyle.ListBullet);
                    projectParagraph.AppendText(string.Format("{0} {1}", txt.Name, formater.Convert(item.TimePeriod, typeof(string), null, languageTag)));
                    projectParagraph = section.AddParagraph();
                    projectParagraph.ApplyStyle(BuiltinStyle.ListContinue2);
                    projectParagraph.AppendText(string.Format("{0}", txt.Description));
                }
            }

            return await document.SaveAsync(file, Syncfusion.DocIO.FormatType.Docx);
        }
    }
}
