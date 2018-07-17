using System;
using System.Collections.Generic;
using Android.Content;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.ViewModels;
using TwitterSearch.Core;

namespace TwitterSearch.UI.Droid
{
    public class Setup
        : MvxAndroidSetup
    {
        public Setup()
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeLastChance()
        {
            //MvvmCross.Plugin.File.Plat
            base.InitializeLastChance();
        }
    }
}

