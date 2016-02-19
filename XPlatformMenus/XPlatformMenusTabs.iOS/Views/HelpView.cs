using Foundation;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("HelpView")]
    public class HelpView : BaseViewController<HelpAndFeedbackViewModel>
    {

        public override void ViewWillAppear(bool animated)
        {
            NavigationController.SetNavigationBarHidden(true, true);
            Title = "Help View";
            base.ViewWillAppear(animated);
        }
    }
}
