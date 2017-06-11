using System;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using StarWarsSample.ViewModels;

namespace StarWarsSample.iOS.Views
{
    [MvxTabPresentation(WrapInNavigationController = true, TabName = "Planets", TabIconName = "ic_people")]
    public class PlanetsView : MvxTableViewController<PlanetsViewModel>
    {
        public PlanetsView()
        {
        }
    }
}
