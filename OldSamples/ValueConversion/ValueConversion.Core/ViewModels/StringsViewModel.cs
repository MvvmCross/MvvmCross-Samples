using Cirrious.MvvmCross.ViewModels;

namespace ValueConversion.Core.ViewModels
{
    public class StringsViewModel : MvxViewModel
    {
        private string _theText;

        public StringsViewModel()
        {
            TheText = "Hello World";
        }

        public string TheText
        {
            get { return _theText; }
            set
            {
                _theText = value;
                RaisePropertyChanged(() => TheText);
            }
        }
    }
}