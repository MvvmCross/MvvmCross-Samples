using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace XPlatformMenus.Core.ViewModels
{
    public class ThirdViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public ThirdViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public IMvxAsyncCommand SaveAndCloseCommand => new MvxAsyncCommand(async () =>
        {
            await _navigationService.Navigate<HomeViewModel>();
        });
        
    }
}