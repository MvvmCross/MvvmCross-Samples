using System;
using AppKit;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

namespace XPlatformMenus.Mac.Views
{
	public class SplitViewDelegate : NSSplitViewDelegate
	{
		public override void Resize(NSSplitView splitView, CoreGraphics.CGSize oldSize)
		{
			//Mvx.Trace(MvxTraceLevel.Diagnostic,oldSize.Width.ToString());

			splitView.AdjustSubviews();
		}

		//public override nfloat SetMinCoordinateOfSubview(NSSplitView splitView, nfloat proposedMinimumPosition, nint subviewDividerIndex)
		//{
		//	return 50.0f;
		//}

		//public override nfloat SetMaxCoordinateOfSubview(NSSplitView splitView, nfloat proposedMaximumPosition, nint subviewDividerIndex)
		//{
		//	return 130.0f;
		//}
	}
}

