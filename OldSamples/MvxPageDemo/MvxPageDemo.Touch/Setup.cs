using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvxPageDemo.Shared;
using UIKit;

namespace MvxPageDemo.Touch
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window) : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return (new App());
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {            

            return (new MvxIosViewPresenter((MvxApplicationDelegate)ApplicationDelegate, Window));
        }
    }
}