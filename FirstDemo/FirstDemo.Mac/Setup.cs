using Foundation;
using AppKit;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Core.ViewModels;

namespace FirstDemo.Mac
{
	public class Setup : MvxMacSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, IMvxMacViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{

		}

		protected override IMvxApplication CreateApp ()
		{
			return new FirstDemo.Core.App ();
		}
	}
}

