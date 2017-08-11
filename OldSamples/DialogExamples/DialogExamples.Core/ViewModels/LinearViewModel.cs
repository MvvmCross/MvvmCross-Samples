using System.Windows.Input;
using MvvmCross.Core.ViewModels;

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