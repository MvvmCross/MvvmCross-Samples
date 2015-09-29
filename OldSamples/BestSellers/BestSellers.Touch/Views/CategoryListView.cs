using BestSellers.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using System.Collections.Generic;

namespace BestSellers.Touch.Views
{
    public class CategoryListView : MvxTableViewController
    {
        public new CategoryListViewModel ViewModel
        {
            get { return (CategoryListViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Best Sellers";

            var source = new MvxStandardTableViewSource(
                TableView,
                UITableViewCellStyle.Default,
                new NSString("CategoryListView"),
                "TitleText DisplayName;SelectedCommand ShowCategoryCommand",
                UITableViewCellAccessory.DisclosureIndicator);

            this.AddBindings(
                new Dictionary<object, string>()
                    {
                        { source, "ItemsSource List" }
                    });

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}