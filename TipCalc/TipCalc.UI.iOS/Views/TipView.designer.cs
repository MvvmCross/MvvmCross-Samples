// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//

using System.CodeDom.Compiler;
using Foundation;
using UIKit;

namespace TipCalc.UI.iOS.Views
{
	[Register ("TipView")]
	partial class TipView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISlider GenerositySlider { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField SubTotalTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel TipLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (GenerositySlider != null) {
				GenerositySlider.Dispose ();
				GenerositySlider = null;
			}
			if (SubTotalTextField != null) {
				SubTotalTextField.Dispose ();
				SubTotalTextField = null;
			}
			if (TipLabel != null) {
				TipLabel.Dispose ();
				TipLabel = null;
			}
		}
	}
}
