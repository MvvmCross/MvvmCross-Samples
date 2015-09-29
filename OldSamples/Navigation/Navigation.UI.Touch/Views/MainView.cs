using MonoTouch.UIKit;
using Navigation.Core.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace Navigation.UI.Touch
{
    public partial class MainView : MvxViewController
    {
        public MainView() : base("MainView", null)
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

            this.CreateBinding(KeyTextField).To((MainViewModel vm) => vm.ParameterKey).Apply();
            this.CreateBinding(AnonButton).To((MainViewModel vm) => vm.GoAnonymousCommand).Apply();
            this.CreateBinding(ParamsButton).To((MainViewModel vm) => vm.GoParameterizedCommand).Apply();
            this.CreateBinding(SimpleButton).To((MainViewModel vm) => vm.GoSimpleCommand).Apply();

            this.View.AddGestureRecognizer(new UITapGestureRecognizer(() => { KeyTextField.ResignFirstResponder(); }));
        }
    }
}