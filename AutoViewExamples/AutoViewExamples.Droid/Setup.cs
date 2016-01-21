using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.AutoView.Droid;

namespace AutoViewExamples.Droid
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

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            var autoViewSetup = new MvxAutoViewSetup();
            autoViewSetup.Initialize(typeof(Resource.Layout));
        }
    }
}