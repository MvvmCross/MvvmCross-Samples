using Android.Content;
using Android.Views;
using Cirrious.CrossCore.Droid;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Binding.Droid;
using Cirrious.MvvmCross.Binding.Droid.Binders.ViewTypeResolvers;

namespace CrossLight.Framework
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
            MvxTrace.Initialize();

            ioc.RegisterSingleton<IMvxAndroidGlobals>(new AndroidGlobals(applicationContext));

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