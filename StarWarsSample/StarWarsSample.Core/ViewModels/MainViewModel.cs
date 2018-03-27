using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace StarWarsSample.Core.ViewModels
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

        // MVVM Properties

        // MVVM Commands
        public IMvxAsyncCommand ShowPeopleViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowPlanetsViewModelCommand { get; private set; }
        public IMvxAsyncCommand ShowMenuViewModelCommand { get; private set; }

        // Private methods
    }
}
