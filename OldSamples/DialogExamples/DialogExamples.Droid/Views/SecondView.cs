using System.ComponentModel;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Droid.Views;
using CrossUI.Droid.Dialog.Elements;
using DialogExamples.Core.ViewModels;

namespace DialogExamples.Droid.Views
{
    [Activity(Label = "View for SecondViewModel")]
    public class SecondView : MvxDialogActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

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
                            new TimeElement("Time").Bind(bindings, vm => vm.Duration),
                            new StringElement("Time is").Bind(bindings, vm => vm.Duration),
                        },
                    new Section("Float")
                        {
                            new FloatElement("Float?")
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