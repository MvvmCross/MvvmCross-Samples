using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.AutoView.Touch;
using Cirrious.MvvmCross.Dialog.Touch;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace AutoViewExamples.Touch
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

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();
            SetupAutoViews();
        }

        private void SetupAutoViews()
        {
            var autoView = new MvxAutoViewSetup();
            autoView.Initialize();
        }
    }
}