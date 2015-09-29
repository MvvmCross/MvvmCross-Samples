using Microsoft.Devices;

namespace Sample.Plugin.Vibration.WindowsPhone
{
    public class MvxWindowsPhoneVibrate : IVibrate
    {
        public void Shake()
        {
            var controller = VibrateController.Default;
            controller.Start(Constants.Short);
        }
    }
}