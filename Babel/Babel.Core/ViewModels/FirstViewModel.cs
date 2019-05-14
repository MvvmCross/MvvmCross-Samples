using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.Plugin.JsonLocalization;
using System.Windows.Input;

namespace Babel.Core.ViewModels
{
    public class FirstViewModel : BaseViewModel
    {
        private readonly IMvxTextProviderBuilder _builder;
        private readonly IMvxNavigationService _navigationService;

        public FirstViewModel(IMvxTextProviderBuilder builder, IMvxNavigationService navigationService)
        {
            _builder = builder;
            _navigationService = navigationService;
        }

        public ICommand LolCatCommand
        {
            get { return new MvxCommand(() => PickLanguage("LolCat")); }
        }

        public ICommand ProperEnglishCommand
        {
            get { return new MvxCommand(() => PickLanguage("ProperEnglish")); }
        }

        public ICommand DefaultCommand
        {
            get { return new MvxCommand(() => PickLanguage(string.Empty)); }
        }

        private void PickLanguage(string which)
        {
            _builder.LoadResources(which);
        }

        public ICommand GoCommand
        {
            get { return new MvxCommand(() => _navigationService.Navigate<SecondViewModel>()); }
        }

        public ICommand ForceTextRefreshCommand
        {
            get { return new MvxCommand(() => RaisePropertyChanged(() => TextSource)); }
        }
    }
}
