using DailyDilbert.Core.ViewModels;
using System;
using MvvmCross.iOS.Views;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace DailyDilbert.Touch
{
    public partial class DetailView : MvxViewController
    {
        private MvxImageViewLoader _loader;

        private static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public DetailView()
            : base(UserInterfaceIdiomIsPhone ? "DetailView_iPhone" : "DetailView_iPad", null)
        {
            _loader = new MvxImageViewLoader(() => this.StripImage);
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //rotate rect
            StripImage.Transform = CoreGraphics.CGAffineTransform.MakeRotation((float)Math.PI / 2);

            // Perform any additional setup after loading the view, typically from a nib.
            this.CreateBinding(_loader).To<DetailViewModel>(vm => vm.Item.StripUrl).Apply();
            this.CreateBinding().For(p => p.Title).To<DetailViewModel>(vm => vm.Item.Title).Apply();
        }
    }
}