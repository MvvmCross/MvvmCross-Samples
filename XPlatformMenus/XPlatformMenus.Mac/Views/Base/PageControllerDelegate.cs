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
			var containerView = pageController.View;

			// in this case just swap the view with the stored view
			var targetView = targetObject as NSView;
			if (targetView != null)
			{
				while (containerView.Subviews.Any())
				{
					containerView.Subviews[0].RemoveFromSuperview();
				}

				targetView.TranslatesAutoresizingMaskIntoConstraints = false;
				containerView.AddSubview(targetView);
				NSDictionary views = NSDictionary.FromObjectAndKey(targetView, new NSString("target"));
				containerView.AddConstraints(NSLayoutConstraint.FromVisualFormat(
					"H:|-10-[target]-10-|", NSLayoutFormatOptions.None, null, views));
				containerView.AddConstraints(NSLayoutConstraint.FromVisualFormat(
					"V:|-10-[target]-10-|", NSLayoutFormatOptions.None, null, views));
			}
		}

		public override void DidEndLiveTransition(NSPageController pageController)
		{
//			base.DidEndLiveTransition(pageController);
		}
	}
}

