using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	[MvxRegion("PageContent")]
	public partial class HomeViewController : BaseViewController<HomeViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public HomeViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public HomeViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public HomeViewController() : base("HomeView", NSBundle.MainBundle)
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

			var set = this.CreateBindingSet<HomeViewController, HomeViewModel>();
			set.Bind(ShowInfoButton).To(vm => vm.GoToInfoCommand);
			set.Apply();
		}

		//strongly typed view accessor
		public new HomeView View
		{
			get
			{
				return (HomeView)base.View;
			}
		}
	}
}
