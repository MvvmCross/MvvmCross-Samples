using System;
using System.ComponentModel;
using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using NoBinding.Framework;

namespace NoBinding
{
    [Activity(Label = "PluginUse - No Binding", MainLauncher = true, Icon = "@drawable/icon")]
    public class LocationView : Activity
    {
        private LocationViewModel _locationViewModel;

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
            Mvx.Resolve<ITopActivity>().Activity = this;

            // ensure location plugin is available
            Cirrious.MvvmCross.Plugins.Location.PluginLoader.Instance.EnsureLoaded();

            // create the view model
            _locationViewModel = Mvx.IocConstruct<LocationViewModel>();

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
            UpdateError();
            UpdateStarted();
            UpdateLocation();

            // subscribe for future changes
            _locationViewModel.PropertyChanged += LocationViewModelOnPropertyChanged;
        }

        private void LocationViewModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            switch (propertyChangedEventArgs.PropertyName)
            {
                case "Location":
                    UpdateLocation();
                    return;
                case "Error":
                    UpdateError();
                    return;
                case "Started":
                    UpdateStarted();
                    return;
            }
        }

        private void ButtonOnClick(object sender, EventArgs eventArgs)
        {
            _locationViewModel.ToggleCommand.Execute(null);
        }

        private void UpdateError()
        {
            _errorText.Text = _locationViewModel.Error ?? "";
        }

        private void UpdateStarted()
        {
            _startedText.Text = _locationViewModel.Started.ToString();
        }

        private void UpdateLocation()
        {
            var lat = "Unknown";
            var lng = "Unknown";

            var location = _locationViewModel.Location;
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

