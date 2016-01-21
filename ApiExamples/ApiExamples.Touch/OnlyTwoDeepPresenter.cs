//using Cirrious.MvvmCross.Touch.Platform;
//using Cirrious.MvvmCross.Touch.Views.Presenters;

using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.iOS.Views;
using MvvmCross.Platform.iOS.Platform;
using UIKit;

namespace ApiExamples.Touch
{
    public class OnlyTwoDeepPresenter : MvxTouchViewPresenter
    {
        public OnlyTwoDeepPresenter(IMvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        public override void Show(Cirrious.MvvmCross.Touch.Views.IMvxTouchView view)
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