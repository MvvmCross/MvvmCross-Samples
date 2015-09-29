using Cirrious.MvvmCross.ViewModels;

namespace QuickLayout.Core.ViewModels
{
    public abstract class BaseDetailsViewModel 
        : MvxViewModel
    {
        private string firstName = "Mvvm";
        public string FirstName
        { 
            get { return firstName; }
            set { firstName = value; RaisePropertyChanged(() => FirstName); }
        }

        private string _lastName = "Cross";
        public string LastName 
        {   
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(() => LastName); }
        }

        private string _number = "12";
        public string Number 
        {   
            get { return _number; }
            set { _number = value; RaisePropertyChanged(() => Number); }
        }

        private string _street = "Strathmore";
        public string Street 
        {   
            get { return _street; }
            set { _street = value; RaisePropertyChanged(() => Street); }
        }

        private string _town = "Teddington";
        public string Town 
        {   
            get { return _town; }
            set { _town = value; RaisePropertyChanged(() => Town); }
        }

        private string _zip = "TW12 2SA";
        public string Zip 
        {   
            get { return _zip; }
            set { _zip = value; RaisePropertyChanged(() => Zip); }
        }
    }
}