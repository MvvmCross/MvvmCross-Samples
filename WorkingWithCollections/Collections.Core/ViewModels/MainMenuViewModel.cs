using Collections.Core.ViewModels.Samples.LargeDynamic;
using Collections.Core.ViewModels.Samples.LargeFixed;
using Collections.Core.ViewModels.Samples.MultipleListItemTypes;
using Collections.Core.ViewModels.Samples.SmallDynamic;
using Collections.Core.ViewModels.Samples.SmallFixed;
using Collections.Core.ViewModels.Samples.SpecificPositions;
using Collections.Core.ViewModels.Samples.Expandable;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Navigation;
using MvvmCross.Platform;

namespace Collections.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        readonly IMvxNavigationService NavigationService;

        public MainMenuViewModel()
        {
            NavigationService = Mvx.Resolve<IMvxNavigationService>();

            MenuItems = new List<MenuItem>
            {
                new MenuItem("Small Fixed Collection", this, nameof(SmallFixedViewModel)),
                new MenuItem("Small Dynamic Collection", this, nameof(SmallDynamicViewModel)),
                new MenuItem("Large Fixed Collection", this, nameof(LargeFixedViewModel)),
                new MenuItem("Large Dynamic Collection", this, nameof(LargeDynamicViewModel)),
                new MenuItem("Polymorphic Collection", this, nameof(PolymorphicListItemTypesViewModel)),
                new MenuItem("Specific Positions Collection", this, nameof(SpecificPositionsViewModel)),
                new MenuItem("Expandable Collection", this, nameof(ExpandableViewModel)),
            };
        }

        public List<MenuItem> MenuItems { get; private set; }

        public class MenuItem
        {
            public MenuItem(string title, MainMenuViewModel parent, string viewModelUrl)
            {
                Title = title;
                // Will change to navigate to type once https://github.com/MvvmCross/MvvmCross/pull/2148 is in.
                ShowCommand = new MvxCommand(() => parent.NavigationService.Navigate(viewModelUrl));
            }

            public string Title { get; private set; }
            public ICommand ShowCommand { get; private set; }
        }
    }
}