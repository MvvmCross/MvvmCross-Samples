using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace Sample.Plugin.Vibration.Touch
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IVibrate>(new MvxTouchVibrate());
        }
    }
}
