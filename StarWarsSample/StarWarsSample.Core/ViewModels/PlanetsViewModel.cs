using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using Nito.AsyncEx;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.MvxResults;
using StarWarsSample.Core.Services.Interfaces;

namespace StarWarsSample.Core.ViewModels
{
    public class PlanetsViewModel : BaseViewModel
    {
        private readonly IPlanetsService _planetsService;
        private readonly IMvxNavigationService _navigationService;

        private string _nextPage;

        public PlanetsViewModel(
            IPlanetsService planetsService,
            IMvxNavigationService navigationService)
        {
            _planetsService = planetsService;
            _navigationService = navigationService;

            Planets = new MvxObservableCollection<Planet>();

            PlanetSelectedCommand = new MvxAsyncCommand<Planet>(PlanetSelected);
            FetchPlanetCommand = new MvxCommand(
                () =>
            {
                if (!string.IsNullOrEmpty(_nextPage))
                    NotifyTaskCompletion.Create(LoadPlanets);
            });
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadPlanetsTask = NotifyTaskCompletion.Create(LoadPlanets);

            return Task.FromResult(0);
        }

        // MVVM Properties
        public INotifyTaskCompletion LoadPlanetsTask { get; set; }

        public INotifyTaskCompletion FetchPlanetsTask { get; set; }

        private MvxObservableCollection<Planet> _planets;
        public MvxObservableCollection<Planet> Planets
        {
            get
            {
                return _planets;
            }
            set
            {
                _planets = value;
                RaisePropertyChanged(() => Planets);
            }
        }

        // MVVM Commands
        public IMvxCommand PlanetSelectedCommand { get; set; }

        public IMvxCommand FetchPlanetCommand { get; set; }

        // Private methods
        private async Task LoadPlanets()
        {
            var result = await _planetsService.GetPlanetsAsync(_nextPage);

            _nextPage = result.Next;

            Planets.AddRange(result.Results);
        }

        private async Task PlanetSelected(Planet selectedPlanet)
        {
            var result = await _navigationService.Navigate<PlanetViewModel, Planet, MvxDestructionResult<Planet>>(selectedPlanet);

            if (result != null && result.Destroyed)
            {
                var planet = Planets.FirstOrDefault(p => p.Name == result.Entity.Name);
                if (planet != null)
                    Planets.Remove(planet);
            }
        }
    }
}
