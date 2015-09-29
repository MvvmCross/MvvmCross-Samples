using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using FractalGen.Core.Services.Fractal;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace FractalGen.UI.Store.Converters
{
    public class BytesToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var writeableBitmap = (ISimpleWriteableBitmap) value;
            if (writeableBitmap == null)
                return null;

            var byteArray = new byte[writeableBitmap.Pixels.Length*4];
            Buffer.BlockCopy(writeableBitmap.Pixels, 0, byteArray, 0, byteArray.Length);
            var toReturn = new WriteableBitmap(writeableBitmap.Width, writeableBitmap.Height);

            var pixelStream = toReturn.PixelBuffer.AsStream();
            pixelStream.Seek(0, SeekOrigin.Begin);
            pixelStream.Write(byteArray, 0, byteArray.Length);
            return toReturn;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}