using Android.Content;
using Android.Views;
using Cirrious.CrossCore.Core;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.Droid.Platform;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Binding.Droid.Binders.ViewTypeResolvers;
using Mvvm.Framework;

namespace Mvvm
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

            ioc.RegisterSingleton<IMvxPluginManager>(new MvxFilePluginManager(".Droid", ".dll"));

            ioc.RegisterSingleton<IMvxAndroidGlobals>(new AndroidGlobals(applicationContext, GetType().Namespace));

            var topActivity = new AndroidTopActivity();
            ioc.RegisterSingleton<ITopActivity>(topActivity);
            ioc.RegisterSingleton<IMvxMainThreadDispatcher>(topActivity);

            var builder = new MvxAndroidBindingBuilder();
            builder.DoRegistration();

            var viewCache = ioc.Resolve<IMvxTypeCache<View>>();
            viewCache.AddAssembly(typeof(View).Assembly);

            var namespaces = ioc.Resolve<IMvxNamespaceListViewTypeResolver>();
            namespaces.Add("Android.Views");
            namespaces.Add("Android.Widget");
            namespaces.Add("Android.Webkit");
        }
    }
}