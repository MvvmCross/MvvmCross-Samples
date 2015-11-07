using Foundation;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Panels;

namespace XPlatformMenus.Touch.Views
{
    [Register("HelpView")]
    [PanelPresentation(PanelEnum.Center, PanelHintType.ActivePanel, true)]
    public class HelpView : BaseViewController<HelpAndFeedbackViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            Title = "Help View";
            base.ViewWillAppear(animated);
        }
    }
}
