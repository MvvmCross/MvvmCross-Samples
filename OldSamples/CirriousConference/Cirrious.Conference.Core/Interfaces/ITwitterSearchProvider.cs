using Cirrious.Conference.Core.Models.Twitter;
using System;
using System.Collections.Generic;

namespace Cirrious.Conference.Core.Interfaces
{
    public interface ITwitterSearchProvider
    {
        void StartAsyncSearch(string searchText, Action<IEnumerable<Tweet>> success, Action<Exception> error);
    }
}