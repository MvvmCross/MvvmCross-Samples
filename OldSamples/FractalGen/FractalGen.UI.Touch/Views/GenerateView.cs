
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using FractalGen.Core.ViewModels;

namespace FractalGen.UI.Touch
{
	public partial class GenerateView : MvxViewController
	{
		public GenerateView ()
			: base ("GenerateView_iPhone", null)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.CreateBinding(this.AutoRunSwitch).To<GenerateViewModel>(vm => vm.AutoPlay).Apply();
			this.CreateBinding(this.RefreshButton).To<GenerateViewModel>(vm => vm.RestartCommand).Apply();
			this.CreateBinding(this.FractalImage).To<GenerateViewModel>(vm => vm.Bitmap)
				.WithConversion("BytesToUIImage").Apply();
		}
	}
}

