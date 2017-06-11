using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using OxyPlot.Xamarin.iOS;
using StarWarsSample.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxModalPresentation(WrapInNavigationController = true, ModalTransitionStyle = UIKit.UIModalTransitionStyle.CrossDissolve)]
    public class StatusView : MvxViewController<StatusViewModel>
    {
        private PlotView _plotView;
        private UIBarButtonItem _btnClose;

        public StatusView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _btnClose = new UIBarButtonItem(UIBarButtonSystemItem.Cancel, (sender, e) => DismissViewController(true, null));
            NavigationItem.SetLeftBarButtonItem(_btnClose, false);

            _plotView = new PlotView();

            View.AddSubview(_plotView);
            View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            View.AddConstraints(
                _plotView.AtLeftOf(View),
                _plotView.AtTopOf(View),
                _plotView.AtRightOf(View),
                _plotView.AtBottomOf(View)
            );

            var set = this.CreateBindingSet<StatusView, StatusViewModel>();
            set.Bind(_plotView).For(v => v.Model).To(vm => vm.PlotModel);
            set.Apply();
        }

        public override void DidRotate(UIInterfaceOrientation fromInterfaceOrientation)
        {
            base.DidRotate(fromInterfaceOrientation);
            _plotView.InvalidatePlot(false);
        }
    }
}
