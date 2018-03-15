using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using StarWarsSample.Core.Models;
using StarWarsSample.Core.Rest.Interfaces;
using StarWarsSample.Core.Services.Interfaces;

namespace StarWarsSample.Core.Services.Implementations
{
    public class PlanetService : IPlanetsService
    {
        private readonly IRestClient _restClient;

        public PlanetService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<PagedResult<BasePlanet>> GetPlanetsAsync(string url = null)
        {


            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<BasePlanet>>($"{Constants.BaseUrl}/planets/", HttpMethod.Get)
                         : _restClient.MakeApiCall<PagedResult<BasePlanet>>(url, HttpMethod.Get);
        }

        private PagedResult<IPlanet> GetMockedPlanets()
        {
            return new PagedResult<IPlanet>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<BasePlanet>
                {
                    new Planet
                    {
                        Name = "Alderaan",
                        Population = "20000"
                    },
                    new Planet2
                    {
                        Name = "Crait",
                        Population = "675000"
                    },
                    new Planet
                    {
                        Name = "Endor",
                        Population = "22130000"
                    }
                }
            };
        }
    }
}
