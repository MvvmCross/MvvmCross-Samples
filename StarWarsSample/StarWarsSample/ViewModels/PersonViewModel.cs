using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using StarWarsSample.Models;
using StarWarsSample.MvxInteraction;
using StarWarsSample.MvxResults;

namespace StarWarsSample.ViewModels
{
    public class PersonViewModel : BaseViewModel<Person, MvxDestructionResult<Person>>
    {
        private readonly IUserDialogs _userDialogs;

        private MvxInteraction<DestructionAction> _interaction = new MvxInteraction<DestructionAction>();

        public PersonViewModel(
            IUserDialogs userDialogs)
        {
            _userDialogs = userDialogs;

            DestroyPersonCommand = new MvxAsyncCommand(DestroyPerson);
        }

        // MvvmCross Lifecycle
        public override Task Initialize(Person parameter)
        {
            Person = parameter;

            return Task.FromResult(0);
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
                OnDestroyed = () => Close(new MvxDestructionResult<Person> { Entity = Person, Destroyed = true })
            };

            _interaction.Raise(request);
        }
    }
}
