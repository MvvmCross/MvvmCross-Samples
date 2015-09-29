using System.Drawing;
using Babel.Core.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Babel.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            var button = AddButton(0, "Second Page");
            set.Bind(button).To(vm => vm.GoCommand);
            button = AddButton(1, "LolCat");
            set.Bind(button).To(vm => vm.LolCatCommand);
            button = AddButton(2, "English");
            set.Bind(button).To(vm => vm.ProperEnglishCommand);
            button = AddButton(3, "Default");
            set.Bind(button).To(vm => vm.DefaultCommand);
            var label = AddLabel(4);
            label.Text = "Example Text";
            label = AddLabel(5);
            this.BindLanguage(label, "Text", "ExampleText");
            button = AddButton(6, "Force Refresh");
            set.Bind(button).To(vm => vm.ForceTextRefreshCommand);
            set.Apply();
        }

        private UILabel AddLabel(int count)
        {
            var label = new UILabel(new RectangleF(10, 10 + count*40, 300, 40));
            Add(label);
            return label;
        }

        private UIButton AddButton(int count, string title)
        {
            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10, 10 + count*40, 300, 40);
            button.SetTitle(title, UIControlState.Normal);
            Add(button);
            return button;
        }
    }
}