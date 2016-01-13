using MvvmCross.Core.ViewModels;

namespace XPlatformMenus.Touch.Panels
{
    public class PanelPopToRootPresentationHint : MvxPresentationHint
    {
        public readonly PanelEnum Panel;

        public PanelPopToRootPresentationHint(PanelEnum panel)
        {
            Panel = panel;
        }
    }
}
