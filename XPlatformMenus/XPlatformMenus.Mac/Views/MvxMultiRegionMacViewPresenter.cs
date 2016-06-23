using System;
using AppKit;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Mac.Views;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform;
using System.Linq;

namespace XPlatformMenus.Mac.Views
{
	public class MvxMultiRegionMacViewPresenter : MvxMacViewPresenter
    {
		public MvxMultiRegionMacViewPresenter(NSApplicationDelegate appDelegate, NSWindow window)
			: base(appDelegate, window)
        {
		}

        public override void Show(MvxViewModelRequest request)
        {
            var viewType = GetViewType(request);

            if (viewType.HasRegionAttribute())
            {
				// where is the view loader?
				var loader = Mvx.Resolve<IMvxMacViewCreator>();
				var view = loader.CreateView(request);
				var viewController = view as NSViewController;

				if (Window.ContentView.Subviews.Any())
				{
					// there should be 1, and it should be the MainView
					var mainView = Window.ContentView.Subviews[0];
					if (mainView is MainView)
					{
						var mainViewController = mainView.NextResponder as MainViewController;
						if (mainViewController != null)
						{
							mainViewController.PlaceView(viewType.GetRegionName(), viewController.View);
						}
					}
					return;
				}
			}
            
            base.Show(request);
        }

        private static Type GetViewType(MvxViewModelRequest request)
        {
            var viewFinder = Mvx.Resolve<IMvxViewsContainer>();
            return viewFinder.GetViewType(request.ViewModelType);
        }
    }
}
