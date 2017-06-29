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

        public Task<PagedResult<Planet>> GetPlanetsAsync(string url = null)
        {
            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<Planet>>($"{Constants.BaseUrl}/planets/", HttpMethod.Get)
                         : _restClient.MakeApiCall<PagedResult<Planet>>(url, HttpMethod.Get);
        }

        private PagedResult<Planet> GetMockedPlanets()
        {
            return new PagedResult<Planet>()
            {
                Count = 3,
                Next = string.Empty,
                Previous = string.Empty,
                Results = new List<Planet>
                {
                    new Planet
                    {
                        Name = "Alderaan",
                        Population = "20000"
                    },
                    new Planet
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
