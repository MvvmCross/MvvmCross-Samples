using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	[MvxRegion("PageContent")]
	public partial class HelpViewController : BaseViewController<HelpAndFeedbackViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public HelpViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public HelpViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public HelpViewController() : base("HelpView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		//strongly typed view accessor
		public new HelpView View
		{
			get
			{
				return (HelpView)base.View;
			}
		}
	}
}
