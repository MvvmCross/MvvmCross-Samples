using System;
using System.Linq;
using AppKit;
using Foundation;

namespace XPlatformMenus.Mac
{
	public class PageControllerDelegate : NSPageControllerDelegate
	{
		public override void WillStartLiveTransition(NSPageController pageController)
		{
//			base.WillStartLiveTransition(pageController);
		}

		public override void DidTransition(NSPageController pageController, NSObject targetObject)
		{
			// in this case just swap the view with the stored view
			var targetView = targetObject as NSView;
			if (targetView != null)
			{
				// clear the deck
				while (pageController.View.Subviews.Any())
				{
					pageController.View.Subviews[0].RemoveFromSuperview();
				}

				// prep the view
				//targetView.TranslatesAutoresizingMaskIntoConstraints = false;
				//targetView.AutoresizingMask = NSViewResizingMask.MinXMargin | NSViewResizingMask.MaxXMargin |
				//	NSViewResizingMask.MinYMargin | NSViewResizingMask.MaxXMargin;

				//pageController.View.AddConstraints(NSLayoutConstraint.FromVisualFormat(
				//	"H:|-[target]-|", NSLayoutFormatOptions.None, "target", targetView));
				//pageController.View.AddConstraints(NSLayoutConstraint.FromVisualFormat(
				//	"V:|-[target]-|", NSLayoutFormatOptions.None, "target", targetView));
				pageController.View.AddSubview(targetView);
			}
		}

		public override void DidEndLiveTransition(NSPageController pageController)
		{
//			base.DidEndLiveTransition(pageController);
		}
	}
}

