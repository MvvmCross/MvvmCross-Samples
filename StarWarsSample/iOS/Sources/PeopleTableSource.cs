using System;
using System.Windows.Input;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using StarWarsSample.iOS.Views.Cells;
using UIKit;

namespace StarWarsSample.iOS.Sources
{
    public class PeopleTableSource : MvxSimpleTableViewSource
    {
        public ICommand FetchCommand { get; set; }

        public PeopleTableSource(UITableView tableView) : base(tableView, typeof(PeopleTableViewCell))
        {
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
        {
            var cell = base.GetOrCreateCellFor(tableView, indexPath, item);

            if (indexPath.Item == ItemsSource.Count() - 5)
                FetchCommand?.Execute(null);

            return cell;
        }
    }
}
