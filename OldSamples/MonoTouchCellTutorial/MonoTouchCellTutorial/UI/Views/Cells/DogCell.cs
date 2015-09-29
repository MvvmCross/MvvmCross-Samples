using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Plugins.DownloadCache;
using System.Windows.Input;

namespace MonoTouchCellTutorial
{
	[Register("DogCell")]
	public partial class DogCell : MvxTableViewCell
	{
		public static readonly NSString Identifier = new NSString("DogCell");
		
		public const string BindingText = @"
NameText Animal.Name; 
Price Price; 
IsGoodWithChildren Animal.GoodWithChildren;
ImageUrl Animal.ImageUrl;
SellCommand SellCommand";
		
		public DogCell ()
			: base(BindingText)
		{
			InitialiseImageHelper();		
		}
		
		public DogCell (IntPtr handle)
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
		
		public bool IsGoodWithChildren {
			get {
				return !this.GoodWithChildrenLabel.Hidden;
			}
			set {
				this.GoodWithChildrenLabel.Hidden = !value;
			}
		}

		public string ImageUrl {
			get { return _imageHelper.ImageUrl; }
			set { _imageHelper.ImageUrl = value; }
		}
		
		private MvxImageViewLoader _imageHelper;

		private void InitialiseImageHelper()
		{
			_imageHelper = new MvxImageViewLoader(() => DogImageView);
		}

		public ICommand SellCommand { get; set; }

		partial void DeleteButtonAction (MonoTouch.Foundation.NSObject sender)
		{
			SellCommand.Execute(null);
		}

	}
}
