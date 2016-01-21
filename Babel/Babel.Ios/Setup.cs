using MvvmCross.iOS.Platform;
using UIKit;
using MvvmCross.Localization;
using System.Collections.Generic;
using System.Linq;


namespace Babel.Touch
{
	public class Setup : MvxIosSetup
	{
		public Setup (MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base (applicationDelegate, window)
		{
		}

		protected override IEnumerable<System.Reflection.Assembly> ValueConverterAssemblies {
			get {
				var toReturn = base.ValueConverterAssemblies.ToList ();
				toReturn.Add (typeof(MvxLanguageConverter).Assembly);
				return toReturn;
			}
		}

		protected override MvvmCross.Core.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App ();
		}
	}
}