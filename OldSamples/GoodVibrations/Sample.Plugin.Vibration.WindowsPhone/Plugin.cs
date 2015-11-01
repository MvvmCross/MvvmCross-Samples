using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;

namespace Sample.Plugin.Vibration.WindowsPhone
{
    public class Plugin
        : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IVibrate>(new MvxWindowsPhoneVibrate());
        }
    }
}
