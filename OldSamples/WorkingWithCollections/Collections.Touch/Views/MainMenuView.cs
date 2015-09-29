using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace Collections.Touch
{
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

#warning Switch to new base constructor when released...
            public TableSource(UITableView tableView)
                : base(tableView, UITableViewCellStyle.Default, Identifier, BindingText)
            {
            }
        }
    }
}