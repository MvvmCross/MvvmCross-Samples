using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using TipCalc.Core.ViewModels;
using UIKit;

namespace TipCalc.UI.Touch.Views
{
    public partial class TipView : MvxViewController
    {
        public new TipViewModel ViewModel
        {
            get { return (TipViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        public TipView()
            : base("TipView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            this.CreateBinding(TipLabel).To((TipViewModel vm) => vm.Tip).Apply();
            this.CreateBinding(SubTotalTextField).To((TipViewModel vm) => vm.SubTotal).Apply();
            this.CreateBinding(GenerositySlider).To((TipViewModel vm) => vm.Generosity).Apply();

            View.AddGestureRecognizer(new UITapGestureRecognizer(() => { SubTotalTextField.ResignFirstResponder(); }));
        }
    }
}