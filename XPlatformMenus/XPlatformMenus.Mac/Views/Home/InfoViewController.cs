using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace XPlatformMenus.Mac.Views
{
	public partial class InfoViewController : BaseViewController
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
