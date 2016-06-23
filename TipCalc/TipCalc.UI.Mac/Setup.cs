using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Core.ViewModels;
using TipCalc.Core;

namespace TipCalc.UI.Mac
{
	public class Setup : MvxMacSetup
	{
		public Setup(MvxApplicationDelegate appDelegate, IMvxMacViewPresenter presenter)
			: base(appDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}
	}
}

