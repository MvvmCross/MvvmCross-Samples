using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.DownloadCache;
using MvvmCross.Platform.Plugins;


namespace Collections.Touch
{
    public class Setup
        : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Collections.Core.App();
        }
    }
}