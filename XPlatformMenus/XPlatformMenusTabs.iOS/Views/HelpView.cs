using Foundation;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("HelpView")]
    public class HelpView : BaseViewController<HelpAndFeedbackViewModel>
    {

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.SetNavigationBarHidden(true, false);
        }
    }
}
