using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Platform;
using UIKit;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenusTabs.iOS.Interfaces;

namespace XPlatformMenusTabs.iOS.Views
{
    public class TabBarController : MvxTabBarViewController, ITabBarPresenter
    {
        public TabBarController()
        {
            Mvx.Resolve<ITabBarPresenterHost>().TabBarPresenter = this;

            // because the UIKit base class does ViewDidLoad, we have to make a second call here
            ViewDidLoad();
        }

        private int _createdSoFarCount = 0;

        private UIViewController CreateTabFor(string title, string imageName, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            controller.NavigationBar.TintColor = UIColor.Black;
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            SetTitleAndTabBarItem(screen, title, imageName);
            controller.PushViewController(screen, false);
            return controller;
        }

        private void SetTitleAndTabBarItem(UIViewController screen, string title, string imageName)
        {
            screen.Title = title;
            screen.TabBarItem = new UITabBarItem(title, null, _createdSoFarCount);
            _createdSoFarCount++;
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationController?.SetNavigationBarHidden(true, false);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // first time around this will be null, second time it will be OK
            if (ViewModel == null)
                return;

            HomeViewModel homeViewModel = (HomeViewModel) Mvx.IocConstruct(typeof (HomeViewModel));
            SettingsViewModel settingsViewModel = (SettingsViewModel) Mvx.IocConstruct(typeof(SettingsViewModel));
            HelpAndFeedbackViewModel helpAndFeedbackViewModel = (HelpAndFeedbackViewModel) Mvx.IocConstruct(typeof(HelpAndFeedbackViewModel));
            var viewControllers = new[]
            {
                CreateTabFor("Home", "", homeViewModel),
                CreateTabFor("Settings", "", settingsViewModel),
                CreateTabFor("Help", "", helpAndFeedbackViewModel),
            };
            ViewControllers = viewControllers;
            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];
        }

        public new MainViewModel ViewModel
        {
            get { return (MainViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public bool GoBack()
        {
            var subNavigation = this.SelectedViewController as UINavigationController;
            if (subNavigation == null)
                return false;

            if (subNavigation.ViewControllers.Length <= 1)
                return false;

            subNavigation.PopViewController(true);
            return true;
        }

        public bool ShowView(IMvxIosView view)
        {
            if (TryShowViewInCurrentTab(view))
                return true;

            return false;
        }

        private bool TryShowViewInCurrentTab(IMvxIosView view)
        {
            var navigationController = (UINavigationController)this.SelectedViewController;
            navigationController.PushViewController((UIViewController)view, true);
            return true;
        }
    }
}