using System;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Presenters;

namespace StarWarsSample.Forms.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, App>
    {
        protected override IMvxFormsPagePresenter CreateFormsPagePresenter(IMvxFormsViewPresenter viewPresenter)
        {
            // workaround which should be removed when https://github.com/MvvmCross/MvvmCross/pull/2972 is released
            var presenter = base.CreateFormsPagePresenter(viewPresenter);
            Mvx.IoCProvider.RegisterSingleton<IMvxFormsPagePresenter>(presenter);
            return presenter;
        }
    }
}