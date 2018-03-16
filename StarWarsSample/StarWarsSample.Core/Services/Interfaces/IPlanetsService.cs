using System;
using System.Threading.Tasks;
using StarWarsSample.Core.Models;

namespace StarWarsSample.Core.Services.Interfaces
{
    public interface IPlanetsService
    {
        Task<PagedResult<BasePlanet>> GetPlanetsAsync(string url = null);
    }
}
