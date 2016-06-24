using System;
using System.Linq;
using AppKit;
using Foundation;

namespace XPlatformMenus.Mac.Views
{
	public class PageControllerDelegate : NSPageControllerDelegate
	{
		// See https://developer.apple.com/library/mac/releasenotes/WindowsViews/NSPageControllerDelegate_Protocol/#//apple_ref/occ/intfm/NSPageControllerDelegate/pageController:identifierForObject:
		// Perhaps we should be using the ViewController code

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
				containerView.SwapSubView(targetView);
			}
		}

		public override void DidEndLiveTransition(NSPageController pageController)
		{
//			base.DidEndLiveTransition(pageController);
		}
	}
}

