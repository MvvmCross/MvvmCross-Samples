using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using MvxPageDemo.Shared;
using UIKit;

namespace MvxPageDemo.Touch
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return (new App());
        }

        protected override IMvxTouchViewPresenter CreatePresenter()
        {
            return (new MvxModalNavSupportTouchViewPresenter((MvxApplicationDelegate)ApplicationDelegate, Window));
        }
    }
}