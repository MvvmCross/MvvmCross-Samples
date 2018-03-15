using System;
using StarWarsSample.Core.Models;

namespace StarWarsSample.Core.Extensions
{
    public static class PlanetExtensions
    {
        public static Planet ToPlanet(this BasePlanet basePlanet)
        {
            return new Planet
            {
                Climate = basePlanet.Climate,
                Created = basePlanet.Created,
                Diameter = basePlanet.Diameter,
                Edited = basePlanet.Edited,
                Films = basePlanet.Films,
                Gravity = basePlanet.Gravity,
                Name = basePlanet.Name,
                OrbitalPeriod = basePlanet.OrbitalPeriod,
                Population = basePlanet.Population,
                Residents = basePlanet.Residents,
                RotationPeriod = basePlanet.RotationPeriod,
                SurfaceWater = basePlanet.SurfaceWater,
                Terrain = basePlanet.Terrain,
                Url = basePlanet.Url
            };
        }

        public static Planet2 ToPlanet2(this BasePlanet basePlanet)
        {
            return new Planet2
            {
                Climate = basePlanet.Climate,
                Created = basePlanet.Created,
                Diameter = basePlanet.Diameter,
                Edited = basePlanet.Edited,
                Films = basePlanet.Films,
                Gravity = basePlanet.Gravity,
                Name = basePlanet.Name,
                OrbitalPeriod = basePlanet.OrbitalPeriod,
                Population = basePlanet.Population,
                Residents = basePlanet.Residents,
                RotationPeriod = basePlanet.RotationPeriod,
                SurfaceWater = basePlanet.SurfaceWater,
                Terrain = basePlanet.Terrain,
                Url = basePlanet.Url
            };
        }
    }
}
