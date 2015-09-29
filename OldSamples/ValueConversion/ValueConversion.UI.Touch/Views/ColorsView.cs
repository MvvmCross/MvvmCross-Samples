using ValueConversion.Core.ViewModels;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace ValueConversion.UI.Touch
{
    public partial class ColorsView : MvxViewController
    {
        public ColorsView() : base("ColorsView", null)
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

            this.CreateBinding(RedSlider).To<ColorsViewModel>(vm => vm.Red).Apply();
            this.CreateBinding(GreenSlider).To<ColorsViewModel>(vm => vm.Green).Apply();
            this.CreateBinding(BlueSlider).To<ColorsViewModel>(vm => vm.Blue).Apply();
            this.CreateBinding(ColorView).For(v => v.BackgroundColor).To<ColorsViewModel>(vm => vm.Color)
                .WithConversion("NativeColor").Apply();
            this.CreateBinding(ColorLabel).For(v => v.TextColor).To<ColorsViewModel>(vm => vm.Color)
                .WithConversion("ContrastColor").Apply();
            this.CreateBinding(ColorLabel).For(v => v.Text).To<ColorsViewModel>(vm => vm.Color)
                .Apply();
        }
    }
}