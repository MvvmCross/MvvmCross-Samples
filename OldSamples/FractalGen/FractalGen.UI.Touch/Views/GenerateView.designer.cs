// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace FractalGen.UI.Touch
{
	[Register ("GenerateView")]
	partial class GenerateView
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView FractalImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UISwitch AutoRunSwitch { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton RefreshButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FractalImage != null) {
				FractalImage.Dispose ();
				FractalImage = null;
			}

			if (AutoRunSwitch != null) {
				AutoRunSwitch.Dispose ();
				AutoRunSwitch = null;
			}

			if (RefreshButton != null) {
				RefreshButton.Dispose ();
				RefreshButton = null;
			}
		}
	}
}
