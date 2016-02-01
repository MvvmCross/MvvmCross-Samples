using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using InternetMinute.Core.ViewModels;

namespace InternetMinute.Touch.Views
{
	public partial class DescriptionCell : MvxTableViewCell
	{
		public static readonly NSString Key = new NSString ("DescriptionCell");
		public static readonly UINib Nib;

		private readonly MvxImageViewLoader _loader;

		static DescriptionCell ()
		{
			Nib = UINib.FromName ("DescriptionCell", NSBundle.MainBundle);
		}

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
	}
}
