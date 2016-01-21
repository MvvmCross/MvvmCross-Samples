using MvvmCross.AutoView.iOS;
using MvvmCross.Dialog.iOS;
using MvvmCross.iOS.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using UIKit;

namespace AutoViewExamples.Ios
{
    public class Setup : MvxIosDialogSetup
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
            return new MvxDebugTrace();
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