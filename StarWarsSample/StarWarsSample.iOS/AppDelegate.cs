using Foundation;
using MvvmCross.Platforms.Ios.Core;
using MvvmCross.Plugin.Color.Platforms.Ios;
using StarWarsSample.Core;
using UIKit;

namespace StarWarsSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            var result = base.FinishedLaunching(application, launchOptions);

            CustomizeAppearance();

            return result;
        }

        private void CustomizeAppearance()
        {
            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarPosition.Any, UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();

            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                TextColor = UIColor.White,
                Font = UIFont.SystemFontOfSize(17f, UIFontWeight.Semibold)
            });
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

            UITextField.Appearance.TintColor = AppColors.AccentColor.ToNativeColor();
            UITextView.Appearance.TintColor = AppColors.AccentColor.ToNativeColor();
            UIButton.Appearance.SetTitleColor(AppColors.AccentColor.ToNativeColor(), UIControlState.Highlighted);
        }
    }
}

