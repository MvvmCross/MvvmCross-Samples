using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

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
