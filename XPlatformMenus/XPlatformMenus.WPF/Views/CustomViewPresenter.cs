using MvvmCross.Core.ViewModels;
using MvvmCross.Wpf.Views;
using System.Windows.Controls;

namespace XPlatformMenus.WPF.Views
{
    public class CustomViewPresenter : MvxMultiRegionWpfViewPresenter
    {
        ContentControl _contentControl;

        public CustomViewPresenter(ContentControl contentControl)
            : base(contentControl)
        {
            _contentControl = contentControl;
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is MvxPanelPopToRootPresentationHint)
            {
                var mainView = _contentControl.Content as MainView;
                if (mainView != null)
                {
                    mainView.PopToRoot();
                }
            }

            base.ChangePresentation(hint);
        }
    }
}
