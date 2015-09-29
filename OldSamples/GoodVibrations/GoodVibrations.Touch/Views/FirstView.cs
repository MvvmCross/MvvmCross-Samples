using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace GoodVibrations.Touch.Views
{
    [Register("FirstView")]
    public class FirstView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView(){ BackgroundColor = UIColor.White};
            base.ViewDidLoad();

            //var label = new UILabel(new RectangleF(10, 10, 300, 40));
            //Add(label);
            //var textField = new UITextField(new RectangleF(10, 50, 300, 40));
            //Add(textField);
            var button = new UIButton(UIButtonType.RoundedRect);
            button.Frame = new RectangleF(10, 50, 300, 40);
            button.SetTitle("Shake", UIControlState.Normal);
            Add(button);

            var set = this.CreateBindingSet<FirstView, Core.ViewModels.FirstViewModel>();
            //set.Bind(label).To(vm => vm.Hello);
            //set.Bind(textField).To(vm => vm.Hello);
            set.Bind(button).To(vm => vm.ShakeCommand);
            set.Apply();
        }
    }
}