using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace Navigation.UI.Touch
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxApplicationDelegate
    {
        private UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            window = new UIWindow(UIScreen.MainScreen.Bounds);

            var presenter = new MvxTouchViewPresenter(this, window);
            var setup = new Setup(this, presenter);
            setup.Initialize();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            window.MakeKeyAndVisible();

            return true;
        }
    }
}