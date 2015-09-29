using Cirrious.MvvmCross.ViewModels;

namespace TwitterSearch.UI.Touch
{
    [Register("AppDelegate")]
    public partial class AppDelegate
    : MvxApplicationDelegate
    {
        private UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // create a new window instance based on the screen size
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            var presenter =
                IsPad
                    ? (IMvxTouchViewPresenter)new TwitterTabletSearchPresenter(this, _window)
                    : (IMvxTouchViewPresenter)new TwitterPhoneSearchPresenter(this, _window);

            var setup = new Setup(this, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _window.MakeKeyAndVisible();

            return true;
        }

        public static bool IsPhone
        {
            get
            {
                return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
            }
        }

        public static bool IsPad
        {
            get
            {
                return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad;
            }
        }

        public static bool HasRetina
        {
            get
            {
                if (MonoTouch.UIKit.UIScreen.MainScreen.RespondsToSelector(new Selector("scale")))
                    return (MonoTouch.UIKit.UIScreen.MainScreen.Scale == 2.0);
                else
                    return false;
            }
        }
    }
}