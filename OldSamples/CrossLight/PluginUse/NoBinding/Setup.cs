using Android.Content;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Droid.Platform;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using NoBinding.Framework;

namespace NoBinding
{
    public class Setup
    {
        public static readonly Setup Instance = new Setup();

        private Setup()
        {            
        }

        public void EnsureInitialized(Context applicationContext)
        {
            if (MvxSimpleIoCContainer.Instance != null)
                return;

            var ioc = MvxSimpleIoCContainer.Initialize();

            ioc.RegisterSingleton<IMvxTrace>(new MvxDebugOnlyTrace());
            ioc.RegisterSingleton<IMvxPluginManager>(new MvxFilePluginManager(".Droid", ".dll"));

			ioc.RegisterSingleton<IMvxAndroidGlobals>(new AndroidGlobals(applicationContext, GetType().Namespace));

            var topActivity = new AndroidTopActivity();
            ioc.RegisterSingleton<ITopActivity>(topActivity);
            ioc.RegisterSingleton<IMvxMainThreadDispatcher>(topActivity);
       }
    }
}