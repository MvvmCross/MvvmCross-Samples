using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace StarWarsSample.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            ShowPlanetsCommand = new MvxCommand(() => ShowViewModel<PlanetsViewModel>());
            ShowPeopleCommand = new MvxCommand(() => ShowViewModel<PeopleViewModel>());
            ShowStatusCommand = new MvxCommand(() => ShowViewModel<StatusViewModel>());
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();
        }

        // MVVM Properties

        // MVVM Commands
        public ICommand ShowStatusCommand { get; set; }
        public ICommand ShowPlanetsCommand { get; set; }
        public ICommand ShowPeopleCommand { get; set; }

        // Private methods
    }
}
