using Cirrious.MvvmCross.Localization;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;

namespace Babel.Touch
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
		{
		}

        protected override System.Collections.Generic.List<System.Reflection.Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies;
                toReturn.Add(typeof(MvxLanguageConverter).Assembly);
                return toReturn;
            }
        }

        protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp()
		{
			return new Core.App();
		}
	}
}