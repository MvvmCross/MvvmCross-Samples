using System;
using System.Globalization;

namespace Tutorial.UI.WinRT.Converters
{
    public class InvertedConverter : MvxValueConverter
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}