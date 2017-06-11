using System;
using System.Net.Http;
using System.Threading.Tasks;
using StarWarsSample.Models;
using StarWarsSample.Rest.Interfaces;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.Services.Implementations
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
    }
}
