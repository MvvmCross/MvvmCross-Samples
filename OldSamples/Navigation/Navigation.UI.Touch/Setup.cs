using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;

namespace Navigation.UI.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{		
		}

		protected override IMvxApplication CreateApp ()
		{
			return new Core.App();
		}
	}
}