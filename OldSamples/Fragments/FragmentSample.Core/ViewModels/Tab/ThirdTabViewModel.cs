namespace FragmentSample.Core.ViewModels.Tab
{
    public class ThirdTabViewModel : BaseSubTabViewModel
    {
        private string _firstName;
        private string _lastName;

        public ThirdTabViewModel()
        {
            _firstName = "Hello";
            _lastName = "MvvmCross";
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                RaisePropertyChanged(() => FirstName);
                RaisePropertyChanged(() => FullName);
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                RaisePropertyChanged(() => LastName);
                RaisePropertyChanged(() => FullName);
            }
        }

        public string FullName
        {
            get { return string.Format(@"{0} {1}", _firstName, _lastName); }
        }
    }
}