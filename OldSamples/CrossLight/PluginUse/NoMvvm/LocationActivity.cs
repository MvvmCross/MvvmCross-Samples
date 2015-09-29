using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;

namespace NoMvvm
{
    [Activity(Label = "PluginUse - No Mvvm", MainLauncher = true, Icon = "@drawable/icon")]
    public class LocationActivity : Activity
    {
        private IMvxGeoLocationWatcher _geoLocationWatcher;
        private bool _started;

        private TextView _latText;
        private TextView _lngText;
        private TextView _startedText;
        private TextView _errorText;
        private Button _button;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // setup the application
            Setup.Instance.EnsureInitialized(ApplicationContext);

            // ensure location plugin is available
            Cirrious.MvvmCross.Plugins.Location.PluginLoader.Instance.EnsureLoaded();

            // get the location instance
            _geoLocationWatcher = Mvx.Resolve<IMvxGeoLocationWatcher>();

            // create the UI
            SetContentView(Resource.Layout.Main);

            // get the controls
             _latText = this.FindViewById<TextView>(Resource.Id.LatText);
             _lngText = this.FindViewById<TextView>(Resource.Id.LngText);
             _startedText = this.FindViewById<TextView>(Resource.Id.StartedText);
             _errorText = this.FindViewById<TextView>(Resource.Id.ErrorText);
             _button = this.FindViewById<Button>(Resource.Id.ToggleButton);

             // bind to click
            _button.Click += ButtonOnClick;

            // update all UI
            UpdateError(null);
            UpdateStarted();
            UpdateLocation(null);
        }


        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            if (!_started)
            {
                _geoLocationWatcher.Start(new MvxGeoLocationOptions(), OnLocation, OnError);
            }
            else
            {
                _geoLocationWatcher.Stop();
            }
            _started = !_started;
            UpdateStarted();
        }

        private void OnLocation(MvxGeoLocation location)
        {
            RunOnUiThread(() => UpdateLocation(location));
        }

        private void OnError(MvxLocationError error)
        {
            RunOnUiThread(() => UpdateError(error));
        }

        private void UpdateError(MvxLocationError error)
        {
            _errorText.Text = error == null ? "" : error.Code.ToString();
        }

        private void UpdateStarted()
        {
            _startedText.Text = _started.ToString();
        }

        private void UpdateLocation(MvxGeoLocation location)
        {
            var lat = "Unknown";
            var lng = "Unknown";

            if (location != null
                && location.Coordinates != null)
            {
                lat = location.Coordinates.Latitude.ToString();
                lng = location.Coordinates.Longitude.ToString();
            }

            _latText.Text = lat;
            _lngText.Text = lng;
        }
    }
}

