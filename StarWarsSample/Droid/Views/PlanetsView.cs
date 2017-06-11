using System;
using Android;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using StarWarsSample.Droid.Views;
using StarWarsSample.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("starWarsSample.droid.views.PlanetsView")]
    public class PlanetsView : BaseFragment<PlanetsViewModel>
    {
        protected override int FragmentId => Resource.Layout.PlanetsView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);


            return view;
        }

    }
}
