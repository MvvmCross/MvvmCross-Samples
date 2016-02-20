using Foundation;
using MvvmCross.Binding.BindingContext;
using UIKit;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("HomeView")]
    public class HomeView : BaseViewController<HomeViewModel>
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController.SetNavigationBarHidden(true, false);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UIButton infoButton = new UIButton(View.Frame);
            infoButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            infoButton.SetTitle("Show info", UIControlState.Normal);
            View.AddSubview(infoButton);
            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(infoButton).To(vm => vm.GoToInfoCommand);
            set.Apply();
        }
    }
}
