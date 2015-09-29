using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace DialogExamples.Core.ViewModels
{
    public class LinearViewModel : FirstViewModel
    {
        public ICommand GoListViewCommand
        {
            get { return new MvxCommand(() => ShowViewModel<FirstViewModel>()); }
        }
    }
}