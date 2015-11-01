using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using FractalGen.Core.Services.Fractal;

namespace FractalGen.UI.Phone.Converters
{
    public class BytesToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var bytes = (ISimpleWriteableBitmap) value;
            if (bytes == null)
                return null;

            var toReturn = new WriteableBitmap(bytes.Width, bytes.Height);
            Array.Copy(bytes.Pixels, toReturn.Pixels, bytes.Pixels.Length);
            return toReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}