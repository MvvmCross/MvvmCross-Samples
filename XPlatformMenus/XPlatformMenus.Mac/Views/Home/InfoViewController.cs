using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	[MvxRegion("PageContent")]
	public partial class InfoViewController : BaseViewController<InfoViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public InfoViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public InfoViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public InfoViewController() : base("InfoView", NSBundle.MainBundle)
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

			var set = this.CreateBindingSet<InfoViewController, InfoViewModel>();
			set.Bind(ShowThirdButton).To(vm => vm.ShowThirdViewModelCommand);
			set.Apply();
		}

		//strongly typed view accessor
		public new InfoView View
		{
			get
			{
				return (InfoView)base.View;
			}
		}
	}
}
