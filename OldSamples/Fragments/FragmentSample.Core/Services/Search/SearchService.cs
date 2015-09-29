using System;
using System.Collections.Generic;
using System.Threading;

namespace FragmentSample.Core.Services.Search
{
    public class SearchService : ISearchService
    {
        public void GetItems(string key, Action<List<SearchResult>> onSuccess, Action<SearchServiceError> onError)
        {
            ThreadPool.QueueUserWorkItem(ignored =>
                {
                    if (string.IsNullOrWhiteSpace(key))
                    {
                        onError(SearchServiceError.ErrorEmptyKey);
                        return;
                    }

                    var success = new List<SearchResult>();
                    for (var i = 0; i < 10; i++)
                    {
                        success.Add(new SearchResult
                            {
                                Id = i,
                                Title = "Title " + i + "(" + key + ")",
                                Notes =
                                    string.Format("This item returned from {0} - here's a GUID: {1}", key,
                                                  Guid.NewGuid().ToString("N")),
                                When = DateTime.UtcNow.AddMinutes(-i)
                            });
                    }
                    onSuccess(success);
                });
        }
    }
}