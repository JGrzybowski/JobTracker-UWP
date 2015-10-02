using JobTracker.Models;
using JobTracker.UniversalApp.Services.ResourcesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace JobTracker.UniversalApp.Converters
{
    public class PeriodFormater : IValueConverter
    {
        static Dictionary<TimeUnit, string> datesFormats = new Dictionary<TimeUnit, string> {
            {TimeUnit.Days, "dd" }, {TimeUnit.Months, "MM" }, {TimeUnit.Years, "yyyy" },
            {TimeUnit.DayAndMonth, "dd.MM" }, { TimeUnit.MonthAndYear, "MM yyyy" }, {TimeUnit.Full, "dd.MM.yyyy" }
        };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string param;
            param = parameter as string;

            var period = value as Period;
            bool from = false, to = false;
            if(period != null)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    from = true;
                    to = period.DatesVisibility.Equals(DatesVisibility.Both);
                }
                else if (param == nameof(Period.From))
                    from = true;
                else if (param == nameof(Period.To))
                    to = true;
                else
                    throw new ArgumentOutOfRangeException("parameter", string.Format("Parameter must be \"{0}\" or \"{1}\" or null.", nameof(Period.From), nameof(Period.To)));

                StringBuilder sb = new StringBuilder();
                if (from)
                    sb.Append(period.From.Date.ToString(datesFormats[period.DatesPartsVisibility]));
                if (from && to)
                    sb.Append(" - ");
                if (to)
                {
                    if (period.TillNow == true)
                    {
                        var resoucesProvider = new ReswStringsProvider();
                        sb.Append(resoucesProvider.GetLocalizedString(Period.NowFieldName, language));
                    }
                    else
                    {
                        sb.Append(period.To.Date.ToString(datesFormats[period.DatesPartsVisibility]));
                    }
                }
                return sb.ToString();
            }
            throw new ArgumentException("value", "Value must be a Period object.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
