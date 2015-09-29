using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace BestSellers.ViewModels
{
    public class CategoryDataViewModel
        : BaseViewModel
    {
        public string ListName { get; set; }
        public string DisplayName { get; set; }

        public string ListNameEncoded
        {
            get { return ListName.ToLower().Replace(' ', '-'); }
        }

        public override string ToString()
        {
            return DisplayName;
        }

        public ICommand ShowCategoryCommand
        {
            get
            {
                return new MvxCommand(() => ShowViewModel<BookListViewModel>(new { category = ListNameEncoded }));
            }
        }
    }
}