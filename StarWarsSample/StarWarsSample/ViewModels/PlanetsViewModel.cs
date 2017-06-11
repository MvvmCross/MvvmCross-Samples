using System;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Messenger;
using Nito.AsyncEx;
using StarWarsSample.Models;
using StarWarsSample.MvxMessages;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.ViewModels
{
    public class PlanetsViewModel : BaseViewModel
    {
        private readonly IPlanetsService _planetsService;
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxMessenger _mvxMessenger;

        private MvxSubscriptionToken _planetDestroyedToken;
        private string _nextPage;

        public PlanetsViewModel(
            IPlanetsService planetsService,
            IMvxJsonConverter jsonConverter,
            IMvxMessenger mvxMessenger)
        {
            _planetsService = planetsService;
            _jsonConverter = jsonConverter;
            _mvxMessenger = mvxMessenger;

            Planets = new MvxObservableCollection<Planet>();

            _planetDestroyedToken = _mvxMessenger.SubscribeOnMainThread<PlanetDestroyedMessage>(
                message =>
                {
                    var planet = Planets.FirstOrDefault(p => p.Name == message.Planet.Name);
                    if (planet != null)
                        Planets.Remove(planet);
                }
            );

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
            ShowViewModel<PlanetViewModel>(new { serializedPlanet });
        }
    }
}
