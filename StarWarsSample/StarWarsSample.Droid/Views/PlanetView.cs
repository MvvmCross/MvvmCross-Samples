using Android.Animation;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Airbnb.Lottie;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Plugin.Color.Platforms.Android;
using MvvmCross.ViewModels;
using StarWarsSample.Core;
using StarWarsSample.Core.MvxInteraction;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("starWarsSample.droid.views.PlanetView")]
    public class PlanetView : BaseFragment<PlanetViewModel>, Animator.IAnimatorListener
    {
        protected override int FragmentId => Resource.Layout.PlanetView;

        private Android.Support.V7.Widget.Toolbar _toolbar;
        private Button _btnDestroy;
        private LottieAnimationView _animationView;

        private DestructionAction _interactionRequested;

        private IMvxInteraction<DestructionAction> _interaction;
        public IMvxInteraction<DestructionAction> Interaction
        {
            get => _interaction;
            set
            {
                if(_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            _toolbar = view.FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            _btnDestroy = view.FindViewById<Button>(Resource.Id.btn_destroy);
            _animationView = view.FindViewById<LottieAnimationView>(Resource.Id.animation_view);
            _animationView.ImageAssetsFolder = "imgs";
            _animationView.AddAnimatorListener(this);

            _toolbar.SetTitleTextColor(AppColors.AccentColor.ToNativeColor());

            this.AddBindings(_toolbar, "Title Planet.Name");
            this.AddBindings(this, "Interaction Interaction");

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

        private void OnInteractionRequested(object sender, MvxValueEventArgs<DestructionAction> eventArgs)
        {
            _animationView.Visibility = ViewStates.Visible;
            _animationView.Progress = 0;
            _animationView.PlayAnimation();

            _interactionRequested = eventArgs.Value;
        }

        public void OnAnimationCancel(Animator animation)
        {
        }

        public void OnAnimationEnd(Animator animation)
        {
            _interactionRequested?.OnDestroyed();
        }

        public void OnAnimationRepeat(Animator animation)
        {
        }

        public void OnAnimationStart(Animator animation)
        {
        }
    }
}
