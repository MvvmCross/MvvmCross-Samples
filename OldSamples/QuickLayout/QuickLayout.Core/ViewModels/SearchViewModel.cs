using Cirrious.MvvmCross.ViewModels;

namespace QuickLayout.Core.ViewModels
{
    public class SearchViewModel
        : MvxViewModel
    {
        private string _searchText = "Here";
        public string SearchText 
        {   
            get { return _searchText; }
            set { _searchText = value; RaisePropertyChanged(() => SearchText); }
        }

        public void Search()
        {
            SearchText = "Bazinga!";
        }
    }
}