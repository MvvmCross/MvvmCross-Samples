namespace DailyDilbert.Touch
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp()
        {
            return new DailyDilbert.Core.App();
        }
    }
}