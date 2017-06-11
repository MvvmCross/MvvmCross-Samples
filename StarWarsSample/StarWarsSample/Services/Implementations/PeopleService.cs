using System;
using System.Net.Http;
using System.Threading.Tasks;
using StarWarsSample.Models;
using StarWarsSample.Rest.Interfaces;
using StarWarsSample.Services.Interfaces;

namespace StarWarsSample.Services.Implementations
{
    public class PeopleService : IPeopleService
    {
        private readonly IRestClient _restClient;

        public PeopleService(IRestClient restClient)
        {
            _restClient = restClient;
        }

        public Task<PagedResult<Person>> GetPeopleAsync(string url = null)
        {
            return string.IsNullOrEmpty(url)
                         ? _restClient.MakeApiCall<PagedResult<Person>>($"{Constants.BaseUrl}/people/", HttpMethod.Get)
                         : _restClient.MakeApiCall<PagedResult<Person>>(url, HttpMethod.Get);
        }

        public Task<Person> GetPersonAsync()
        {
            return _restClient.MakeApiCall<Person>($"{Constants.BaseUrl}/people/1/", HttpMethod.Get);
        }
    }
}
