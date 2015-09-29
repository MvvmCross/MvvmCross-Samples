using Android.Content;
using Android.Widget;
using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Binding.Bindings.Target.Construction;
using Cirrious.MvvmCross.Droid.Platform;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using FractalGen.Core;
using FractalGen.UI.Droid.Views;

namespace FractalGen.UI.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void InitializeFirstChance()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            base.InitializeFirstChance();
        }

        protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            registry.RegisterFactory(new MvxCustomBindingFactory<ImageView>("Special",
                                                                            imageView =>
                                                                            new CustomImageTargetBinding(imageView)));
            base.FillTargetFactories(registry);
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }
}