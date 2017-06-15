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
    public class PersonViewModel : BaseViewModel
    {
        private readonly IMvxJsonConverter _jsonConverter;
        private readonly IMvxMessenger _mvxMessenger;
        private readonly IUserDialogs _userDialogs;

        private MvxInteraction<DestructionAction> _interaction = new MvxInteraction<DestructionAction>();

        public PersonViewModel(
            IMvxJsonConverter jsonConverter,
            IMvxMessenger mvxMessenger,
            IUserDialogs userDialogs)
        {
            _jsonConverter = jsonConverter;
            _mvxMessenger = mvxMessenger;
            _userDialogs = userDialogs;

            DestroyPersonCommand = new MvxAsyncCommand(DestroyPerson);
        }

        // MvvmCross Lifecycle
        public void Init(string serializedPerson)
        {
            Person = _jsonConverter.DeserializeObject<Person>(serializedPerson);
        }

        public override void Start()
        {
            base.Start();
        }

        // MVVM Properties
        private Person _person;
        public Person Person
        {
            get
            {
                return _person;
            }
            set
            {
                _person = value;
                RaisePropertyChanged(() => Person);
            }
        }

        public IMvxInteraction<DestructionAction> Interaction => _interaction;

        // MVVM Commands
        public IMvxCommand DestroyPersonCommand { get; set; }

        // Private methods
        private async Task DestroyPerson()
        {
            var result = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Destroy Person",
                Message = "Sir, are you sure you want to destroy this person?",
                OkText = "YES",
                CancelText = "No"
            });

            if (!result)
                return;

            var request = new DestructionAction
            {
                OnDestroyed = () =>
                {
                    _mvxMessenger.Publish(new PersonDestroyedMessage(this, Person));

                    Close(this);
                }
            };

            _interaction.Raise(request);
        }
    }
}
