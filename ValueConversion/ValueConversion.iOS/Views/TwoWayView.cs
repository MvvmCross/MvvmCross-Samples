using ValueConversion.Core.ViewModels;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace ValueConversion.UI.Touch
{
    public partial class TwoWayView : MvxViewController
    {
        public TwoWayView() : base("TwoWayView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.CreateBinding(TheLabel)
                .To<TwoWayViewModel>(vm => vm.TheValue)
                .Apply();
            this.CreateBinding(TheTextField)
                .To<TwoWayViewModel>(vm => vm.TheValue)
                .WithConversion("TwoWay")
                .Apply();

            this.View.AddGestureRecognizer(new UITapGestureRecognizer(() => { TheTextField.ResignFirstResponder(); }));
        }
    }
}