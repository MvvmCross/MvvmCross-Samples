using System;
using System.Threading.Tasks;
using StarWarsSample.Models;

namespace StarWarsSample.Services.Interfaces
{
    public interface IPeopleService
    {
        Task<PagedResult<Person>> GetPeopleAsync(string url = null);

        Task<Person> GetPersonAsync();
    }
}
