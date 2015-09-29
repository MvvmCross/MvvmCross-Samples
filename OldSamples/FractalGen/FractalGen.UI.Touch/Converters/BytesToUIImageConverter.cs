using System;
using System.Collections.Generic;
using System.Linq;
using FractalGen.Core.Services.Fractal;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.CrossCore.Converters;
using MonoTouch.CoreGraphics;

namespace FractalGen.UI.Touch
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
				 
	public class BytesToUIImageConverter
		: MvxValueConverter<ISimpleWriteableBitmap, UIImage>
	{
		protected override UIImage Convert (ISimpleWriteableBitmap value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if (value == null)
				return null;

			var byteArray = new byte[value.Pixels.Length * 4];
			Buffer.BlockCopy(value.Pixels, 0, byteArray, 0, byteArray.Length);

			using (var colorSpace = CGColorSpace.CreateDeviceRGB())
			using (var bitmapContext =  new CGBitmapContext(byteArray, value.Width, value.Height, 8, 4*value.Width, colorSpace, CGBitmapFlags.PremultipliedLast | CGBitmapFlags.ByteOrderDefault))
			using (var image = bitmapContext.ToImage())
					return new UIImage(image);
		}
	}
	
}
