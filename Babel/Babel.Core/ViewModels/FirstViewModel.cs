using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.JsonLocalization;

namespace Babel.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        private readonly IMvxTextProviderBuilder _builder;
        private readonly IMvxNavigationService _navigationService;
        private string _hello;

        public FirstViewModel(IMvxTextProviderBuilder builder, IMvxNavigationService navigationService)
        {
            _builder = builder;
            _navigationService = navigationService;
        }

        public IMvxCommand LolCatCommand => new MvxCommand(() => PickLanguage("LolCat"));

        public IMvxCommand ProperEnglishCommand => new MvxCommand(() => PickLanguage("ProperEnglish"));

        public IMvxCommand DefaultCommand => new MvxCommand(() => PickLanguage(string.Empty));

        private void PickLanguage(string which)
        {
            _builder.LoadResources(which);
        }

        public IMvxCommand GoCommand => new MvxCommand(() => _navigationService.Navigate<SecondViewModel>());

        public IMvxCommand ForceTextRefreshCommand => new MvxCommand(() => RaisePropertyChanged(() => TextSource));

        public string Hello
        {
            get => _hello;
            set => SetProperty(ref _hello, value);
        }
    }
}
