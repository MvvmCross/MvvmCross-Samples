using Foundation;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("SettingsView")]
    public class SettingsView : BaseViewController<SettingsViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.SetNavigationBarHidden(true, false);
        }
    }
}
