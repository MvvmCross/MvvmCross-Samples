using System;
using Foundation;
using MvvmCross.Binding.Mac.Views;

namespace XPlatformMenus.Mac.Views
{
	public class BaseView : MvxView
	{
		#region Constructors

		// Called when created from unmanaged code
		public BaseView(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		public BaseView(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion


		public static Random randomGen = new Random();

		public override void AwakeFromNib()
		{
			base.AwakeFromNib();
			WantsLayer = true;
		}

		public override bool WantsUpdateLayer
		{
			get
			{
				return true;
			}
		}

		public override void UpdateLayer()
		{
			base.UpdateLayer();

			Layer.BackgroundColor =
				     new CoreGraphics.CGColor(randomGen.Next(255)/255.0f, randomGen.Next(255)/255.0f, randomGen.Next(255)/255.0f, 255);
		}
	}
}

