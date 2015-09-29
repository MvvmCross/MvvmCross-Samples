using Cirrious.MvvmCross.ViewModels;

namespace ValueConversion.Core.ViewModels
{
    public class VisibilityViewModel : MvxViewModel
    {
        private bool _makeItVisible;

        public VisibilityViewModel()
        {
            _makeItVisible = true;
        }

        public bool MakeItVisible
        {
            get { return _makeItVisible; }
            set
            {
                _makeItVisible = value;
                RaisePropertyChanged(() => MakeItVisible);
            }
        }
    }
}