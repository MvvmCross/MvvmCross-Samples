using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using UIKit;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Panels;

namespace XPlatformMenus.Touch.Views
{
    [Register("HomeView")]
    [PanelPresentation(PanelEnum.Center, PanelHintType.ResetRoot, true)]
    public class HomeView : BaseViewController<HomeViewModel>
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var viewModel = this.ViewModel;

            var scrollView = new UIScrollView(View.Frame)
            {
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };

            var infoButton = new UIButton();
            infoButton.SetTitle("Show Info ViewModel", UIControlState.Normal);
            infoButton.BackgroundColor = UIColor.Blue;
            scrollView.AddSubviews( infoButton);

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));
            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<HomeView, HomeViewModel>();
            set.Bind(infoButton).To("GoToInfoCommand");
            set.Apply();

            scrollView.AddConstraints(
               
                infoButton.Below(scrollView).Plus(10),
                infoButton.WithSameWidth(scrollView),
                infoButton.WithSameLeft(scrollView)
                );

        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Home View";
            base.ViewWillAppear(animated);
        }
    }
}
