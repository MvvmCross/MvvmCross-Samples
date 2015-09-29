using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Plugins.DownloadCache;
using Cirrious.MvvmCross.Platform;
using System.Windows.Input;

namespace MonoTouchCellTutorial
{
	[Register("KittenCell")]
	public partial class KittenCell : MvxTableViewCell
	{
		public static readonly NSString Identifier = new NSString("KittenCell");

		public const string BindingText = @"
NameText Animal.Name; 
Price Price; 
IsLitterTrained Animal.LitterTrained;
ImageUrl Animal.ImageUrl;
IncreaseCommand IncreasePrice;
DecreaseCommand DecreasePrice";

		public KittenCell ()
			: base(BindingText)
		{
			InitialiseImageHelper();		
		}

		public KittenCell (IntPtr handle)
			: base(BindingText, handle)
		{
			InitialiseImageHelper();		
		}

		public string NameText {
			get { return this.NameLabel.Text; }
			set { this.NameLabel.Text = value; }
		}

		public int Price {
			get {
				int price;
				Int32.TryParse (this.PriceLabel.Text, out price);
				return price;
			}
			set {
				this.PriceLabel.Text = value.ToString ();
			}
		}

		public bool IsLitterTrained {
			get {
				return !this.LitterTrainedLabel.Hidden;
			}
			set {
				this.LitterTrainedLabel.Hidden = !value;
			}
		}

		public string ImageUrl {
			get { return _imageHelper.ImageUrl; }
			set { _imageHelper.ImageUrl = value; }
		}
		
		private MvxImageViewLoader _imageHelper;
		
		private void InitialiseImageHelper()
		{
			_imageHelper = new MvxImageViewLoader(() => KittenImageView);
		}
		

		public ICommand IncreaseCommand {get;set;}
		public ICommand DecreaseCommand {get;set;}

		partial void IncreasePriceAction (MonoTouch.Foundation.NSObject sender)
		{
			IncreaseCommand.Execute(null);
		}
		
		partial void DecreasePriceAction (MonoTouch.Foundation.NSObject sender)
		{
			DecreaseCommand.Execute(null);
		}
	}
}

