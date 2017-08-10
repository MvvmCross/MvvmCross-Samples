using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Dialog.Droid;

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