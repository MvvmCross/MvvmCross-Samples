using Cirrious.MvvmCross.ViewModels;

namespace CustomBinding.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private string _first = "Hello";
        public string First
		{ 
			get { return _first; }
			set { _first = value; RaisePropertyChanged(() => First); }
		}

        private string _second = "World";
        public string Second
        {
            get { return _second; }
            set { _second = value; RaisePropertyChanged(() => Second); }
        }
    }
}
