using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Views;

namespace Babel.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondView);
        }
    }
}
