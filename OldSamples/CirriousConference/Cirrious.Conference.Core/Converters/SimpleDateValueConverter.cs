using Cirrious.CrossCore.Converters;
using System;

namespace Cirrious.Conference.Core.Converters
{
    public class SimpleDateValueConverter
        : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (!(value is DateTime))
                return value;

            var format = parameter ?? "ddd h:mm";

            var dateValue = (DateTime)value;
            return dateValue.ToLocalTime().ToString((string)format);
        }
    }
}