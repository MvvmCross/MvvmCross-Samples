using System;
using Foundation;
using MvvmCross.Binding.Mac.Views;

namespace XPlatformMenus.Mac.Views
{
	public class BaseView : MvxView
	{
		#region Constructors

		// Called when created from unmanaged code
		public BaseView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		public BaseView(NSCoder coder) : base(coder)
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

