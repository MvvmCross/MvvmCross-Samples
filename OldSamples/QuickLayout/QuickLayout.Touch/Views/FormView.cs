using Cirrious.FluentLayouts;
using Cirrious.FluentLayouts.Touch;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using QuickLayout.Core.ViewModels;

namespace QuickLayout.Touch.Views
{
    [Register("FormView")]
    public class FormView : MvxViewController
    {
        public override void ViewDidLoad()
        {
            View.BackgroundColor = UIColor.White;
            base.ViewDidLoad();

            var fNameLabel = new UILabel {Text = "First"};
            Add(fNameLabel);

            var sNameLabel = new UILabel {Text = "Last"};
            Add(sNameLabel);

            var numberLabel = new UILabel {Text = "#"};
            Add(numberLabel);

            var streetLabel = new UILabel {Text = "Street"};
            Add(streetLabel);

            var townLabel = new UILabel {Text = "Town"};
            Add(townLabel);

            var zipLabel = new UILabel {Text = "Zip"};
            Add(zipLabel);

            var fNameField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(fNameField);

            var sNameField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(sNameField);

            var numberField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(numberField);

            var streetField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(streetField);

            var townField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(townField);

            var zipField = new UITextField() { BackgroundColor = UIColor.LightGray, BorderStyle = UITextBorderStyle.RoundedRect };
            Add(zipField);

            var debug = new UILabel() { BackgroundColor = UIColor.White, Lines = 0 };
            Add(debug);

            var set = this.CreateBindingSet<FormView, FormViewModel>();
            set.Bind(fNameField).To(vm => vm.FirstName);
            set.Bind(sNameField).To(vm => vm.LastName);
            set.Bind(numberField).To(vm => vm.Number);
            set.Bind(streetField).To(vm => vm.Street);
            set.Bind(townField).To(vm => vm.Town);
            set.Bind(zipField).To(vm => vm.Zip);
            set.Bind(debug).To("FirstName  + ' ' + LastName + ', '  + Number + ' ' + Street + ' ' + Town + ' ' + Zip");
            set.Apply();

            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var hMargin = 10;
            var vMargin = 10;


            View.AddConstraints(

                fNameLabel.AtTopOf(View, vMargin),
                fNameLabel.AtLeftOf(View, hMargin),
                fNameLabel.ToLeftOf(sNameLabel, hMargin),

                sNameLabel.WithSameTop(fNameLabel),
                sNameLabel.AtRightOf(View, hMargin),
                sNameLabel.WithSameWidth(fNameLabel),

                fNameField.WithSameWidth(fNameLabel),
                fNameField.WithSameLeft(fNameLabel),
                fNameField.Below(fNameLabel, vMargin),

                sNameField.WithSameLeft(sNameLabel),
                sNameField.WithSameWidth(sNameLabel),
                sNameField.WithSameTop(fNameField),

                numberLabel.WithSameLeft(fNameLabel),
                numberLabel.ToLeftOf(streetLabel, hMargin),
                numberLabel.Below(fNameField, vMargin),
                numberLabel.WithRelativeWidth(streetLabel, 0.3f),

                streetLabel.WithSameTop(numberLabel),
                streetLabel.AtRightOf(View, hMargin),

                numberField.WithSameLeft(numberLabel),
                numberField.WithSameWidth(numberLabel),
                numberField.Below(numberLabel, vMargin),

                streetField.WithSameLeft(streetLabel),
                streetField.WithSameWidth(streetLabel),
                streetField.WithSameTop(numberField),

                townLabel.WithSameLeft(fNameLabel),
                townLabel.WithSameRight(streetLabel),
                townLabel.Below(numberField, vMargin),

                townField.WithSameLeft(townLabel),
                townField.WithSameWidth(townLabel),
                townField.Below(townLabel, vMargin),

                zipLabel.WithSameLeft(fNameLabel),
                zipLabel.WithSameWidth(townLabel),
                zipLabel.Below(townField, vMargin),

                zipField.WithSameLeft(townLabel),
                zipField.WithSameWidth(zipLabel),
                zipField.Below(zipLabel, vMargin),

                debug.WithSameLeft(townLabel),
                debug.WithSameWidth(zipLabel),
                debug.AtBottomOf(View, vMargin)

                );
        }
    }

    /*
     * 
                View.AddConstraints(

                fNameLabel.Left().EqualTo().LeftOf(View).Plus(hMargin),
                fNameLabel.Right().EqualTo().LeftOf(sNameLabel).Minus(hMargin),
                fNameLabel.Top().EqualTo().TopOf(View).Plus(vMargin),
                
                sNameLabel.Top().EqualTo().TopOf(fNameLabel),
                sNameLabel.Right().EqualTo().RightOf(View).Minus(hMargin),
                sNameLabel.Width().EqualTo().WidthOf(fNameLabel),

                fNameField.Left().EqualTo().LeftOf(fNameLabel),
                fNameField.Width().EqualTo().WidthOf(fNameLabel),
                fNameField.Top().EqualTo().BottomOf(fNameLabel).Plus(vMargin),

                sNameField.Left().EqualTo().LeftOf(sNameLabel),
                sNameField.Width().EqualTo().WidthOf(sNameLabel),
                sNameField.Top().EqualTo().TopOf(fNameField),

                numberLabel.Left().EqualTo().LeftOf(fNameLabel),
                numberLabel.Right().EqualTo().LeftOf(streetLabel).Minus(hMargin),
                numberLabel.Top().EqualTo().BottomOf(fNameField).Plus(vMargin),
                numberLabel.Width().EqualTo().WidthOf(streetLabel).WithMultiplier(0.3f),
 
                streetLabel.Top().EqualTo().TopOf(numberLabel),
                streetLabel.Right().EqualTo().RightOf(View).Minus(hMargin),

                numberField.Left().EqualTo().LeftOf(numberLabel),
                numberField.Width().EqualTo().WidthOf(numberLabel),
                numberField.Top().EqualTo().BottomOf(numberLabel).Plus(vMargin),

                streetField.Left().EqualTo().LeftOf(streetLabel),
                streetField.Width().EqualTo().WidthOf(streetLabel),
                streetField.Top().EqualTo().TopOf(numberField),

                townLabel.Left().EqualTo().LeftOf(fNameLabel),
                townLabel.Right().EqualTo().RightOf(streetLabel),
                townLabel.Top().EqualTo().BottomOf(numberField).Plus(vMargin),
               
                townField.Left().EqualTo().LeftOf(townLabel),
                townField.Width().EqualTo().WidthOf(townLabel),
                townField.Top().EqualTo().BottomOf(townLabel).Plus(vMargin),
 
                zipLabel.Left().EqualTo().LeftOf(fNameLabel),
                zipLabel.Width().EqualTo().WidthOf(townLabel),
                zipLabel.Top().EqualTo().BottomOf(townField).Plus(vMargin),
                
                zipField.Left().EqualTo().LeftOf(townLabel),
                zipField.Width().EqualTo().WidthOf(zipLabel),
                zipField.Top().EqualTo().BottomOf(zipLabel).Plus(vMargin),

                debug.Left().EqualTo().LeftOf(townLabel),
                debug.Width().EqualTo().WidthOf(zipLabel),
                debug.Top().EqualTo().BottomOf(zipField).Plus(4 * vMargin)

                );
    */
}