using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace Collections.Core.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        protected readonly IMvxNavigationService NavigationService;

        public BaseViewModel()
        {
            NavigationService = Mvx.Resolve<IMvxNavigationService>();
        }
    }
}
