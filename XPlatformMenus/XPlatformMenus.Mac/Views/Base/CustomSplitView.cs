using System;
using AppKit;
using Foundation;
using MvvmCross.Platform;

namespace XPlatformMenus.Mac.Views
{
	[Register("CustomSplitView")]
	public class CustomSplitView : NSSplitView
	{
		#region Constructors

		// Called when created from unmanaged code
		public CustomSplitView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		public CustomSplitView(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		public override void AdjustSubviews()
		{
			// we want to keep the left subview width the same
			try
			{
				// this leads to issues with constraints though.
				var oldWidth = Subviews[0].Frame.Width;

				base.AdjustSubviews();

				var newFrame = Subviews[0].Frame;
				var diff = newFrame.Width - oldWidth;
				newFrame.Width = oldWidth;

				Subviews[0].Frame = newFrame;

				var newFrame2 = Subviews[1].Frame;
				newFrame2.Width = newFrame2.Width + diff;
				Subviews[1].Frame = newFrame2;
			}
			catch (Exception ex) 
			{
				// what if we get too small
				Mvx.Trace(ex.Message);
			}
		}
	}
}

