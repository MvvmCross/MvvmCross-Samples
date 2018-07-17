using Android.App;
using MvvmCross.Platforms.Android.Views;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.UI.Droid.Views
{
    [Activity(Label = "TwitterSearch", MainLauncher = true)]
    public class HomeView : MvxActivity<HomeViewModel>
    {
        protected override void OnCreate(Android.OS.Bundle bundle)        
        {
            //Log.Trace("OnCreate called with {0}", bundle == null);
            base.OnCreate(bundle);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_Home);
        }

        protected override void OnSaveInstanceState(Android.OS.Bundle outState)
        {
            //MvxTrace.Trace("SaveInstanceState called with {0}", outState == null);
            base.OnSaveInstanceState(outState);
        }
    }
}