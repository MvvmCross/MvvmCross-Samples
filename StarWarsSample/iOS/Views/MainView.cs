using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using MvvmCross.Plugins.Color.iOS;
using StarWarsSample.ViewModels;

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

            TabBar.TintColor = AppColors.AccentColor.ToNativeColor();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (_firstTimePresented)
            {
                _firstTimePresented = false;
                ViewModel.ShowPeopleViewModelCommand.Execute(null);
                ViewModel.ShowPlanetsViewModelCommand.Execute(null);
                ViewModel.ShowMenuViewModelCommand.Execute(null);
            }
        }
    }
}
