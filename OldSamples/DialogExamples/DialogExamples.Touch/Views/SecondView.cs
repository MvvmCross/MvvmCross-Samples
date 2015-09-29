using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Touch;
using CrossUI.Touch.Dialog.Elements;
using DialogExamples.Core.ViewModels;
using MonoTouch.Foundation;

namespace DialogExamples.Touch.Views
{
    [Register("SecondView")]
    public class SecondView : MvxDialogViewController
    {
        public SecondView()
            : base(pushing:true)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var bindings = this.CreateInlineBindingTarget<SecondViewModel>();

            Root = new RootElement("Second Root")
                {
                    new Section("Date")
                        {
                            new DateElement("Date").Bind(bindings, vm => vm.When),
                            new StringElement("Date is").Bind(bindings, vm => vm.When),
                        },
                    new Section("Time")
                        {
                            new TimeElement("Time", null).Bind(bindings, vm => vm.Duration),
                            new StringElement("Time is").Bind(bindings, vm => vm.Duration),
                        },
                    new Section("Float")
                        {
                            new FloatElement()
                                {
                                    MinValue = 32,
                                    MaxValue = 212
                                }.Bind(bindings, vm => vm.Temperature),
                            new StringElement("Float is").Bind(bindings, vm => vm.Temperature),
                        },
                    new Section("Todo:")
                        {
                            new StringElement("RadioElement & Group"),
                            new StringElement("Multiline"),
                            new StringElement("Html"),
                            new StringElement("Image"),
                            new StringElement("View"),
                            new StringElement("Html"),
                            new StringElement("WebContent"),
                            new StringElement("Achievement"),
                            new StringElement("General 'Options' on lots of cell types"),
                            new StringElement("General Resource ID overrides"),
                        },
                };
        }
    }
}