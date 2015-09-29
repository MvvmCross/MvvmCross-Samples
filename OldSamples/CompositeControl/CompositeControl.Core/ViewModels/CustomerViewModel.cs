using Cirrious.MvvmCross.ViewModels;

namespace CompositeControl.Core.ViewModels
{
    public class CustomerViewModel
        : MvxViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(() => FirstName); RaisePropertyChanged(() => FullName); }
        }

        private string _secondName;
        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; RaisePropertyChanged(() => SecondName); RaisePropertyChanged(() => FullName); }
        }        

        public string FullName
        {
            get { return FirstName + " " + SecondName; }
        }
    }
}