using Cirrious.MvvmCross.ViewModels;

namespace ValueConversion.Core.ViewModels
{
    public class TwoWayViewModel : MvxViewModel
    {
        private double _theValue;

        public TwoWayViewModel()
        {
            _theValue = 3;
        }

        public double TheValue
        {
            get { return _theValue; }
            set
            {
                _theValue = value;
                RaisePropertyChanged(() => TheValue);
            }
        }
    }
}