using System;
using System.Collections.Generic;

namespace DailyGarfield.Core
{
    public interface IGarfieldService
    {
        void GetFeedItems(Action<List<GarfieldItem>> success, Action<Exception> error);
    }
}