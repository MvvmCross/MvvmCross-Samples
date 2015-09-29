using Android.Content;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;

namespace NoMvvm
{
    public class Setup
    {
        public static readonly Setup Instance = new Setup();

        public void EnsureInitialized(Context applicationContext)
        {
            if (MvxSimpleIoCContainer.Instance != null)
                return;

            var ioc = MvxSimpleIoCContainer.Initialize();

            ioc.RegisterSingleton<IMvxPluginManager>(new MvxFilePluginManager(".Droid", ".dll"));
	
			ioc.RegisterSingleton<IMvxAndroidGlobals>(new AndroidGlobals(applicationContext, GetType().Namespace));
		}
    }
}