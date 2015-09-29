using Cirrious.MvvmCross.ViewModels;
using QuickLayout.Core.Services;

namespace QuickLayout.Core.ViewModels
{
    public class TipViewModel : MvxViewModel
    {
        private readonly ICalculationService _calculation;
        private int _generosity;

        private double _subTotal;
        private double _tip;

        public TipViewModel(ICalculationService calculation)
        {
            _calculation = calculation;
        }

        public double SubTotal
        {
            get { return _subTotal; }
            set
            {
                _subTotal = value;
                RaisePropertyChanged(() => SubTotal);
                Recalcuate();
            }
        }

        public void Zero()
        {
            Generosity = 0;
        }
        public void Full()
        {
            Generosity = 100;
        }

        public int Generosity
        {
            get { return _generosity; }
            set
            {
                _generosity = Limit(value);
                Cirrious.CrossCore.Core.MvxAsyncDispatcher.BeginAsync(() => RaisePropertyChanged(() => Generosity));
                Recalcuate();
            }
        }

        public double Tip
        {
            get { return _tip; }
            set
            {
                _tip = value;
                RaisePropertyChanged(() => Tip);
            }
        }

        public override void Start()
        {
            _subTotal = 100;
            _generosity = 10;
            Recalcuate();
            base.Start();
        }

        private int Limit(int value)
        {
            if (value < 0)
                value = 0;
            if (value > 100)
                value = 100;
            return value;
        }

        private void Recalcuate()
        {
            Tip = _calculation.TipAmount(SubTotal, Generosity);
        }
    }
}