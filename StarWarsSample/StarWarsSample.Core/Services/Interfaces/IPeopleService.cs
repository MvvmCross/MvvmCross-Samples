using System;
using System.Threading.Tasks;
using StarWarsSample.Core.Models;

namespace StarWarsSample.Core.Services.Interfaces
{
    public interface IPeopleService
    {
        Task<PagedResult<Person>> GetPeopleAsync(string url = null);

        Task<Person> GetPersonAsync();
    }
}
