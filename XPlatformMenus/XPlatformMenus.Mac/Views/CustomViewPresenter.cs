using MvvmCross.Core.ViewModels;
using AppKit;

namespace XPlatformMenus.Mac.Views
{
	public class CustomViewPresenter : MvxMultiRegionMacViewPresenter
    {
        public CustomViewPresenter(NSApplicationDelegate appDelegate, NSWindow window)
			: base(appDelegate, window)
        {
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxPanelPopToRootPresentationHint)
            {
				var viewController = Window.ContentViewController as MainViewController;
				if (viewController != null)
				{
					viewController.PopToRoot();
				}
            }

            base.ChangePresentation(hint);
        }
    }
}
