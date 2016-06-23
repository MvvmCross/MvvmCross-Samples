// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TipCalc.UI.Mac
{
	[Register ("TipViewController")]
	partial class TipViewController
	{
		[Outlet]
		AppKit.NSSlider GenerositySlider { get; set; }

		[Outlet]
		AppKit.NSTextField SubTotalTextField { get; set; }

		[Outlet]
		AppKit.NSTextField TipAmountLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SubTotalTextField != null) {
				SubTotalTextField.Dispose ();
				SubTotalTextField = null;
			}

			if (GenerositySlider != null) {
				GenerositySlider.Dispose ();
				GenerositySlider = null;
			}

			if (TipAmountLabel != null) {
				TipAmountLabel.Dispose ();
				TipAmountLabel = null;
			}
		}
	}
}
