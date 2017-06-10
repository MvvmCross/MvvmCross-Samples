using System;
using System.Threading.Tasks;
using StarWarsSample.Models;

namespace StarWarsSample.Services.Interfaces
{
    public interface IPeopleService
    {
        Task<Person> GetPersonAsync();
    }
}
