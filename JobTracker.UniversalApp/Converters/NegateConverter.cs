using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace JobTracker.UniversalApp.Converters
{
    public class NegateConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return Negate(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return Negate(value);
        }

        private object Negate(object value)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            throw new NotImplementedException();
        }

    }
}
