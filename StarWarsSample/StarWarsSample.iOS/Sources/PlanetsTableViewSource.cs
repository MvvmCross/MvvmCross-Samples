﻿using System;
using System.Windows.Input;
using MvvmCross.Binding.ExtensionMethods;
using MvvmCross.Binding.iOS.Views;
using StarWarsSample.iOS.Views.Cells;
using UIKit;

namespace StarWarsSample.iOS.Sources
{
    public class PlanetsTableViewSource : MvxSimpleTableViewSource
    {
        public ICommand FetchCommand { get; set; }

        public PlanetsTableViewSource(UITableView tableView) : base(tableView, typeof(NameTableViewCell))
        {
            DeselectAutomatically = true;
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
