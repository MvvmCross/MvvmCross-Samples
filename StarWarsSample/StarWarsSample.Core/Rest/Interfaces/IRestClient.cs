using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsSample.Core.Rest.Interfaces
{
    public interface IRestClient
    {
        Task<TResult> MakeApiCall<TResult>(string url, HttpMethod method, object data = null)
                        where TResult : class;
    }
}
