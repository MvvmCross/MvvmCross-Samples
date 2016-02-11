using Foundation;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Panels;

namespace XPlatformMenus.Touch.Views
{
    [Register("SettingsView")]
    [PanelPresentation(PanelEnum.Center, PanelHintType.ActivePanel, true)]
    public class SettingsView : BaseViewController<SettingsViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            Title = "Settings View";
            base.ViewWillAppear(animated);
        }
    }
}
