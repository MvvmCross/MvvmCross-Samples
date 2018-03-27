using System.Linq;
using System.Threading.Tasks;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.ViewModelResults;
using StarWarsSample.Core.Services.Interfaces;
using System.Collections.Generic;
using StarWarsSample.Core.Extensions;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvvmCross.Commands;

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

            Planets = new MvxObservableCollection<IPlanet>();

            PlanetSelectedCommand = new MvxAsyncCommand<IPlanet>(PlanetSelected);
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

        private MvxObservableCollection<IPlanet> _planets;
        public MvxObservableCollection<IPlanet> Planets
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
        public IMvxCommand<IPlanet> PlanetSelectedCommand { get; private set; }

        public IMvxCommand FetchPlanetCommand { get; private set; }

        public IMvxCommand RefreshPlanetsCommand { get; private set; }

        // Private methods
        private async Task LoadPlanets()
        {
            var result = await _planetsService.GetPlanetsAsync(_nextPage);

            List<IPlanet> planetsToAdd = new List<IPlanet>();
            for (int i = 0; i < result.Results.Count(); i++)
            {
                if (i % 2 == 0)
                {
                    planetsToAdd.Add(result.Results.ElementAt(i).ToPlanet());
                }
                else
                {
                    planetsToAdd.Add(result.Results.ElementAt(i).ToPlanet2());
                }
            }

            if (string.IsNullOrEmpty(_nextPage))
            {
                Planets.Clear();
            }
            Planets.AddRange(planetsToAdd);

            _nextPage = result.Next;
        }

        private async Task PlanetSelected(IPlanet selectedPlanet)
        {
            var result = await _navigationService.Navigate<PlanetViewModel, IPlanet, DestructionResult<IPlanet>>(selectedPlanet);

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
