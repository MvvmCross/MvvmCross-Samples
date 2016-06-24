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
	}
}

