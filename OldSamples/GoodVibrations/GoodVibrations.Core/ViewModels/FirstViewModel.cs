using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Sample.Plugin.Vibration;

namespace GoodVibrations.Core.ViewModels
{
    public class FirstViewModel 
		: MvxViewModel
    {
        private readonly IVibrate _vibrate;

        public FirstViewModel(IVibrate vibrate)
        {
            _vibrate = vibrate;
        }

		private string _hello = "Hello MvvmCross";
        public string Hello
		{ 
			get { return _hello; }
			set { _hello = value; RaisePropertyChanged(() => Hello); }
		}

        public ICommand ShakeCommand
        {
            get
            {
                return new MvxCommand(() => _vibrate.Shake());
            }
        }
    }
}
