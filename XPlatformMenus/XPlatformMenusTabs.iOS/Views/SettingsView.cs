using Foundation;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Views;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("SettingsView")]
    public class SettingsView : BaseViewController<SettingsViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            Title = "Settings View";
            base.ViewWillAppear(animated);
        }
    }
}
