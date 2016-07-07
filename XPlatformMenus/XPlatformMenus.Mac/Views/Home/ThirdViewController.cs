using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	[MvxRegion("PageContent")]
	public partial class ThirdViewController : BaseViewController<ThirdViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public ThirdViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public ThirdViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public ThirdViewController() : base("ThirdView", NSBundle.MainBundle)
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

			var set = this.CreateBindingSet<ThirdViewController, ThirdViewModel>();
			set.Bind(SaveAndCloseButton).To(vm => vm.SaveAndCloseCommand);
			set.Apply();
		}

		//strongly typed view accessor
		public new ThirdView View
		{
			get
			{
				return (ThirdView)base.View;
			}
		}
	}
}
