using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.ViewModelResults;
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
                {
                    FetchPlanetsTask = MvxNotifyTask.Create(LoadPlanets);
                    RaisePropertyChanged(() => FetchPlanetsTask);
                }
            });
            RefreshPlanetsCommand = new MvxCommand(RefreshPlanets);
        }

        // MvvmCross Lifecycle
        public override Task Initialize()
        {
            LoadPlanetsTask = MvxNotifyTask.Create(LoadPlanets);

            return Task.FromResult(0);
        }

        // MVVM Properties
        public MvxNotifyTask LoadPlanetsTask { get; private set; }

        public MvxNotifyTask FetchPlanetsTask { get; private set; }

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
        public IMvxCommand<Planet> PlanetSelectedCommand { get; private set; }

        public IMvxCommand FetchPlanetCommand { get; private set; }

        public IMvxCommand RefreshPlanetsCommand { get; private set; }

        // Private methods
        private async Task LoadPlanets()
        {
            var result = await _planetsService.GetPlanetsAsync(_nextPage);

            if (string.IsNullOrEmpty(_nextPage))
            {
                Planets.Clear();
            }
            Planets.AddRange(result.Results);

            _nextPage = result.Next;
        }

        private async Task PlanetSelected(Planet selectedPlanet)
        {
            var result = await _navigationService.Navigate<PlanetViewModel, Planet, DestructionResult<Planet>>(selectedPlanet);

            if (result != null && result.Destroyed)
            {
                var planet = Planets.FirstOrDefault(p => p.Name == result.Entity.Name);
                if (planet != null)
                    Planets.Remove(planet);
            }
        }

        private void RefreshPlanets()
        {
            _nextPage = null;

            LoadPlanetsTask = MvxNotifyTask.Create(LoadPlanets);
            RaisePropertyChanged(() => LoadPlanetsTask);
        }
    }
}
