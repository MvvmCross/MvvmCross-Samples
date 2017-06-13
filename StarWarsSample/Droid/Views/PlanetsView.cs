﻿using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.RecyclerView;
using StarWarsSample.Droid.Extensions;
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

            ParentActivity.SupportActionBar.Title = "Target: Planets";

            var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.planets_recycler_view);
            if (recyclerView != null)
            {
                recyclerView.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);

                recyclerView.AddOnScrollFetchItemsListener(layoutManager, () => ViewModel.FetchPlanetsTask, () => this.ViewModel.FetchPlanetCommand);
            }

            return view;
        }
    }
}
