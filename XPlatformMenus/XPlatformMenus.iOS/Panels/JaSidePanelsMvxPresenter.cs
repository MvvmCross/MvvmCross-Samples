using System.Linq;
using JASidePanels;
using UIKit;
using MvvmCross.iOS.Views.Presenters;

// based on code from Matthew Waring and using the JASidePanel Component
// https://matthewwaring.wordpress.com/2015/10/21/jasidepanels-and-mvvmcross-ios-slide-out-menu/
// https://components.xamarin.com/view/jasidepanels
using MvvmCross.iOS.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.Platform;
using MvvmCross.Core.Views;


namespace XPlatformMenus.Touch.Panels
{
    public class JaSidePanelsMvxPresenter : MvxIosViewPresenter
    {
        private UIViewController _currentModalViewController;

        private readonly JASidePanelController _jaSidePanelController;
        private PanelEnum _activePanel;

        private UINavigationController CentrePanelUiNavigationController()
        {
            return ((UINavigationController)_jaSidePanelController.CenterPanel);
        }

        private UINavigationController RightPanelUiNavigationController()
        {
            return ((UINavigationController)_jaSidePanelController.RightPanel);
        }

        private UINavigationController LeftPanelUiNavigationController()
        {
            return ((UINavigationController)_jaSidePanelController.LeftPanel);
        }

        private UINavigationController GetActivePanelUiNavigationController
        {
            get
            {
                switch (_activePanel)
                {
                    case PanelEnum.Center:
                        return CentrePanelUiNavigationController();
                    case PanelEnum.Left:
                        return LeftPanelUiNavigationController();
                    case PanelEnum.Right:
                        return RightPanelUiNavigationController();
                }

                return CentrePanelUiNavigationController();
            }
        }

        public override void Show(IMvxIosView view)
        {
            Trc.Mn("IMvxTouchView");

            // Handle modal first
            // This will use our TopLevel UINavigation Controller, to present over the top of the Panels UX
            if (view is IMvxModalIosView)
            {
                if (_currentModalViewController != null)
                {
                    throw new MvxException("Only one modal view controller at a time supported");
                }

                _currentModalViewController = view as UIViewController;
                PresentModalViewController(view as UIViewController, true);
                return;
            }

            // Then handle panels 
            UIViewController viewController = view as UIViewController;
            if (viewController == null)
            {
                throw new MvxException("Passed in IMvxTouchView is not a UIViewController");
            }

            if (MasterNavigationController == null)
            {
                ShowFirstView(viewController);
            }
            else
            {
                // here we need to get the Presentation Panel attribute details from the custom attribute
                var panelAttribute = viewController.GetType().GetCustomAttributes(typeof(PanelPresentationAttribute), true).FirstOrDefault() as PanelPresentationAttribute;
                if (panelAttribute != null)
                {
                    switch (panelAttribute.HintType)
                    {
                        case PanelHintType.ActivePanel:
                            ChangePresentation(new ActivePanelPresentationHint(panelAttribute.Panel, panelAttribute.ShowPanel));
                            break;
                        case PanelHintType.PopToRoot:
                            ChangePresentation(new PanelPopToRootPresentationHint(panelAttribute.Panel));
                            break;
                        case PanelHintType.ResetRoot:
                            ChangePresentation(new PanelResetRootPresentationHint(panelAttribute.Panel));
                            break;
                    }
                }

                if (GetActivePanelUiNavigationController == null)
                {
                    // If we have cleared down our panel completely, then we will be setting a new root view
                    // this is perfect for Menu items 
                    switch (_activePanel)
                    {
                        case PanelEnum.Center:
                            _jaSidePanelController.CenterPanel = new UINavigationController(viewController);
                            break;
                        case PanelEnum.Left:
                            _jaSidePanelController.LeftPanel = new UINavigationController(viewController);
                            break;
                        case PanelEnum.Right:
                            _jaSidePanelController.RightPanel = new UINavigationController(viewController);
                            break;
                    }
                }
                else
                {
                    // Otherwise we just want to push to the designated panel 
                    GetActivePanelUiNavigationController.PushViewController(viewController, true);
                }
            }
        }

        public override void NativeModalViewControllerDisappearedOnItsOwn()
        {
            if (_currentModalViewController != null)
            {
                MvxTrace.Error("How did a modal disappear when we didn't have one showing?");
            }
            else
            {
                _currentModalViewController = null;
            }
        }

        public override void CloseModalViewController()
        {
            if (_currentModalViewController != null)
            {
                _currentModalViewController.DismissModalViewController(true);
                _currentModalViewController = null;
            }
            else
            {
                base.CloseModalViewController();
            }
        }

        public JaSidePanelsMvxPresenter(UIApplicationDelegate applicationDelegate, UIWindow window) :
            base(applicationDelegate, window)
        {
            _jaSidePanelController = new JASidePanelController();
            _activePanel = PanelEnum.Center;
        }

