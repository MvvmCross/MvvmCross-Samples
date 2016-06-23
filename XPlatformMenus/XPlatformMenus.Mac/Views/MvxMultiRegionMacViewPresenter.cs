using System;
using AppKit;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Mac.Views;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform;

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

				var mainViewController = Window.ContentViewController as MainViewController;
				if (mainViewController != null)
				{
					var targetViewController = view as NSViewController;

					mainViewController.PlaceView(viewType.GetRegionName(), targetViewController.View);
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
