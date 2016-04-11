using System;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.Color.Droid;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Plugins.Color.Droid.BindingTargets;

namespace SomeAbsolutelty.Unconventional.Namespace
{
    public class CustomColorPlugin: IMvxPlugin
    {
        public void Load()
        {
            Console.WriteLine ("-------- This plugin is loaded instead of the default");
            Mvx.RegisterSingleton<IMvxNativeColor>(new MvxAndroidColor());
            Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(RegisterDefaultBindings);
        }

        private void RegisterDefaultBindings()
        {
            var helper = new MvxDefaultColorBindingSet();
            helper.RegisterBindings();
        }
    }
}

