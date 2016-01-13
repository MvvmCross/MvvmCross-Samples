using XPlatformMenus.Core.Interfaces;
using MvvmCross.Core.ViewModels;

namespace XPlatformMenus.Core.ViewModels
{
	public class LoginViewModel : BaseViewModel
    {
        private readonly ILoginService _loginService;

        private readonly IDialogService _dialogService;

        public LoginViewModel(ILoginService loginService, IDialogService dialogService)
        {
            _loginService = loginService;
            _dialogService = dialogService;

            Username = "TestUser";
            Password = "YouCantSeeMe";
            IsLoading = false;
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                SetProperty (ref _username, value);
                RaisePropertyChanged(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                SetProperty (ref _password, value);
                RaisePropertyChanged(() => Password);
            }
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }

            set
            {
                SetProperty(ref _isLoading, value);
            }
        }

        private IMvxCommand _loginCommand;
        public virtual IMvxCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new MvxCommand(AttemptLogin, CanExecuteLogin);
                return _loginCommand;
            }
        }

        private void AttemptLogin()
        {
            if (_loginService.Login(Username, Password))
            {
                ShowViewModel<MainViewModel>();
            }
            else
            {
                _dialogService.Alert("We were unable to log you in!", "Login Failed", "OK");
            }
        }

        private bool CanExecuteLogin()
        {
            return (!string.IsNullOrEmpty(Username) || !string.IsNullOrWhiteSpace(Username))
                   && (!string.IsNullOrEmpty(Password) || !string.IsNullOrWhiteSpace(Password));
        }
    }
}