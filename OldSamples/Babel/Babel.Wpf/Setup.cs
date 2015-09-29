using System;
using System.IO;
using System.Windows.Threading;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.ResourceLoader.Wpf;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Wpf.Platform;
using Cirrious.MvvmCross.Wpf.Views;

namespace Babel.Wpf
{
    // hack necessary due to https://github.com/slodge/MvvmCross/issues/267?source=c
    public class HackResourceLoaderPluginBootstrap
        : MvxPluginBootstrapAction<Cirrious.MvvmCross.Plugins.ResourceLoader.PluginLoader>
    {
    }

    // hack necessary due to https://github.com/slodge/MvvmCross/issues/267?source=c
    public class HackJsonPluginBootstrap
        : MvxPluginBootstrapAction<Cirrious.MvvmCross.Plugins.Json.PluginLoader>
    {
    }

    public class Setup
        : MvxWpfSetup
    {
        public Setup(Dispatcher dispatcher, IMvxWpfViewPresenter presenter)
            : base(dispatcher, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}
