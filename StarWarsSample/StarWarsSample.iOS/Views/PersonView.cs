using Airbnb.Lottie;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Base;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Color.Platforms.Ios;
using MvvmCross.ViewModels;
using StarWarsSample.Core;
using StarWarsSample.Core.MvxInteraction;
using StarWarsSample.Core.Resources;
using StarWarsSample.Core.ViewModels;
using StarWarsSample.iOS.CustomControls;
using StarWarsSample.iOS.Extensions;
using TZStackView;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxChildPresentation]
    public class PersonView : MvxViewController<PersonViewModel>
    {
        private const float HEADER_HEIGHT = 160f;

        private UIScrollView _scrollView;
        private UIView _contentView;
        private TwitterCoverImageView _twitterCoverImageView;
        private UILabel _lblName;
        private UIView _line;
        private StackView _stackInfo;
        private InfoView _viewHeight, _viewMass, _viewHairColor, _viewSkinColor, _viewEyeColor, _viewBirthYear, _viewGender;
        private UIButton _btnDestroy;

        private LOTAnimationView _animation;

        private IMvxInteraction<DestructionAction> _interaction;
        public IMvxInteraction<DestructionAction> Interaction
        {
            get => _interaction;
            set
            {
                if (_interaction != null)
                    _interaction.Requested -= OnInteractionRequested;

                _interaction = value;
                _interaction.Requested += OnInteractionRequested;
            }
        }

        public PersonView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Person Target details";

            View.BackgroundColor = UIColor.Black;

            _scrollView = new UIScrollView();

            _twitterCoverImageView = new TwitterCoverImageView
            {
                CoverViewHeight = HEADER_HEIGHT,
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("Person_Header"),
                ScrollView = _scrollView
            };

            _line = new UIView
            {
                BackgroundColor = UIColor.LightGray
            };

            _contentView = new UIView();

            _stackInfo = new StackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 8f
            };
            _lblName = new UILabel
            {
                Font = UIFont.SystemFontOfSize(28f, UIFontWeight.Bold),
                TextColor = AppColors.AccentColor.ToNativeColor()
            };

            _viewHeight = new InfoView();
            _viewHeight.Label.Text = Strings.Height;

            _viewMass = new InfoView();
            _viewMass.Label.Text = Strings.Mass;

            _viewHairColor = new InfoView();
            _viewHairColor.Label.Text = Strings.HairColor;

            _viewSkinColor = new InfoView();
            _viewSkinColor.Label.Text = Strings.SkinColor;

            _viewEyeColor = new InfoView();
            _viewEyeColor.Label.Text = Strings.EyeColor;

            _viewBirthYear = new InfoView();
            _viewBirthYear.Label.Text = Strings.BirthYear;

            _viewGender = new InfoView();
            _viewGender.Label.Text = Strings.Gender;

            _btnDestroy = new UIButton
            {
                BackgroundColor = UIColor.Red
            };
            _btnDestroy.Layer.CornerRadius = 8f;
            _btnDestroy.SetTitle(Strings.Destroy.ToUpper(), UIControlState.Normal);
            _btnDestroy.SetTitleColor(UIColor.White, UIControlState.Normal);
            _btnDestroy.SetTitleColor(UIColor.LightGray, UIControlState.Selected);
            _btnDestroy.PulseToSize(1.2f, 2f, true, true);

            _animation = LOTAnimationView.AnimationNamed("starwars2");
            _animation.Hidden = true;

            _scrollView.AddSubview(_twitterCoverImageView);

            View.AddSubviews(_scrollView);
            View.AddSubview(_animation);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _scrollView.AddSubviews(_lblName, _line, _contentView);
            _scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _contentView.AddSubviews(_stackInfo, _btnDestroy);
            _contentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _stackInfo.AddArrangedSubview(_viewHeight);
            _stackInfo.AddArrangedSubview(_viewMass);
            _stackInfo.AddArrangedSubview(_viewHairColor);
            _stackInfo.AddArrangedSubview(_viewSkinColor);
            _stackInfo.AddArrangedSubview(_viewEyeColor);
            _stackInfo.AddArrangedSubview(_viewBirthYear);
            _stackInfo.AddArrangedSubview(_viewGender);

            View.AddConstraints(
                _scrollView.AtLeftOf(View),
                _scrollView.AtTopOf(View),
                _scrollView.AtRightOf(View),
                _scrollView.AtBottomOf(View),

                _animation.AtLeftOf(View),
                _animation.AtTopOf(View),
                _animation.AtRightOf(View),
                _animation.AtBottomOf(View)
            );

            _scrollView.AddConstraints(
                _line.AtTopOf(_scrollView, HEADER_HEIGHT),
                _line.AtLeftOf(_scrollView),
                _line.AtRightOf(_scrollView),
                _line.Height().EqualTo(.5f),

                _lblName.Above(_line, 8f),
                _lblName.AtLeftOf(_line, 8f),

                _contentView.Below(_line),
                _contentView.AtLeftOf(_scrollView),
                _contentView.AtRightOf(_scrollView),
                _contentView.AtBottomOf(_scrollView)
            );

            View.AddConstraints(
                _contentView.WithSameWidth(View)
            );

            _contentView.AddConstraints(
                _stackInfo.AtTopOf(_contentView),
                _stackInfo.AtLeftOf(_contentView),
                _stackInfo.AtRightOf(_contentView),

                _btnDestroy.Below(_stackInfo, 20f),
                _btnDestroy.WithSameCenterX(_contentView),
                _btnDestroy.AtBottomOf(_contentView, 300f),
                _btnDestroy.Width().EqualTo(120f)
            );

            var set = this.CreateBindingSet<PersonView, PersonViewModel>();

            set.Bind(_lblName).To(vm => vm.Person.Name);
            set.Bind(_viewHeight.Information).To(vm => vm.Person.Height);
            set.Bind(_viewHeight).For("Visibility").To(vm => vm.Person.Height).WithConversion("Visibility");

            set.Bind(_viewMass.Information).To(vm => vm.Person.Mass);
            set.Bind(_viewMass).For("Visibility").To(vm => vm.Person.Mass).WithConversion("Visibility");

            set.Bind(_viewHairColor.Information).To(vm => vm.Person.HairColor);
            set.Bind(_viewHairColor).For("Visibility").To(vm => vm.Person.HairColor).WithConversion("Visibility");

            set.Bind(_viewSkinColor.Information).To(vm => vm.Person.SkinColor);
            set.Bind(_viewSkinColor).For("Visibility").To(vm => vm.Person.SkinColor).WithConversion("Visibility");

            set.Bind(_viewEyeColor.Information).To(vm => vm.Person.EyeColor);
            set.Bind(_viewEyeColor).For("Visibility").To(vm => vm.Person.EyeColor).WithConversion("Visibility");

            set.Bind(_viewBirthYear.Information).To(vm => vm.Person.BirthYear);
            set.Bind(_viewBirthYear).For("Visibility").To(vm => vm.Person.BirthYear).WithConversion("Visibility");

            set.Bind(_viewGender.Information).To(vm => vm.Person.Gender);
            set.Bind(_viewGender).For("Visibility").To(vm => vm.Person.Gender).WithConversion("Visibility");

            set.Bind(_btnDestroy).To(vm => vm.DestroyPersonCommand);
            set.Bind(this).For(v => v.Interaction).To(vm => vm.Interaction);
            set.Apply();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            NavigationController.SetNavigationBarHidden(true, false);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            NavigationController.SetNavigationBarHidden(false, false);
        }

        private void OnInteractionRequested(object sender, MvxValueEventArgs<DestructionAction> eventArgs)
        {
            _animation.Hidden = false;
            _animation.PlayWithCompletion(
                (animationFinished) =>
            {
                eventArgs.Value.OnDestroyed();
            });
        }
    }
}
