using Navigation.Core.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Navigation.UI.Touch
{
    public partial class ParameterizedView : MvxViewController
    {
        public ParameterizedView() : base("ParameterizedView", null)
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

            // Perform any additional setup after loading the view, typically from a nib.
            this.CreateBinding(KeyLabel).To((ParameterizedViewModel vm) => vm.Key).Apply();
        }
    }
}