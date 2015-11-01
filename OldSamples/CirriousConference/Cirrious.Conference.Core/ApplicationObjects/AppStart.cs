using Cirrious.Conference.Core.Interfaces;
using Cirrious.Conference.Core.ViewModels;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;

namespace Cirrious.Conference.Core.ApplicationObjects
{
    public class AppStart
        : MvxNavigatingObject
        , IMvxAppStart
    {
        private readonly bool _showSplashScreen;

        public AppStart(bool showSplashScreen)
        {
            _showSplashScreen = showSplashScreen;
        }

        public void Start(object hint = null)
        {
            var confService = Mvx.Resolve<IConferenceService>();
            if (_showSplashScreen)
            {
                confService.BeginAsyncLoad();
                ShowViewModel<SplashScreenViewModel>();
            }
            else
            {
                confService.DoSyncLoad();
                ShowViewModel<HomeViewModel>();
            }
        }
    }
}