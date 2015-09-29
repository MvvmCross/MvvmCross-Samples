using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.CrossCore;
using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.ViewModels;
using FragmentSample.Core.Services.Search;

namespace FragmentSample.Core.ViewModels.Form
{
    public class SearchViewModel : BaseViewModel
    {
        private List<SearchResult> _items;
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                _searchTerm = value;
                RaisePropertyChanged(() => SearchTerm);
            }
        }

        public List<SearchResult> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        public ICommand FetchItemsCommand
        {
            get { return new MvxCommand(DoFetchItems); }
        }

        private void DoFetchItems()
        {
            var service = Mvx.Resolve<ISearchService>();
            service.GetItems(SearchTerm, OnSuccess, OnError);
        }

        private void OnSuccess(List<SearchResult> simpleItems)
        {
            Items = simpleItems;
        }

        private void OnError(SearchServiceError searchServiceError)
        {
            MvxTrace.Trace("Sorry - a problem occurred - " + searchServiceError.ToString());
        }
    }
}