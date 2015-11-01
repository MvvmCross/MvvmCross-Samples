using Cirrious.Conference.UI.Touch.Interfaces;

namespace Cirrious.Conference.UI.Touch
{
    public class ConferencePresenter
        : MvxModalSupportTouchViewPresenter
        , ITabBarPresenterHost
    {
        public ConferencePresenter(UIApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override UINavigationController CreateNavigationController(UIViewController viewController)
        {
            var toReturn = base.CreateNavigationController(viewController);
            toReturn.NavigationBarHidden = true;
            return toReturn;
        }

        public ITabBarPresenter TabBarPresenter { get; set; }

        public override void Show(IMvxTouchView view)
        {
            if (TabBarPresenter != null && view != TabBarPresenter)
            {
                TabBarPresenter.ShowView(view);
                return;
            }

            base.Show(view);
        }
    }
}