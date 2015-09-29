using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using FragmentSample.Core.ViewModels.Dialog;
using FragmentSample.Core.ViewModels.Form;
using FragmentSample.Core.ViewModels.Shakespeare;
using FragmentSample.Core.ViewModels.Tab;

namespace FragmentSample.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private NamesViewModel _names = new NamesViewModel();

        public NamesViewModel Names
        {
            get { return _names; }
            set
            {
                _names = value;
                RaisePropertyChanged(() => Names);
            }
        }

        public ICommand ShowFormCommand
        {
            get { return new MvxCommand(() => ShowViewModel<SearchViewModel>()); }
        }

        public ICommand ShowTabsCommand
        {
            get { return new MvxCommand(() => ShowViewModel<TabViewModel>()); }
        }

        public ICommand ShowShakespeareCommand
        {
            get { return new MvxCommand(() => ShowViewModel<TitlesViewModel>());}
        }
    }
}