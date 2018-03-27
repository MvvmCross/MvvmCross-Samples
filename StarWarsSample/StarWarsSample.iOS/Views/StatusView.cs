using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Color.Platforms.Ios;
using OxyPlot.Xamarin.iOS;
using StarWarsSample.Core;
using StarWarsSample.Core.Resources;
using StarWarsSample.Core.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxModalPresentation(WrapInNavigationController = true, ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve)]
    public class StatusView : MvxViewController<StatusViewModel>
    {
        private UIImageView _imgBackground;
        private UILabel _lblTitle;
        private PlotView _plotView;
        private UIBarButtonItem _btnClose;

        public StatusView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.Clear;

            _imgBackground = new UIImageView(UIImage.FromBundle("Background.jpg"))
            {
                ContentMode = UIViewContentMode.ScaleAspectFill
            };

            Title = Strings.Statistics;

            _btnClose = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, null);
            NavigationItem.SetLeftBarButtonItem(_btnClose, false);

            _lblTitle = new UILabel
            {
                Font = UIFont.SystemFontOfSize(28f, UIFontWeight.Bold),
                TextColor = AppColors.AccentColor.ToNativeColor(),
                Text = Strings.DeathStarStatus
            };

            _plotView = new PlotView();
            _plotView.BackgroundColor = UIColor.Clear;

            View.AddSubviews(_imgBackground, _lblTitle, _plotView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _imgBackground.AtLeftOf(View),
                _imgBackground.AtTopOf(View),
                _imgBackground.AtBottomOf(View),
                _imgBackground.AtRightOf(View),

                _lblTitle.AtLeftOf(View, 12f),
                _lblTitle.AtTopOf(View, 8f),
                _lblTitle.AtRightOf(View, 12f),

                _plotView.Below(_lblTitle),
                _plotView.AtLeftOf(View),
                _plotView.AtRightOf(View),
                _plotView.AtBottomOf(View)
            );

            View.BringSubviewToFront(_plotView);

            var set = this.CreateBindingSet<StatusView, StatusViewModel>();
            set.Bind(_plotView).For(v => v.Model).To(vm => vm.PlotModel);
            set.Bind(_btnClose).For("Clicked").To(vm => vm.CloseCommand);
            set.Apply();
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);
            _plotView.InvalidatePlot(false);
        }
    }
}
