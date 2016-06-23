using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using MvvmCross.Mac.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	public class BaseViewController : MvxViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public BaseViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		public BaseViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public BaseViewController(string viewName, NSBundle bundle) : base(viewName, bundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion
	}
}

