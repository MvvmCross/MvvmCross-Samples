using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using Nito.AsyncEx;
using StarWarsSample.Models;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.ViewModels
{
    public class PlanetsViewModel : MvxViewModel
    {
        private readonly IPlanetsService _planetsService;

        public PlanetsViewModel(IPlanetsService planetsService)
        {
            _planetsService = planetsService;
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();

            LoadPlanetsTask = NotifyTaskCompletion.Create(LoadPlanets);
        }

        // MVVM Properties
        public INotifyTaskCompletion LoadPlanetsTask { get; set; }

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

        // Private methods
        private async Task LoadPlanets()
        {
            var result = await _planetsService.GetPlanetsAsync();

            Planets = new MvxObservableCollection<Planet>(result.Results);
        }
    }
}
