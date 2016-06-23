using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace XPlatformMenus.Mac.Views
{
	public partial class SettingsViewController : BaseViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public SettingsViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public SettingsViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public SettingsViewController() : base("SettingsView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		//strongly typed view accessor
		public new SettingsView View
		{
			get
			{
				return (SettingsView)base.View;
			}
		}
	}
}
