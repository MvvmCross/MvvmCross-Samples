﻿using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Core.ViewModels;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.MvxInteraction;
using StarWarsSample.Core.ViewModelResults;

namespace StarWarsSample.Core.ViewModels
{
    public class PersonViewModel : BaseViewModel<Person, DestructionResult<Person>>
    {
        private readonly IUserDialogs _userDialogs;

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

        public MvxInteraction<DestructionAction> Interaction { get; set; } = new MvxInteraction<DestructionAction>();

        // MVVM Commands
        public IMvxCommand DestroyPersonCommand { get; private set; }

        // Private methods

        private async Task DestroyPerson()
        {
            var destroy = await _userDialogs.ConfirmAsync(new ConfirmConfig
            {
                Title = "Destroy Person",
                Message = "Sir, are you sure you want to destroy this person?",
                OkText = "YES",
                CancelText = "No"
            });

            if (!destroy)
                return;

            var request = new DestructionAction
            {
                OnDestroyed = () => Close(
                    new DestructionResult<Person>
                    {
                        Entity = Person,
                        Destroyed = true
                    })
            };

            Interaction.Raise(request);
        }
    }
}
