using Cirrious.MvvmCross.Dialog.Touch;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace DialogExamples.Touch
{
    public class Setup : MvxTouchDialogSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}