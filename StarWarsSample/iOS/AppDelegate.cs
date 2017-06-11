using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using MvvmCross.Plugins.Color.iOS;
using UIKit;

namespace StarWarsSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Window = new UIWindow(UIScreen.MainScreen.Bounds);

            var setup = new Setup(this, Window);
            setup.Initialize();

            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            Window.MakeKeyAndVisible();

            CustomizeAppearance();

            return true;
        }

        private void CustomizeAppearance()
        {
            var attributes = new UITextAttributes();
            attributes.TextColor = UIColor.White;
            attributes.TextShadowColor = UIColor.Clear;
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();

            UINavigationBar.Appearance.SetTitleTextAttributes(attributes);
            UINavigationBar.Appearance.Translucent = false;
            UINavigationBar.Appearance.BarTintColor = AppColors.PrimaryColor.ToNativeColor();
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BackgroundColor = AppColors.PrimaryColor.ToNativeColor();
            UINavigationBar.Appearance.BackIndicatorImage = new UIImage();

            UITabBar.Appearance.BackgroundColor = AppColors.PrimaryColor.ToNativeColor();
            UITabBarItem.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = AppColors.AccentColor.ToNativeColor()
            }, UIControlState.Selected);

            UITextField.Appearance.TintColor = AppColors.PrimaryColor.ToNativeColor();
            UITextView.Appearance.TintColor = AppColors.PrimaryColor.ToNativeColor();
        }
    }
}

