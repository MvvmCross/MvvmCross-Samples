using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Core
{
    public class AppStart : IMvxAppStart
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        private bool _started;

        public AppStart(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public bool IsStarted => _started;

        public void Start(object hint = null)
        {
            if(!_started)
            {
                _started = true;
                _mvxNavigationService.Navigate<MainViewModel>();
            }
        }
    }
}
