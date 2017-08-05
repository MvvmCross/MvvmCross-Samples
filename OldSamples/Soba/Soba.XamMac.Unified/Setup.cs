using AppKit;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Core.ViewModels;
using Foundation;

namespace Soba.XamMac.Unified
{
	public class Setup : MvxMacSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, IMvxMacViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Soba.Core.App ();
		}
	}
}