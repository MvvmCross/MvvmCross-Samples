using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace StarWarsSample.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowPeopleViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<PeopleViewModel>());
            ShowPlanetsViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<PlanetsViewModel>());
            ShowMenuViewModelCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<MenuViewModel>());
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();
        }

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowPeopleViewModelCommand { get; set; }
        public IMvxCommand ShowPlanetsViewModelCommand { get; set; }
        public IMvxCommand ShowMenuViewModelCommand { get; set; }

        // Private methods
    }
}
