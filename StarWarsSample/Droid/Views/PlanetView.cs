using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using StarWarsSample.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("starWarsSample.droid.views.PlanetView")]
    public class PlanetView : BaseFragment<PlanetViewModel>
    {
        protected override int FragmentId => Resource.Layout.PlanetView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = "Planet Target Details";


            return view;
        }

    }
}
