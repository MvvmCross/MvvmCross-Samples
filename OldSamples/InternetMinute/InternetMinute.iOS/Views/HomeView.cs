using InternetMinute.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using InternetMinute.Touch.Views;

namespace InternetMinute.Touch
{
    public class HomeView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxSimpleTableViewSource(TableView, DescriptionCell.Key, DescriptionCell.Key);
            this.CreateBinding(source).To<HomeViewModel>(vm => vm.Descriptions).Apply();

            TableView.RowHeight = 100.0f;
            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}