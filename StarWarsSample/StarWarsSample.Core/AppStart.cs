using System;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Core
{
    public class AppStart : MvxNavigatingObject, IMvxAppStart
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public AppStart(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public void Start(object hint = null)
        {
            _mvxNavigationService.Navigate<MainViewModel>();
        }
    }
}
