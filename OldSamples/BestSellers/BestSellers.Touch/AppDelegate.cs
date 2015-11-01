using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace BestSellers.Touch
{
    [Register("AppDelegate")]
    public partial class AppDelegate
        : MvxApplicationDelegate

    {
        private UIWindow _window;

        // This method is invoked when the application has loaded its UI and its ready to run
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            _window = new UIWindow(UIScreen.MainScreen.Bounds);

            // initialize app for single screen iPhone display
            var presenter = new MvxTouchViewPresenter(this, _window);
            var setup = new Setup(this, presenter);
            setup.Initialize();

            // start the app
            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _window.MakeKeyAndVisible();

            return true;
        }

        // This method is required in iPhoneOS 3.0
        public override void OnActivated(UIApplication application)
        {
        }
    }
}