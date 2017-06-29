using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.MvxInteraction;
using StarWarsSample.Core.ViewModelResults;

namespace StarWarsSample.Core.ViewModels
{
    public class PlanetViewModel : BaseViewModel<Planet, DestructionResult<Planet>>
    {
        private readonly IUserDialogs _userDialogs;

        public PlanetViewModel(
            IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;

            DestroyPlanetCommand = new MvxAsyncCommand(DestroyPlanet);
        }

        // MvvmCross Lifecycle
        public override Task Initialize(Planet parameter)
        {
            Planet = parameter;

            return Task.FromResult(0);
        }

        // MVVM Properties
        private Planet _planet;
        public Planet Planet
        {
            get
            {
                return _planet;
            }
            set
            {
                _planet = value;
                RaisePropertyChanged(() => Planet);
            }
        }

        public MvxInteraction<DestructionAction> Interaction { get; set; } = new MvxInteraction<DestructionAction>();

        // MVVM Commands
        public IMvxCommand DestroyPlanetCommand { get; private set; }

        // Private methods
        private async Task DestroyPlanet()
        {
            var destroy = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Destroy Planet",
                Message = "Sir, are you sure you want to destroy this planet?",
                OkText = "YES",
                CancelText = "No"
            });

            if (!destroy)
                return;

            var request = new DestructionAction
            {
                OnDestroyed = () => Close(new DestructionResult<Planet> { Entity = Planet, Destroyed = true })
            };

            Interaction.Raise(request);
        }
    }
}
