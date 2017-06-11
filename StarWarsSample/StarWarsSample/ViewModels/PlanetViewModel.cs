using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Plugins.Messenger;
using StarWarsSample.Models;
using StarWarsSample.MvxMessages;

namespace StarWarsSample.ViewModels
{
    public class PlanetViewModel : MvxViewModel
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxMessenger _mvxMessenger;
        private readonly IUserDialogs _userDialogs;

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

        private bool _destroying;
        public bool Destroying
        {
            get
            {
                return _destroying;
            }
            set
            {
                _destroying = value;
                RaisePropertyChanged(() => Destroying);
            }
        }

        // MVVM Commands
        public IMvxCommand DestroyPlanetCommand { get; set; }

        // Private methods
        private async Task DestroyPlanet()
        {
            var result = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Destroy Planet",
                Message = "Sir, are you sure you want to destroy this planet",
                OkText = "YES",
                CancelText = "No"
            });

            if (!result)
                return;

            Destroying = true;

            await Task.Delay(5000);

            Destroying = false;

            _mvxMessenger.Publish(new PlanetDestroyedMessage(this, Planet));

            Close(this);
        }
    }
}
