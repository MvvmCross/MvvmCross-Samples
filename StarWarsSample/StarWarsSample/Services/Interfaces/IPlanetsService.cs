using System;
using System.Threading.Tasks;
using StarWarsSample.Models;

namespace StarWarsSample.Services.Interfaces
{
    public interface IPlanetsService
    {
        Task<PagedResult<Planet>> GetPlanetsAsync();
    }
}
