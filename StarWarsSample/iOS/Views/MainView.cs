using System;
using Cirrious.FluentLayouts.Touch;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.ViewModels;
using UIKit;

namespace StarWarsSample.iOS.Views
{
    [MvxRootPresentation]
    public class MainView : MvxTabBarViewController
    {
        //private UILabel _lblPerson;

        public MainView()
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //_lblPerson = new UILabel();

            //View.AddSubview(_lblPerson);
            //View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();

            var set = this.CreateBindingSet<MainView, MainViewModel>();
            set.Apply();
        }
    }
}
