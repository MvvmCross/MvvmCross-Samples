using MvvmCross.Core.ViewModels;
using AppKit;
using System.Linq;

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
				if (Window.ContentView.Subviews.Any())
				{
					// there should be 1, and it should be the MainView
					var mainView = Window.ContentView.Subviews[0];
					if (mainView is MainView)
					{
						var mainViewController = mainView.NextResponder as MainViewController;
						if (mainViewController != null)
						{
							mainViewController.PopToRoot();
						}
					}
					return;
				}
            }

            base.ChangePresentation(hint);
        }
    }
}
