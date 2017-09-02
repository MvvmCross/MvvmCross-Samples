using System.Collections.Generic;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using Foundation;
using UIKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views.Presenters.Attributes;

namespace Collections.Touch
{
    [MvxRootPresentation(WrapInNavigationController = true)]
    public class MainMenuView : MvxTableViewController
    {
        public MainMenuView()
        {
            Title = "Main Menu";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new TableSource(TableView);
            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource MenuItems"}
                });

            TableView.Source = source;
            TableView.ReloadData();
        }

        public class TableSource : MvxStandardTableViewSource
        {
            private static readonly NSString Identifier = new NSString("MenuCellIdentifier");
            private const string BindingText = "TitleText Title;SelectedCommand ShowCommand";

            public TableSource(UITableView tableView)
                : base(tableView, UITableViewCellStyle.Default, Identifier, BindingText)
            {
            }
        }
    }
}