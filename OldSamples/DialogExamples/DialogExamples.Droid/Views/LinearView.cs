using System.Linq;
using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Dialog.Droid.Views;
using CrossUI.Droid.Dialog.Elements;
using DialogExamples.Core.ViewModels;

namespace DialogExamples.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class LinearView : MvxLinearDialogActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var bindings = this.CreateInlineBindingTarget<LinearViewModel>();

            // note that this list isn't bound - if the view model list changes, then the UI won't update it;s list
            var radioChoices = from r in (ViewModel as LinearViewModel).DessertChoices
                               select (Element)new RadioElement(r);

            Root = new RootElement("Example Root")
                {
                    new Section("Your details")
                        {
                            new EntryElement("Login", "Enter Login name").Bind(bindings, vm => vm.TextProperty),
                            new EntryElement("Password", "Enter Password")
                            {
                                Password = true
                            }.Bind(bindings, vm => vm.PasswordProperty)
                        },
                    new Section("Your options")
                        {
                            new BooleanElement("Remember me?").Bind(bindings, vm => vm.SwitchThis),
                            new CheckboxElement("Upgrade?").Bind(bindings, vm => vm.CheckThis),
                        },
                    new Section("Radio")
                        {
                            new RootElement("Dessert", new RadioGroup("Dessert", 0))
                                {
                                    new Section()
                                        {
                                            radioChoices
                                        }
                                }.Bind(bindings, e => e.RadioSelected, vm => vm.CurrentDessertIndex) as Element
                        },
                    new Section("Action")
                        {
                            new ButtonElement("Second").Bind(bindings, element => element.SelectedCommand, vm => vm.GoSecondCommand),
                            new ButtonElement("Bindable Elements").Bind(bindings, element => element.SelectedCommand, vm => vm.BindableElementsCommand),
                            new ButtonElement("Listview dialog").Bind(bindings, element => element.SelectedCommand, vm => vm.GoListViewCommand)  
                        },
                    new Section("Debug out:")
                        {
                            new StringElement("Login is:").Bind(bindings, vm => vm.TextProperty),
                            new StringElement("Password is:").Bind(bindings, vm => vm.PasswordProperty),
                            new StringElement("Remember is:").Bind(bindings, vm => vm.SwitchThis),
                            new StringElement("Upgrade is:").Bind(bindings, vm => vm.CheckThis),
                            new StringElement("Selected Dessert Index is:").Bind(bindings, vm => vm.CurrentDessertIndex),
                        },
                };
        }
    }
}