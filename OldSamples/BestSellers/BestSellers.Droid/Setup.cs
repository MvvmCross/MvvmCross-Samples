using System;
using System.Collections.Generic;
using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;


namespace BestSellers.Droid
{
    public class Setup
        : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeLastChance()
        {
            var errorHandler = new ErrorDisplayer(ApplicationContext);
            MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.Visibility.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();
            base.InitializeLastChance();
        }
    }
}