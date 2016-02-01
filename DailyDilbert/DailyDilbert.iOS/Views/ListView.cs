using DailyDilbert.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace DailyDilbert.Touch
{
    public partial class ListView : MvxViewController
    {
        private static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public ListView()
            : base(UserInterfaceIdiomIsPhone ? "ListView_iPhone" : "ListView_iPad", null)
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var source = new MvxStandardTableViewSource(TableView, "TitleText Title;ImageUrl StripUrl");
            this.CreateBinding(source).To<ListViewModel>(vm => vm.Items).Apply();
            this.CreateBinding(source).For(s => s.SelectionChangedCommand).To<ListViewModel>(vm => vm.ItemSelectedCommand).Apply();
            TableView.Source = source;
            TableView.ReloadData();
        }
    }
}