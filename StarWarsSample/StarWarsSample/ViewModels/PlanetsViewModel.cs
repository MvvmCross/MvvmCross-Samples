using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using Nito.AsyncEx;
using StarWarsSample.Models;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.ViewModels
{
    public class PlanetsViewModel : MvxViewModel
    {
        private readonly IPlanetsService _planetsService;
        private readonly IMvxJsonConverter _jsonConverter;

        private string _nextPage;

        public PlanetsViewModel(IPlanetsService planetsService, IMvxJsonConverter jsonConverter)
        {
            _planetsService = planetsService;
            _jsonConverter = jsonConverter;

            Planets = new MvxObservableCollection<Planet>();

            PlanetSelectedCommand = new MvxCommand<Planet>(PlanetSelected);
            FetchPlanetCommand = new MvxCommand(
                () =>
            {
                if (!string.IsNullOrEmpty(_nextPage))
                    NotifyTaskCompletion.Create(LoadPlanets);
            });
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();

            LoadPlanetsTask = NotifyTaskCompletion.Create(LoadPlanets);
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

        private void PlanetSelected(Planet selectedPlanet)
        {
            var serializedPlanet = _jsonConverter.SerializeObject(selectedPlanet);
            ShowViewModel<PersonViewModel>(new { serializedPlanet });
        }
    }
}
