using Cirrious.Conference.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Cirrious.Conference.Core.Models.Twitter
{
    public class TwitterSearchProvider : ITwitterSearchProvider
    {
        public void StartAsyncSearch(string searchText, Action<IEnumerable<Tweet>> success, Action<Exception> error)
        {
            TwitterSearch.StartAsyncSearch(searchText, success, error);
        }
    }
}