using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using UIKit;

namespace ApiExamples.Ios
{
    public class OnlyTwoDeepPresenter : MvxIosViewPresenter
    {
        public OnlyTwoDeepPresenter(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public override void Show(MvvmCross.iOS.Views.IMvxIosView view)
        {
            if (MasterNavigationController == null)
            {
                base.Show(view);
                return;
            }

            if (MasterNavigationController.ViewControllers.Length <= 1)
            {
                base.Show(view);
                return;
            }

            MasterNavigationController.PopViewController(false);
            MasterNavigationController.PushViewController(
                view as UIViewController,
                true);
        }
    }
}