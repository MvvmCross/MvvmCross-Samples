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

            ShowInitialViewModelsCommand = new MvxCommand(ShowInitialViewModels);
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();
        }

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowInitialViewModelsCommand { get; set; }

        // Private methods
        private void ShowInitialViewModels()
        {
            ShowViewModel<PeopleViewModel>();
            ShowViewModel<PlanetsViewModel>();
            ShowViewModel<MenuViewModel>();
        }
    }
}
