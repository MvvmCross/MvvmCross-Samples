using Cirrious.Conference.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using System.Collections.Generic;

namespace Cirrious.Conference.UI.Touch.Views
{
    public class BaseSponsorsView<TViewModel>
        : MvxTableViewController
        where TViewModel : BaseSponsorsViewModel
    {
        private UIActivityIndicatorView _activityView;

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationItem.SetRightBarButtonItem(new UIBarButtonItem("Tweet", UIBarButtonItemStyle.Bordered, (sender, e) => ViewModel.DoShareGeneral()), false);

            //this.View.BackgroundColor = UIColor.Black;

            //_activityView = new UIActivityIndicatorView(this.View.Frame);
            //Add(_activityView);
            //View.BringSubviewToFront(_activityView);

            var source = new MvxActionBasedTableViewSource(
                                TableView,
                                UITableViewCellStyle.Default,
                                SponsorCell.Identifier,
                                SponsorCell.BindingText,
                                UITableViewCellAccessory.None);

            source.CellCreator = (tableView, indexPath, item) =>
                {
                    return SponsorCell.LoadFromNib(tableView);
                };
            this.AddBindings(new Dictionary<object, string>()
                                 {
                                     {source, "ItemsSource Sponsors"},
                                 });
            TableView.RowHeight = 90;
            TableView.Source = source;
            TableView.BackgroundColor = UIColor.White;
            TableView.ReloadData();
        }
    }
}