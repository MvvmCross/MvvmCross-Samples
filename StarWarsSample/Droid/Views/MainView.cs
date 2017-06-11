using System;
using Android.App;
using MvvmCross.Droid.Support.V7.AppCompat;
using StarWarsSample.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [Activity]
    public class MainView : MvxCachingFragmentCompatActivity<MainViewModel>
    {
        public MainView()
        {
        }
    }
}
