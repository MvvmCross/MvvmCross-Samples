using FragmentSample.Core.Services.Calcs;

namespace FragmentSample.Core.ViewModels.Tab
{
    public class SecondTabViewModel : BaseSubTabViewModel
    {
        private readonly ICalculationService _calculationService;
        private int _generosity;

        private double _subTotal;
        private double _tip;

        public SecondTabViewModel(ICalculationService calculationService)
        {
            _calculationService = calculationService;
            _subTotal = 100;
            _generosity = 10;
            Recalcuate();
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

        public int Generosity
        {
            get { return _generosity; }
            set
            {
                _generosity = Limit(value);
                RaisePropertyChanged(() => Generosity);
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
            Tip = _calculationService.TipAmount(SubTotal, Generosity);
        }
    }
}