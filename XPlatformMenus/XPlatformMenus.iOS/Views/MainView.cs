using Foundation;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Panels;

namespace XPlatformMenus.Touch.Views
{
    [Register("MainView")]
	[PanelPresentation(PanelEnum.Center, PanelHintType.ResetRoot, true)]
    public class MainView : BaseViewController<MainViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewModel.ShowMenu();
        }
    }   
}