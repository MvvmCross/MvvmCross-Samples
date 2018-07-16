using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace TwitterSearch.Core.ViewModels
{
    public class HomeViewModel
        : MvxViewModel
    {
        public override async Task Initialize()
        {
            await base.Initialize();

            Commands = new MvxCommandCollectionBuilder()
                .BuildCollectionFor(this);
            PickRandomCommand();
        }

        public IMvxCommandCollection Commands { get; private set; }

        public class ViewModelState
        {
            public string SearchText { get; set; }
        }

        public void ReloadState(ViewModelState searchText)
        {
            Log.Trace("ReloadState called with {0}", searchText.SearchText);
            SearchText = searchText.SearchText;
        }

        public ViewModelState SaveState()
        {
            Log.Trace("SaveState called");
            return new ViewModelState { SearchText = SearchText };
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; RaisePropertyChanged("SearchText"); }
        }

        public void SearchCommand()
        {
            if (SearchText == "javascript")
                return;

            if (string.IsNullOrWhiteSpace(SearchText))
                return;
            NavigationService.Navigate<TwitterViewModel,string>(SearchText);
        }

        public void PickRandomCommand()
        {
            var items = new[] { "MvvmCross", "WP7", "MonoTouch", "MonoDroid", "mvvm", "kittens" };
            var r = new Random();
            var originalText = SearchText;
            var newText = originalText;
            while (originalText == newText)
            {
                var which = r.Next(items.Length);
                newText = items[which];
            }
            SearchText = newText;
        }
    }
}