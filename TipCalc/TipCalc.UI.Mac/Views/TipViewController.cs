using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using MvvmCross.Mac.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.BindingContext;
using TipCalc.Core.ViewModels;

namespace TipCalc.UI.Mac
{
	public partial class TipViewController : MvxViewController
	{
		#region Constructors

		// Called when created from unmanaged code
		public TipViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public TipViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public TipViewController() : base("TipView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<TipViewController, TipViewModel>();
			set.Bind(SubTotalTextField).For(v => v.StringValue).To(vm => vm.SubTotal);
			set.Bind(GenerositySlider).For(v => v.IntValue).To(vm => vm.Generosity);
			set.Bind(TipAmountLabel).For(v => v.StringValue).To(vm => vm.Tip);
			set.Apply();
		}

		//strongly typed view accessor
		public new TipView View
		{
			get
			{
				return (TipView)base.View;
			}
		}
	}
}
