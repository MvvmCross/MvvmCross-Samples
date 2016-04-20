using MvvmCross.Platform.Plugins;

namespace ValueConversion.UI.Droid.Bootstrap
{
    public class ColorPluginBootstrap
        //: MvxPluginBootstrapAction<MvvmCross.Plugins.Color.PluginLoader>
        : MvxLoaderPluginBootstrapAction<MvvmCross.Plugins.Color.PluginLoader, SomeAbsolutelty.Unconventional.Namespace.CustomColorPlugin>
    {
    }
}