using System;
using MvvmCross.Core.ViewModels;

namespace StarWarsSample.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            ShowStatusCommand = new MvxCommand(() => ShowViewModel<StatusViewModel>());
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();
        }

        // MVVM Properties

        // MVVM Commands
        public IMvxCommand ShowStatusCommand { get; set; }

        // Private methods
    }
}
