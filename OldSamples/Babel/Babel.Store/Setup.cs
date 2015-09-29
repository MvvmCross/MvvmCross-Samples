using System;
using System.IO;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Plugins.ResourceLoader.WindowsStore;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Platform;
using Windows.UI.Xaml.Controls;

namespace Babel.Store
{
    public class HackMvxStoreResourceLoader : MvxStoreResourceLoader
    {
        public override void GetResourceStream(string resourcePath, Action<Stream> streamAction)
        {
            // in 3.0.8.2 and earlier we needed to replace the "/" with "\\" :/
            resourcePath = resourcePath.Replace("/", "\\");
            base.GetResourceStream(resourcePath, streamAction);
        }
    }

    public class Setup : MvxStoreSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterType<IMvxResourceLoader, HackMvxStoreResourceLoader>();
            return new Core.App();
        }
    }
}