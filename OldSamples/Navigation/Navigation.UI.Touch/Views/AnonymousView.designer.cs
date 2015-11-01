// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Navigation.UI.Touch
{
	[Register ("AnonymousView")]
	partial class AnonymousView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel KeyLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (KeyLabel != null) {
				KeyLabel.Dispose ();
				KeyLabel = null;
			}
		}
	}
}
