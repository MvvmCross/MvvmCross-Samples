using System.Windows.Input;
using Cirrious.MvvmCross.Plugins.JsonLocalisation;
using Cirrious.MvvmCross.ViewModels;

namespace Babel.Core.ViewModels
{
    public class FirstViewModel
        : BaseViewModel
    {
        private readonly IMvxTextProviderBuilder _builder;

        public FirstViewModel(IMvxTextProviderBuilder builder)
        {
            _builder = builder;
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
            get { return new MvxCommand(() => ShowViewModel<SecondViewModel>());}
        }

        public ICommand ForceTextRefreshCommand
        {
            get { return new MvxCommand(() => RaisePropertyChanged(() => TextSource));}
        }
        
    }
}
