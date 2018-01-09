using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.UWP.Views
{
	public sealed partial class LoginView
	{
		public new LoginViewModel ViewModel
		{
			get { return (LoginViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public LoginView()
		{
			InitializeComponent();
		}
	}
	
}
