using System.Collections.Generic;
using MvvmCross.iOS.Views;
using UIKit;
using Foundation;
using MvvmCross.Binding.BindingContext;
using System;
using MvvmCross.iOS.Support.Views;

namespace Collections.Touch
{
    public class BaseExpandableTableView : MvxTableViewController
    {
        protected ExpandableTableSource source;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            source = new ExpandableTableSource(TableView)
            {
                UseAnimations = true,
                AddAnimation = UITableViewRowAnimation.Left,
                RemoveAnimation = UITableViewRowAnimation.Right
            };

            TableView.RowHeight = 120f;
            TableView.Source = source;
        }
    }

    public class ExpandableTableSource : MvxExpandableTableViewSource
    {
        public ExpandableTableSource(UITableView tableView) : base(tableView)
        {
            string nibName = "KittenCell";
            _cellIdentifier = new NSString(nibName);
            tableView.RegisterNibForCellReuse(UINib.FromName(nibName, NSBundle.MainBundle), CellIdentifier);


            string nibName2 = "HeaderCell";
            _headerCellIdentifier = new NSString(nibName2);
            tableView.RegisterNibForCellReuse(UINib.FromName(nibName2, NSBundle.MainBundle), HeaderCellIdentifier);
        }

        protected override UITableViewCell GetOrCreateHeaderCellFor(UITableView tableView, nint section)
        {
            return tableView.DequeueReusableCell(HeaderCellIdentifier);
        }

        protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath, object item)
        {
            return tableView.DequeueReusableCell(CellIdentifier);
        }

        private readonly NSString _cellIdentifier;
        protected virtual NSString CellIdentifier => _cellIdentifier;

        private readonly NSString _headerCellIdentifier;
        protected virtual NSString HeaderCellIdentifier => _headerCellIdentifier;
    }
}