using Foundation;
using UIKit;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Views;
using Margins = Cirrious.FluentLayouts.Touch.Margins;

namespace XPlatformMenusTabs.iOS.Views
{
    [Register("HomeView")]
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

            var textMessage = new UITextField { Placeholder = "This is the home view", BorderStyle = UITextBorderStyle.RoundedRect };

            Add(scrollView);

//            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
//
//            View.AddConstraints(
//                scrollView.AtLeftOf(View),
//                scrollView.AtTopOf(View),
//                scrollView.WithSameWidth(View),
//                scrollView.WithSameHeight(View));
//
//            scrollView.Add(textMessage);
//
//            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
//
//            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 10, 20, 10, 5, 5), scrollView.Subviews);
//            scrollView.AddConstraints(constraints);
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Home View";
            base.ViewWillAppear(animated);
        }
    }
}
