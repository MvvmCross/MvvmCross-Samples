using Foundation;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Views;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("HelpView")]
    public class HelpView : BaseViewController<HelpAndFeedbackViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            Title = "Help View";
            base.ViewWillAppear(animated);
        }
    }
}
