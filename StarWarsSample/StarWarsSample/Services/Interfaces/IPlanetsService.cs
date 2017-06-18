using System;
using System.Threading.Tasks;
using StarWarsSample.Core.Models;

namespace StarWarsSample.Core.Services.Interfaces
{
    public interface IPlanetsService
    {
        Task<PagedResult<Planet>> GetPlanetsAsync(string url = null);
    }
}
