﻿using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace StarWarsSample.Core.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public MenuViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            ShowPlanetsCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<PlanetsViewModel>());
            ShowPeopleCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<PeopleViewModel>());
            ShowStatusCommand = new MvxAsyncCommand(async () => await _navigationService.Navigate<StatusViewModel>());
        }

        // MvvmCross Lifecycle

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowStatusCommand { get; set; }
        public IMvxCommand ShowPlanetsCommand { get; set; }
        public IMvxCommand ShowPeopleCommand { get; set; }

        // Private methods
    }
}
