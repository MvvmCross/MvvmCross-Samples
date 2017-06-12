using System;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using MvvmCross.Droid.Shared.Attributes;
using StarWarsSample.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("starWarsSample.droid.views.PlanetView")]
    public class PlanetView : BaseFragment<PlanetViewModel>
    {
        protected override int FragmentId => Resource.Layout.PlanetView;

        private Button _btnDestroy;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = "Planet Target Details";

            _btnDestroy = view.FindViewById<Button>(Resource.Id.btn_destroy);

            return view;
        }

        public override void OnResume()
        {
            base.OnResume();

            var myAnimation = AnimationUtils.LoadAnimation(Context, Resource.Animation.pulse_animation);
            _btnDestroy.StartAnimation(myAnimation);
        }

        public override void OnPause()
        {
            base.OnPause();

            _btnDestroy.ClearAnimation();
        }
    }
}
