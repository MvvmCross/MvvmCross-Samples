using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using StarWarsSample.Models;

namespace StarWarsSample.ViewModels
{
    public class PlanetViewModel : MvxViewModel
    {
        private readonly IMvxJsonConverter _jsonConverter;

        public PlanetViewModel(IMvxJsonConverter jsonConverter)
        {
            _jsonConverter = jsonConverter;
        }

        public void Init(string serializedPlanet)
        {
            Planet = _jsonConverter.DeserializeObject<Planet>(serializedPlanet);
        }

        private Planet _planet;
        public Planet Planet
        {
            get
            {
                return _planet;
            }
            set
            {
                _planet = value;
                RaisePropertyChanged(() => Planet);
            }
        }
    }
}
