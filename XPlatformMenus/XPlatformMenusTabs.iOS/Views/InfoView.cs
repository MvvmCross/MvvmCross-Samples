using MvvmCross.Binding.BindingContext;
using UIKit;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenusTabs.iOS.Views
{
    public class InfoView : BaseViewController<InfoViewModel>
    {
        public InfoView() : base()
        {

        }

        public override void ViewWillAppear(bool animated)
        {
            NavigationController.SetNavigationBarHidden(false, false);
            base.ViewWillAppear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            UILabel label = new UILabel(View.Frame);
            View.AddSubview(label);
            var set = this.CreateBindingSet<InfoView, InfoViewModel>();
            set.Bind(label).To(vm => vm.Info);
            set.Apply();
        }
    }
}