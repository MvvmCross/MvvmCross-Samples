
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using InternetMinute.Core.Services.Times;
using InternetMinute.Core.ViewModels;

namespace InternetMinute.Touch
{
	public partial class DescriptionCell : MvxTableViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("DescriptionCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("DescriptionCell");

		private readonly MvxImageViewLoader _loader;

		public DescriptionCell (IntPtr handle) : base (handle)
		{
			_loader = new MvxImageViewLoader(() => this.MainImage);

			this.DelayBind(() => 
			               {
				this.CreateBinding(this.NameLabel).To<DescriptionViewModel>(vm => vm.Description.Name).Apply();
				this.CreateBinding(this.CountLabel).To<DescriptionViewModel>(vm => vm.Count).Apply();
				this.CreateBinding(this._loader).To<DescriptionViewModel>(vm => vm.Description.LogoUrl).Apply();

			});
		}
		
		public static DescriptionCell Create ()
		{
			return (DescriptionCell)Nib.Instantiate (null, null) [0];
		}
	}
}

