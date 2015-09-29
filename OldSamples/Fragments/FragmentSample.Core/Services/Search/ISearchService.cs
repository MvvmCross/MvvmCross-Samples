using System;
using System.Collections.Generic;

namespace FragmentSample.Core.Services.Search
{
    public interface ISearchService
    {
        void GetItems(string key, Action<List<SearchResult>> onSuccess, Action<SearchServiceError> onError);
    }
}