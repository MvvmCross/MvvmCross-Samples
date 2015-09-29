using System;
using System.Collections.Generic;
using Android.Content;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using FragmentSample.Core;

namespace FragmentSample.UI.Droid
{
    public interface IFragmentHost
    {
        bool Show(MvxViewModelRequest request);
    }

    public interface ICustomPresenter
    {
        void Register(Type viewModelType, IFragmentHost host);
    }

    public class CustomPresenter
        : MvxAndroidViewPresenter
        , ICustomPresenter
    {
        private Dictionary<Type, IFragmentHost> _dictionary = new Dictionary<Type, IFragmentHost>();

        public override void Show(MvxViewModelRequest request)
        {
            IFragmentHost host;
            if (_dictionary.TryGetValue(request.ViewModelType, out host))
            {
                if (host.Show(request))
                {
                    return;
                }
            }

            base.Show(request);
        }

        public void Register(Type viewModelType, IFragmentHost host)
        {
            _dictionary[viewModelType] = host;
        }
    }

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

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var customPresenter = new CustomPresenter();
            Mvx.RegisterSingleton<ICustomPresenter>(customPresenter);
            return customPresenter;
        }

        public override void LoadPlugins(Cirrious.CrossCore.Plugins.IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.File.PluginLoader>();
            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.DownloadCache.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }
}