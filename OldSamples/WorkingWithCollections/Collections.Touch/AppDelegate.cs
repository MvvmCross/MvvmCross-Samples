using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;

namespace Collections.Touch
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate
        : MvxApplicationDelegate
    {
        // class-level declarations
        private UIWindow _window;

        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
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
    }
}