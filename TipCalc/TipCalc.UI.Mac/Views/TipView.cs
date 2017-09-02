using System;
using Foundation;
using MvvmCross.Binding.Mac.Views;

namespace TipCalc.UI.Mac.Views
{
	public partial class TipView : MvxView
	{
		#region Constructors

		// Called when created from unmanaged code
		public TipView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public TipView(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion
	}
}
