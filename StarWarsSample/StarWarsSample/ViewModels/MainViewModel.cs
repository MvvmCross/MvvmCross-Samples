using MvvmCross.Core.ViewModels;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IPeopleService _peopleService;

        public MainViewModel(IPeopleService peopleService)
        {
            _peopleService = peopleService;

            ShowPeopleViewModelCommand = new MvxCommand(() => ShowViewModel<PeopleViewModel>());
            ShowPlanetsViewModelCommand = new MvxCommand(() => ShowViewModel<PlanetsViewModel>());
            ShowMenuViewModelCommand = new MvxCommand(() => ShowViewModel<MenuViewModel>());
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
