using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Collections.Touch
{
    public class BaseKittenTableView
        : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableSource(TableView)
                {
                    UseAnimations = true,
                    AddAnimation = UITableViewRowAnimation.Left,
                    RemoveAnimation = UITableViewRowAnimation.Right
                };

            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource Kittens"}
                });

            TableView.Source = source;
            TableView.ReloadData();
        }

        public class TableSource : MvxSimpleTableViewSource
        {
            public TableSource(UITableView tableView)
                : base(tableView, "KittenCell", "KittenCell")
            {
            }

            public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                return KittenCell.GetCellHeight();
            }
        }
    }
}