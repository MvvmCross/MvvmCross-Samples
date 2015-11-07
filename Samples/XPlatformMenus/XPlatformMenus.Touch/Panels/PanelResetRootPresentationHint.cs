using Cirrious.MvvmCross.ViewModels;

namespace XPlatformMenus.Touch.Panels
{
    public class PanelResetRootPresentationHint : MvxPresentationHint
    {
        public readonly PanelEnum Panel;

        public PanelResetRootPresentationHint(PanelEnum panel)
        {
            Panel = panel;
        }
    }
}
