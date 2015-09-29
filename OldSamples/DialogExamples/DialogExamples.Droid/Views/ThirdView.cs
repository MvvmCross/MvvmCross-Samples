using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Droid.Views;
using CrossUI.Droid.Dialog.Elements;
using DialogExamples.Core.ViewModels;
using DialogExamples.Droid.BindableElements;

namespace DialogExamples.Droid.Views
{
    [Activity(Label = "View for ThirdViewModel")]
    public class ThirdView : MvxDialogActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var bindings = this.CreateInlineBindingTarget<ThirdViewModel>();

            Root = new RootElement("Example Root")
                {
                    new Section("Choose a list")
                        {
                            new ButtonElement("Short List").Bind(bindings, element => element.SelectedCommand, vm => vm.ShortListCommand),
                            new ButtonElement("Long List").Bind(bindings, element => element.SelectedCommand, vm => vm.LongListCommand),
                        },
                    new BindableSection<CustomStringElement>("Bound String Elements")
                        .Bind(bindings, element => element.ItemsSource, vm => vm.People),
                    new BindableSection<CustomViewElement>("Bound Custom View Elements", 
                            () => new CustomViewElement(this))
                        .Bind(bindings, element => element.ItemsSource, vm => vm.People)
                };
        }
    }
}