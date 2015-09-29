
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using DailyDilbert.Core.ViewModels;

namespace DailyDilbert.Touch
{
	public partial class DetailView : MvxViewController
	{
		MvxImageViewLoader _loader;
		
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public DetailView ()
			: base (UserInterfaceIdiomIsPhone ? "DetailView_iPhone" : "DetailView_iPad", null)
		{
			_loader = new MvxImageViewLoader(() => this.StripImage);
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			//rotate rect
			StripImage.Transform = MonoTouch.CoreGraphics.CGAffineTransform.MakeRotation((float)Math.PI / 2);

			// Perform any additional setup after loading the view, typically from a nib.
			this.CreateBinding(_loader).To<DetailViewModel>(vm => vm.Item.StripUrl).Apply();
			this.CreateBinding().For(p => p.Title).To<DetailViewModel>(vm => vm.Item.Title).Apply();
		}
	}
}

