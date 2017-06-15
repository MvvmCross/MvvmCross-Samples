using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using StarWarsSample.Models;
using StarWarsSample.MvxInteraction;
using StarWarsSample.MvxResults;

namespace StarWarsSample.ViewModels
{
    public class PlanetViewModel : BaseViewModel<Planet, MvxDestructionResult<Planet>>
    {
        private readonly IUserDialogs _userDialogs;

        private MvxInteraction<DestructionAction> _interaction = new MvxInteraction<DestructionAction>();

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

        public IMvxInteraction<DestructionAction> Interaction => _interaction;

        // MVVM Commands
        public IMvxCommand DestroyPlanetCommand { get; set; }

        // Private methods
        private async Task DestroyPlanet()
        {
            var result = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Destroy Planet",
                Message = "Sir, are you sure you want to destroy this planet?",
                OkText = "YES",
                CancelText = "No"
            });

            if (!result)
                return;

            var request = new DestructionAction
            {
                OnDestroyed = () => Close(new MvxDestructionResult<Planet> { Entity = Planet, Destroyed = true })
            };

            _interaction.Raise(request);
        }
    }
}
