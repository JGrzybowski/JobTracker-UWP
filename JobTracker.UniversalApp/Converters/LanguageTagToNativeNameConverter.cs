using JobTracker.UniversalApp.Services.ResourcesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace JobTracker.UniversalApp.Converters
{
    public class LanguageTagToNativeNameConverter : IValueConverter
    {
        private const string nativeLanguageResourceName = "LanguageName";
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string languageTag = value as string;
            if (languageTag != null)
            {
                var stringProvider = new ReswStringsProvider();
                return stringProvider.GetLocalizedString(nativeLanguageResourceName, languageTag);
            }
            throw new ArgumentException("Value must be a valid string language tag.");

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
