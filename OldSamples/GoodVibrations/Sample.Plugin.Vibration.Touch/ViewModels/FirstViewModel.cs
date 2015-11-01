using Cirrious.MvvmCross.ViewModels;

namespace Sample.Plugin.Vibration.Touch.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        private string _hello = "Hello MvvmCross";

        public string Hello
        {
            get { return _hello; }
            set { _hello = value; RaisePropertyChanged(() => Hello); }
        }
    }
}