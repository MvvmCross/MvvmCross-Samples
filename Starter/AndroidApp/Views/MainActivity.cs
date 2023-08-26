using Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace AndroidApp.Views;

[Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
public sealed class MainActivity : MvxActivity<MainViewModel>
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
    }
}