        protected override void ShowFirstView(UIViewController viewController)
        {
            Trc.Mn();

            // Creates our top level UINavigationController as standard
            base.ShowFirstView(viewController);

            // So lets push our JaSidePanels viewController and then our first viewController in the centre panel to start things off
            // We will let our initial viewmodel load up the panels as required
            MasterNavigationController.NavigationBarHidden = true;
            MasterNavigationController.PushViewController(_jaSidePanelController, false);
            _jaSidePanelController.CenterPanel = new UINavigationController(viewController);
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            ProcessActivePanelPresentation(hint);
            ProcessResetRootPresentation(hint);
            ProcessPopToRootPresentation(hint);

            base.ChangePresentation(hint);
        }

        private void ProcessActivePanelPresentation(MvxPresentationHint hint)
        {
            var activePresentationHint = hint as ActivePanelPresentationHint;
            if (activePresentationHint != null)
            {
                var panelHint = activePresentationHint;

                _activePanel = panelHint.ActivePanel;

                if (panelHint.ShowPanel)
                {
                    ShowPanel(panelHint.ActivePanel);
                }
            }
        }

        private void ProcessPopToRootPresentation(MvxPresentationHint hint)
        {
            var popHint = hint as PanelPopToRootPresentationHint;
            if (popHint != null)
            {
                var panelHint = popHint;

                switch (panelHint.Panel)
                {
                    case PanelEnum.Center:
                        if (CentrePanelUiNavigationController() != null)
                            CentrePanelUiNavigationController().PopToRootViewController(false);
                        break;
                    case PanelEnum.Left:
                        if (LeftPanelUiNavigationController() != null)
                            LeftPanelUiNavigationController().PopToRootViewController(false);
                        break;
                    case PanelEnum.Right:
                        if (RightPanelUiNavigationController() != null)
                            RightPanelUiNavigationController().PopToRootViewController(false);
                        break;
                }
            }
        }

        private void ProcessResetRootPresentation(MvxPresentationHint hint)
        {
            var popHint = hint as PanelResetRootPresentationHint;
            if (popHint != null)
            {
                var panelHint = popHint;

                switch (panelHint.Panel)
                {
                    case PanelEnum.Center:
                        _jaSidePanelController.CenterPanel = null;
                        break;
                    case PanelEnum.Left:
                        _jaSidePanelController.LeftPanel = null;
                        break;
                    case PanelEnum.Right:
                        _jaSidePanelController.RightPanel = null;
                        break;
                }
            }
        }

        private void ShowPanel(PanelEnum panel)
        {
            switch (panel)
            {
                case PanelEnum.Center:
                    _jaSidePanelController.ShowCenterPanelAnimated(true);
                    break;
                case PanelEnum.Left:
                    _jaSidePanelController.ShowLeftPanelAnimated(true);
                    break;
                case PanelEnum.Right:
                    _jaSidePanelController.ShowRightPanelAnimated(true);
                    break;
            }
        }

        public override void Close(IMvxViewModel toClose)
        {
            if (_currentModalViewController != null)
            {
				IMvxIosView mvxTouchView = _currentModalViewController as IMvxIosView;
                if (mvxTouchView == null)
                    MvxTrace.Error("Unable to close view - modal is showing but not an IMvxTouchView");
                else if (mvxTouchView.ReflectionGetViewModel() != toClose)
                {
                    MvxTrace.Error("Unable to close view - modal is showing but is not the requested viewmodel");
                }
                else
                {
                    // ISSUE: reference to a compiler-generated method
                    _currentModalViewController.DismissViewController(true, () => { });
                    _currentModalViewController = null;
                }

                return;
            }

            // We will look across all active navigation stacks to see if we can
            // pop our MvxView associated with this MvxViewModel (saves explicitly having to specify)            
            bool modelClosed = CloseTopView(toClose, CentrePanelUiNavigationController());
            if (!modelClosed) modelClosed = CloseTopView(toClose, LeftPanelUiNavigationController());
            if (!modelClosed) modelClosed = CloseTopView(toClose, RightPanelUiNavigationController());

            if (!modelClosed)
            {
                MvxTrace.Warning("Don't know how to close this viewmodel - none of topmost views represent this viewmodel");
            }
        }

        /// <summary>
        /// See if the supplied ViewModel matches up with the MvxView at the top of the supplied UINavigationController
        /// and if so, pop that View from the stack
        /// </summary>
        private bool CloseTopView(IMvxViewModel toClose, UINavigationController uiNavigationController)
        {
            if (uiNavigationController == null)
            {
                return false;
            }

			IMvxIosView mvxTouchView = uiNavigationController.TopViewController as IMvxIosView;

            if (mvxTouchView == null)
            {
                return false;
            }

            if (mvxTouchView.ReflectionGetViewModel() != toClose)
            {
                return false;
            }

            uiNavigationController.PopViewController(true);

            return true;
        }
    }
}
