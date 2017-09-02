using Collections.Core.ViewModels.Samples.Expandable;
using MvvmCross.Binding.BindingContext;

namespace Collections.Touch
{
    public class ExpandableView : BaseExpandableTableView
    {
        public ExpandableView()
        {
            Title = "Expandable";
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var set = this.CreateBindingSet<ExpandableView, ExpandableViewModel>();
            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.KittenGroups);
            set.Apply();

            TableView.ReloadData();
        }
    }
}