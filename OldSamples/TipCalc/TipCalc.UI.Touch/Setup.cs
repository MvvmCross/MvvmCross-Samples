using Cirrious.MvvmCross.Touch.Platform;
using TipCalc.Core;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;

namespace TipCalc.UI.Touch
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate appDelegate, IMvxTouchViewPresenter presenter)
            : base(appDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}