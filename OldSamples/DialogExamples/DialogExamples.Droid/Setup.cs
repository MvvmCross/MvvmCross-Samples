using Android.Content;
using Cirrious.MvvmCross.Dialog.Droid;
using Cirrious.MvvmCross.ViewModels;

namespace DialogExamples.Droid
{
    public class Setup : MvxAndroidDialogSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}