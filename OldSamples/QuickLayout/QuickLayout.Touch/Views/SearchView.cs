using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using QuickLayout.Core.ViewModels;
using UIKit;

namespace QuickLayout.Touch.Views
{
    [Register("SearchView")]
    public class SearchView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            var button = new UIButton(UIButtonType.RoundedRect);
            button.SetTitle("Search", UIControlState.Normal);
            Add(button);

            var text = new UITextField() { BorderStyle = UITextBorderStyle.RoundedRect };
            Add(text);

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<SearchView, SearchViewModel>();
            set.Bind(button).To("Search");
            set.Bind(text).To(vm => vm.SearchText);
            set.Apply();

            var hPadding = 10;
            var vPadding = 10;
            var ButtonWidth = 100;

            View.AddConstraints(

                    button.AtTopOf(View).Plus(vPadding),
                    button.AtRightOf(View).Minus(hPadding),
                    button.Width().EqualTo(ButtonWidth),

                    text.AtLeftOf(View, hPadding),
                    text.ToLeftOf(button, hPadding),
                    text.WithSameTop(button)

                );
        }
    }
}