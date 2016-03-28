using System;
using System.Collections.Generic;
using System.Text;
using JASidePanels;
using UIKit;

namespace XPlatformMenus.Touch.Panels
{
    public class JSSlidePanelSquareController : JASidePanelController
    {
        public override void StylePanel(UIView panel)
        {
            //from https://github.com/gotosleep/JASidePanels/pull/184
            //basically do not apply the base style
            //base.StylePanel(panel);
        }
    }
}
