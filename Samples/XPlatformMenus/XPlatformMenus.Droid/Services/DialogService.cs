using Android.App;
using XPlatformMenus.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Platform.Droid.Platform;

namespace XPlatformMenus.Droid.Services
{
    /// <summary>
    /// Provides a service to any code that requires a dialog to be shown to the user for more complex situations
    /// where responses and richer user interaction is required use the IInteractionRequest service.
    /// </summary>
    public class DialogService : IDialogService
    {
        /// <summary>Alerts the user with a simple OK dialog and provides a <paramref name="message"/>.</summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="okbtnText">The okbtn text.</param>
        public void Alert(string message, string title, string okbtnText)
        {
            var top = Mvx.Resolve<IMvxAndroidCurrentTopActivity>();
            var act = top.Activity;

            var adb = new AlertDialog.Builder(act);
            adb.SetTitle(title);
            adb.SetMessage(message);
            adb.SetIcon(Resource.Drawable.Icon);
            adb.SetPositiveButton(okbtnText, (sender, args) => { /* some logic */ });
            adb.Create().Show();
        }
    }
}