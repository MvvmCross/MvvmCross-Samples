using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Core
{
    public class AppStart : MvxAppStart
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public AppStart(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        protected override void Startup(object hint = null)
        {
            _mvxNavigationService.Navigate<MainViewModel>();
        }
    }
}
