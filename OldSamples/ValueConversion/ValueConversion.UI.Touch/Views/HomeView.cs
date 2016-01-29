using ValueConversion.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace ValueConversion.UI.Touch
{
    public class HomeView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Name; SelectedCommand ShowCommand");

            this.CreateBinding(source).To((HomeViewModel vm) => vm.Items).Apply();

            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}