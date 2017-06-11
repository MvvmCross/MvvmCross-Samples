using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = false, TabName = "Menu", TabIconName = "ic_menu")]
    public class MenuView : MvxViewController<MenuViewModel>
    {
        private UIButton _btnStatus;

        public MenuView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            _btnStatus = new UIButton();
            _btnStatus.SetTitleColor(UIColor.Red, UIControlState.Normal);
            _btnStatus.SetTitle("Ver", UIControlState.Normal);

            View.AddSubview(_btnStatus);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _btnStatus.WithSameCenterY(View),
                _btnStatus.WithSameCenterX(View)
            );

            var set = this.CreateBindingSet<MenuView, MenuViewModel>();
            set.Bind(_btnStatus).To(vm => vm.ShowStatusCommand);
            set.Apply();
        }
    }
}
