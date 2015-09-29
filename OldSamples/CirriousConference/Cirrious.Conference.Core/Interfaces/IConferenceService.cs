using Cirrious.Conference.Core.Models;
using Cirrious.Conference.Core.Models.Raw;
using System.Collections.Generic;

namespace Cirrious.Conference.Core.Interfaces
{
    public interface IConferenceService
    {
        void BeginAsyncLoad();

        void DoSyncLoad();

        bool IsLoading { get; }

        IDictionary<string, SessionWithFavoriteFlag> Sessions { get; }
        IDictionary<string, Sponsor> Exhibitors { get; }
        IDictionary<string, Sponsor> Sponsors { get; }

        IDictionary<string, SessionWithFavoriteFlag> GetCopyOfFavoriteSessions();
    }
}