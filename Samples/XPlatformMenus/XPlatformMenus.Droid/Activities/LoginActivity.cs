using Android.App;
using Android.Content.PM;
using Android.OS;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace XPlatformMenus.Droid.Activities
{
    [Activity(
        Label = "Examples",
        Theme = "@style/AppTheme.Login",
        LaunchMode = LaunchMode.SingleTop,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Name = "xplatformmenus.droid.activities.LoginActivity"
    )]			
    public class LoginActivity : MvxAppCompatActivity<LoginViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_login);
        }
    }
}

