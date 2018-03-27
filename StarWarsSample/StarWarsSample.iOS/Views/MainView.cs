using MvvmCross.Platforms.Ios.Presenters.Attributes;
using MvvmCross.Platforms.Ios.Views;
using MvvmCross.Plugin.Color.Platforms.Ios;
using StarWarsSample.Core;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.iOS.Views
{
    [MvxRootPresentation]
    public class MainView : MvxTabBarViewController<MainViewModel>
    {
        private bool _firstTimePresented = true;

        public MainView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            TabBar.BarTintColor = AppColors.PrimaryColor.ToNativeColor();
            TabBar.TintColor = AppColors.AccentColor.ToNativeColor();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (_firstTimePresented)
            {
                _firstTimePresented = false;
                ViewModel.ShowPlanetsViewModelCommand.Execute(null);
                ViewModel.ShowPeopleViewModelCommand.Execute(null);
                ViewModel.ShowMenuViewModelCommand.Execute(null);
            }
        }
    }
}
