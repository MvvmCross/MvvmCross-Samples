using System;

namespace XPlatformMenus.Touch.Panels
{
    public class PanelPresentationAttribute : Attribute
    {
        public readonly PanelEnum Panel;
        public readonly PanelHintType HintType;
        public readonly bool ShowPanel;

        public PanelPresentationAttribute(PanelEnum panel, PanelHintType hintType, bool showPanel)
        {
            Panel = panel;
            ShowPanel = showPanel;
            HintType = hintType;
        }
    }
}