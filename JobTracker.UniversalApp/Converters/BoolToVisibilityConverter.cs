using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace JobTracker.UniversalApp.Converters
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                if((bool)value)
                    return Visibility.Visible;
                return Visibility.Collapsed;
            }
            throw new ArgumentException("Value must be a boolean value.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            Visibility visibility;
            if(Enum.TryParse<Visibility>(value.ToString(), out visibility))
            {
                if (visibility == Visibility.Visible)
                    return true;
                else return false;
            }
            throw new ArgumentException("Value must be Collapsed or Visible.");
        }
    }
}
