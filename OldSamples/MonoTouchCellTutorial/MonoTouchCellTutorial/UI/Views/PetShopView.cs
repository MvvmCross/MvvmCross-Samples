using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouchCellTutorial.Core.ViewModels;
using MonoTouchCellTutorial.Core.Models.Kittens;
using MonoTouchCellTutorial.Core.Models.Dogs;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Touch.Views;

namespace MonoTouchCellTutorial
{
	public partial class PetShopView : MvxViewController
	{
		public new PetShopViewModel ViewModel
		{
			get { return (PetShopViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public PetShopView () 
			: base ("PetShopView", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			var source = new TableSource(TableView);

			this.CreateBinding(source).To((PetShopViewModel vm) => vm.Stock).Apply ();

			TableView.Source = source;
			TableView.ReloadData();
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		partial void OnAddAnimalsClick (MonoTouch.Foundation.NSObject sender)
		{
			var sheet = new UIActionSheet("Add Animals");
			sheet.AddButton("Add Dog");
			sheet.AddButton("Add Kitten");
			sheet.Clicked += HandleAddAnimalClicked;
			sheet.ShowInView(this.View);
		}

		void HandleAddAnimalClicked (object sender, UIButtonEventArgs e)
		{
			switch (e.ButtonIndex) {
			case 0:
				ViewModel.AddDogCommand.Execute(null);
				return;
			case 1:
				ViewModel.AddKittenCommand.Execute(null);
				return;
			}
		}

		public class TableSource : MvxTableViewSource
		{
			public TableSource (UITableView tableView)
				: base(tableView)
			{
				UseAnimations = true;
				AddAnimation = UITableViewRowAnimation.Top;
				RemoveAnimation = UITableViewRowAnimation.Middle;

				tableView.RegisterNibForCellReuse(UINib.FromName("KittenCell", NSBundle.MainBundle), KittenCell.Identifier);
				tableView.RegisterNibForCellReuse(UINib.FromName("DogCell", NSBundle.MainBundle), DogCell.Identifier);
			}

			public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				var item = (PetShopAnimalViewModel)GetItemAt (indexPath);
				if (item.Animal is Kitten) {
					return 95.0f;
				}
				if (item.Animal is Dog) {
					return 160.0f;
				}

				throw new Exception("Oh dear");
			}

			protected override UITableViewCell GetOrCreateCellFor (UITableView tableView, NSIndexPath indexPath, object item)
			{
				var viewModel = (PetShopAnimalViewModel)item;

				NSString identifier = KittenCell.Identifier;
				if (viewModel.Animal is Kitten) {
					identifier = KittenCell.Identifier;
				}
				if (viewModel.Animal is Dog) {
					identifier = DogCell.Identifier;
				}

				return (UITableViewCell)tableView.DequeueReusableCell(identifier, indexPath);
			}
		}
	}
}

