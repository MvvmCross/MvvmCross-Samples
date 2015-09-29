using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Babel.Touch.Views
{
    [Register("SecondView")]
    public class SecondView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View = new UIView() { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

            var label = AddLabel(0);
            this.BindLanguage(label, "Text", "PageTitle");
            label = AddLabel(1);
            this.BindLanguage(label, "Text", "Body1");
            label = AddLabel(2);
            this.BindLanguage(label, "Text", "Body2");
        }

        private UILabel AddLabel(int count)
        {
            var label = new UILabel(new RectangleF(10, 10 + count * 40, 300, 40));
            Add(label);
            return label;
        }
    }
}