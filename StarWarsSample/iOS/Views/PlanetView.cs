using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.iOS.CustomViews;
using StarWarsSample.iOS.Extensions;
using StarWarsSample.Resources;
using StarWarsSample.ViewModels;
using TZStackView;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxChildPresentation]
    public class PlanetView : MvxViewController<PlanetViewModel>
    {
        private UIScrollView _scrollView;
        private UIView _contentView;
        private TwitterCoverImageView _twitterCoverImageView;

        private StackView _stackInfo;
        private InfoView _viewName, _viewClimate, _viewDiameter, _viewGravity, _viewTerrain, _viewPopulation;

        private UIButton _btnDestroy;

        public PlanetView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Planet Target details";

            View.BackgroundColor = UIColor.White;

            _scrollView = new UIScrollView();

            _twitterCoverImageView = new TwitterCoverImageView
            {
                CoverViewHeight = 80f,
                BackgroundColor = UIColor.Clear,
                Image = UIImage.FromBundle("ic_vader"),
                ScrollView = _scrollView
            };
            _scrollView.AddSubview(_twitterCoverImageView);

            _contentView = new UIView { BackgroundColor = UIColor.White };

            _stackInfo = new StackView
            {
                Axis = UILayoutConstraintAxis.Vertical,
                Spacing = 8f
            };
            _viewName = new InfoView();
            _viewName.Label.Text = Strings.Name;

            _viewClimate = new InfoView();
            _viewClimate.Label.Text = Strings.Climate;

            _viewDiameter = new InfoView();
            _viewDiameter.Label.Text = Strings.Diameter;

            _viewGravity = new InfoView();
            _viewGravity.Label.Text = Strings.Gravity;

            _viewTerrain = new InfoView();
            _viewTerrain.Label.Text = Strings.Terrain;

            _viewPopulation = new InfoView();
            _viewPopulation.Label.Text = Strings.Population;

            _btnDestroy = new UIButton
            {
                BackgroundColor = UIColor.Red
            };
            _btnDestroy.Layer.CornerRadius = 5f;
            _btnDestroy.SetTitle(Strings.Destroy.ToUpper(), UIControlState.Normal);
            _btnDestroy.SetTitleColor(UIColor.White, UIControlState.Normal);
            _btnDestroy.SetTitleColor(UIColor.LightGray, UIControlState.Selected);
            _btnDestroy.PulseToSize(1.2f, 2f, true, true);

            View.AddSubviews(_scrollView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _scrollView.AddSubview(_contentView);
            _scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _contentView.AddSubviews(_stackInfo, _btnDestroy);
            _contentView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            _stackInfo.AddArrangedSubview(_viewName);
            _stackInfo.AddArrangedSubview(_viewClimate);
            _stackInfo.AddArrangedSubview(_viewDiameter);
            _stackInfo.AddArrangedSubview(_viewGravity);
            _stackInfo.AddArrangedSubview(_viewTerrain);
            _stackInfo.AddArrangedSubview(_viewPopulation);

            View.AddConstraints(
                _scrollView.AtLeftOf(View),
                _scrollView.AtTopOf(View),
                _scrollView.AtRightOf(View),
                _scrollView.AtBottomOf(View)
            );

            _scrollView.AddConstraints(
                _contentView.AtTopOf(_scrollView, 80f),
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
                _btnDestroy.AtBottomOf(_contentView, 150f),
                _btnDestroy.Width().EqualTo(120f)
            );

            var set = this.CreateBindingSet<PlanetView, PlanetViewModel>();
            set.Bind(_viewName.Information).To(vm => vm.Planet.Name);
            set.Bind(_viewClimate.Information).To(vm => vm.Planet.Climate);
            set.Bind(_viewDiameter.Information).To(vm => vm.Planet.Diameter);
            set.Bind(_viewGravity.Information).To(vm => vm.Planet.Gravity);
            set.Bind(_viewTerrain.Information).To(vm => vm.Planet.Terrain);
            set.Bind(_viewPopulation.Information).To(vm => vm.Planet.Population);
            set.Bind(_btnDestroy).To(vm => vm.DestroyPlanetCommand);
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
    }
}
