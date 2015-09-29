using MonoTouch.AudioToolbox;

namespace Sample.Plugin.Vibration.Touch
{
    public class MvxTouchVibrate : IVibrate
    {
        public void Shake()
        {
            // we have no control over duration here!
            SystemSound.Vibrate.PlaySystemSound(); 
        }
    }
}