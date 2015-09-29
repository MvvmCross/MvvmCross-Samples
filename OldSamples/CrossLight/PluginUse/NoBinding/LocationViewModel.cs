using System.ComponentModel;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Plugins.Location;
using NoBinding.Framework;

namespace NoBinding
{
    public class LocationViewModel : INotifyPropertyChanged
    {
        private readonly IMvxGeoLocationWatcher _geoLocationWatcher;
        private readonly ITopActivity _topActivity;

        private bool _started;
        private string _error;

        public LocationViewModel(ITopActivity topActivity, IMvxGeoLocationWatcher geoLocationWatcher)
        {
            _topActivity = topActivity;
            _geoLocationWatcher = geoLocationWatcher;
        }

        private MvxGeoLocation _location;
        public MvxGeoLocation Location
        {
            get { return _location; }
            set
            {
				Mvx.Trace("Location received {0}", _location);
                _location = value;
				OnBackgroundPropertyChanged("Location");
            }
        }

        public bool Started
        {
            get { return _started; }
            set { _started = value; OnPropertyChanged("Started"); }
        }

        public string Error
        {
            get { return _error; }
            set { _error = value; OnBackgroundPropertyChanged("Error"); }
        }

        public ICommand ToggleCommand
        {
            get { return new SimpleCommand(() =>
                {
                    if (!Started)
                    {
                        _geoLocationWatcher.Start(new MvxGeoLocationOptions(), OnLocation, OnError);
                    }
                    else
                    {
                        _geoLocationWatcher.Stop();
                    }
                    Started = !Started;
                }); 
            }
        }

        private void OnLocation(MvxGeoLocation location)
        {
            Location = location;
        }

        private void OnError(MvxLocationError error)
        {
            Error = error.Code.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnBackgroundPropertyChanged(string propertyName)
        {
            if (_topActivity.Activity != null)
                _topActivity.Activity.RunOnUiThread(() => OnPropertyChanged(propertyName));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}