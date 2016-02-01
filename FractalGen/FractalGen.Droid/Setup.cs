using Android.Content;
using Android.Widget;
using FractalGen.Core;
using FractalGen.UI.Droid.Views;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Plugins;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform.IoC;
using MvvmCross.Plugins.Messenger;

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