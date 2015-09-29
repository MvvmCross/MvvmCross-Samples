using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Touch;
using CrossUI.Touch.Dialog.Elements;
using DialogExamples.Core.ViewModels;
using DialogExamples.Touch.BindableElements;
using MonoTouch.Foundation;

namespace DialogExamples.Touch.Views
{
    [Register("ThirdView")]
    public class ThirdView : MvxDialogViewController
    {
        public ThirdView()
            : base(pushing:true)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            var bindings = this.CreateInlineBindingTarget<ThirdViewModel>();

            Root = new RootElement("Example Root")
                {
                    new Section("Choose a list")
                        {
                            new StringElement("Short List").Bind(bindings, element => element.SelectedCommand, vm => vm.ShortListCommand),
                            new StringElement("Long List").Bind(bindings, element => element.SelectedCommand, vm => vm.LongListCommand),
                        },
                    new BindableSection<CustomStringElement>("Bound String Elements")
                        .Bind(bindings, element => element.ItemsSource, vm => vm.People),
                    new BindableSection<CustomViewElement>("Bound Custom View Elements")
                        .Bind(bindings, element => element.ItemsSource, vm => vm.People)
                };
        }
    }
}