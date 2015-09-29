using System;
using System.Collections.Generic;

namespace DailyDilbert.Core
{
    public interface IDilbertService
    {
        void GetFeedItems(Action<List<DilbertItem>> success, Action<Exception> error);
    }
}