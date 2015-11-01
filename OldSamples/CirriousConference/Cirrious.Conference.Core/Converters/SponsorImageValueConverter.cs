using Cirrious.CrossCore.Converters;
using System;

namespace Cirrious.Conference.Core.Converters
{
    public class SponsorImageValueConverter
        : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var stringValue = (string)value;
            return "/ConfResources/SponsorImages/" + stringValue;
        }
    }
}