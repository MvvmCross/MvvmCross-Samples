using MvvmCross.Binding.BindingContext;
using CoreGraphics;
using Foundation;
using UIKit;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Touch.Panels;
using Cirrious.FluentLayouts.Touch;

namespace XPlatformMenus.Touch.Views
{
    [Register("MenuView")]
    [PanelPresentation(PanelEnum.Left, PanelHintType.ActivePanel, false)]
    public class MenuView : BaseViewController<MenuViewModel>
    {
        public MenuView()
        {}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var scrollView = new UIScrollView(View.Frame)
            {
                ShowsHorizontalScrollIndicator = false,
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight
            };

            // create a binding set for the appropriate view model
            var set = this.CreateBindingSet<MenuView, MenuViewModel>();

            var homeButton = new UIButton(new CGRect(0, 100, 320, 40));
            homeButton.SetTitle("Home", UIControlState.Normal);
            homeButton.BackgroundColor = UIColor.White;
            homeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(homeButton).To(vm => vm.ShowHomeCommand);

            var settingsButton = new UIButton(new CGRect(0, 100, 320, 40));
            settingsButton.SetTitle("Settings", UIControlState.Normal);
            settingsButton.BackgroundColor = UIColor.White;
            settingsButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(settingsButton).To(vm => vm.ShowSettingCommand);

            var helpButton = new UIButton(new CGRect(0, 100, 320, 40));
            helpButton.SetTitle("Help & Feedback", UIControlState.Normal);
            helpButton.BackgroundColor = UIColor.White;
            helpButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
            set.Bind(helpButton).To(vm => vm.ShowHelpCommand);

            set.Apply();

            Add(scrollView);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                scrollView.AtLeftOf(View),
                scrollView.AtTopOf(View),
                scrollView.WithSameWidth(View),
                scrollView.WithSameHeight(View));

            scrollView.Add(homeButton);
            scrollView.Add(settingsButton);
            scrollView.Add(helpButton);

            scrollView.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var constraints = scrollView.VerticalStackPanelConstraints(new Margins(20, 10, 20, 10, 5, 5), scrollView.Subviews);
            scrollView.AddConstraints(constraints);
        }

        public override void ViewWillAppear(bool animated)
        {
            Title = "Left Menu View";
            base.ViewWillAppear(animated);

            NavigationController.NavigationBarHidden = true;
        }
    }
}
