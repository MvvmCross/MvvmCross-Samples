using Cirrious.MvvmCross.ViewModels;

namespace CompositeControl.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
		private CustomerViewModel _customer1 = new CustomerViewModel()
		    {
		        FirstName = "Fred",
                SecondName = "Flintstone"
		    };
        public CustomerViewModel Customer1
		{ 
			get { return _customer1; }
			set { _customer1 = value; RaisePropertyChanged(() => Customer1); }
		}

        private CustomerViewModel _customer2 = new CustomerViewModel()
        {
            FirstName = "Barney",
            SecondName = "Rubble"
        };
        public CustomerViewModel Customer2
        {
            get { return _customer2; }
            set { _customer2 = value; RaisePropertyChanged(() => Customer2); }
        }
    }
}
