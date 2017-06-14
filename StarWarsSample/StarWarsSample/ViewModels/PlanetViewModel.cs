using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Messenger;
using StarWarsSample.Models;
using StarWarsSample.MvxInteraction;
using StarWarsSample.MvxMessages;

namespace StarWarsSample.ViewModels
{
    public class PlanetViewModel : BaseViewModel
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxMessenger _mvxMessenger;
        private readonly IUserDialogs _userDialogs;

        private MvxInteraction<DestructionAction> _interaction = new MvxInteraction<DestructionAction>();


        public PlanetViewModel(
            IMvxJsonConverter jsonConverter,
            IMvxMessenger mvxMessenger,
            IUserDialogs userDialogs)
        {
            _jsonConverter = jsonConverter;
            _mvxMessenger = mvxMessenger;
            _userDialogs = userDialogs;

            DestroyPlanetCommand = new MvxAsyncCommand(DestroyPlanet);
        }

        // MvvmCross Lifecycle
        public void Init(string serializedPlanet)
        {
            Planet = _jsonConverter.DeserializeObject<Planet>(serializedPlanet);
        }

        public override void Start()
        {
            base.Start();
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
                OnDestroyed = () =>
                {
                    _mvxMessenger.Publish(new PlanetDestroyedMessage(this, Planet));

                    Close(this);
                }
            };

            _interaction.Raise(request);
        }
    }
}
