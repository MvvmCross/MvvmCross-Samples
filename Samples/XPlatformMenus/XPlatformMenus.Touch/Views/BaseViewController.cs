using Cirrious.MvvmCross.Touch.Views;
using UIKit;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Touch.Views
{
    /// <summary>
    /// A base view
    /// </summary>
    public class BaseViewController<TViewModel> : MvxViewController where TViewModel : BaseVm
    {
        #region Fields

        protected bool NavigationBarEnabled = false;

        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }

        #endregion

        #region Public Methods

        public override void ViewDidLoad()
        {
            EdgesForExtendedLayout = UIRectEdge.None;
            View.BackgroundColor = UIColor.White;

            base.ViewDidLoad();
        }

        #endregion
    }
}