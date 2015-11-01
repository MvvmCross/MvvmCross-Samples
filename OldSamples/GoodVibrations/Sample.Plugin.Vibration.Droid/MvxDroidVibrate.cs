using Android.Content;
using Android.OS;
using Cirrious.CrossCore;

namespace Sample.Plugin.Vibration.Droid
{
    public class MvxDroidVibrate : IVibrate
    {
        public void Shake()
        {
            var globals = Mvx.Resolve<Cirrious.CrossCore.Droid.IMvxAndroidGlobals>();
            var vibrator = globals.ApplicationContext
                                  .GetSystemService(Context.VibratorService)
                                  as Vibrator;
            vibrator.Vibrate((long)Constants.Short.TotalMilliseconds);
        }
    }
}