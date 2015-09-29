using Android.Content;
using Cirrious.MvvmCross.AutoView.Droid;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.ViewModels;

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