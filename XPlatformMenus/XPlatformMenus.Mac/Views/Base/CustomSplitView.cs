using System;
using AppKit;
using Foundation;

namespace XPlatformMenus.Mac.Views
{
	[Register("CustomSplitView")]
	public class CustomSplitView : NSSplitView
	{
		#region Constructors

		// Called when created from unmanaged code
		public CustomSplitView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		public CustomSplitView(NSCoder coder) : base(coder)
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

