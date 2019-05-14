using MvvmCross.Commands;
using MvvmCross.Navigation;

namespace Babel.Core.ViewModels
{
    public class SecondViewModel : BaseViewModel
    {
        public SecondViewModel(IMvxNavigationService navigationService)
        {
            GoBackCommand = new MvxCommand(() => navigationService.Navigate<FirstViewModel>());
        }

        public IMvxCommand GoBackCommand { get; }
    }
}
