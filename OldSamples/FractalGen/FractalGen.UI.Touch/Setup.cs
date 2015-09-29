using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.CrossCore.Converters;
using FractalGen.Core.Services;
using MonoTouch.CoreGraphics;
using Cirrious.CrossCore.IoC;

namespace FractalGen.UI.Touch
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.

				 

	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override Cirrious.MvvmCross.ViewModels.IMvxApplication CreateApp ()
		{
			return new Core.App();
		}

		protected override void InitializeFirstChance()
		{
			CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
			base.InitializeFirstChance();
		}

		public override void LoadPlugins (Cirrious.CrossCore.Plugins.IMvxPluginManager pluginManager)
		{
			pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.Messenger.PluginLoader>();
			base.LoadPlugins (pluginManager);
		}
	}
}
