﻿using MvvmCross.Core.ViewModels;
using MvvmCross.WindowsUWP.Views;

namespace XPlatformMenus.UWP.Views
{
    public class CustomViewPresenter : MvxWindowsMultiRegionViewPresenter
    {
        IMvxWindowsFrame _rootFrame;

        public CustomViewPresenter(IMvxWindowsFrame rootFrame)
            : base(rootFrame)
        {
            _rootFrame = rootFrame;

        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxPanelPopToRootPresentationHint)
            {
                var mainView = _rootFrame.Content as MainView;
                if (mainView != null)
                {
                    mainView.PopToRoot();
                }
            }

            base.ChangePresentation(hint);
        }
    }
}
