using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;

namespace PictureTaking.Touch
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new PictureTaking.Core.App();
        }
    }
}