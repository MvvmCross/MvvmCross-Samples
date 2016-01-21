using Android.Content;
using MvvmCross.Platform.Platform;
using MvvmCross.Core.Platform;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;

namespace ApiExamples.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
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
    }
}