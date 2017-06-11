using System;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.ViewModels;

namespace StarWarsSample.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = false, TabName = "Menu", TabIconName = "ic_menu")]
    public class MenuView : MvxViewController<MenuViewModel>
    {
        public MenuView()
        {
        }
    }
}
