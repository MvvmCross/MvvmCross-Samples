using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	public partial class LoginViewController : BaseViewController<LoginViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public LoginViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public LoginViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public LoginViewController() : base("LoginView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<LoginViewController, LoginViewModel>();
			set.Bind(UsernameTextField).To(vm => vm.Username);
			set.Bind(PasswordSecureTextField).To(vm => vm.Password);
			set.Bind(LoginButton).To(vm => vm.LoginCommand);
			set.Apply();
		}

		//strongly typed view accessor
		public new LoginView View
		{
			get
			{
				return (LoginView)base.View;
			}
		}
	}
}
