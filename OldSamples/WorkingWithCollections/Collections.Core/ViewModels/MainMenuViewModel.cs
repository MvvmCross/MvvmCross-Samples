using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Collections.Core.ViewModels.Samples.LargeDynamic;
using Collections.Core.ViewModels.Samples.LargeFixed;
using Collections.Core.ViewModels.Samples.MultipleListItemTypes;
using Collections.Core.ViewModels.Samples.SmallDynamic;
using Collections.Core.ViewModels.Samples.SmallFixed;
using Collections.Core.ViewModels.Samples.SpecificPositions;

namespace Collections.Core.ViewModels
{
    public class MainMenuViewModel : MvxViewModel
    {
        public MainMenuViewModel()
        {
            MenuItems = new List<MenuItem>
                {
                    new MenuItem("Small Fixed Collection", this, typeof (SmallFixedViewModel)),
                    new MenuItem("Small Dynamic Collection", this, typeof (SmallDynamicViewModel)),
                    new MenuItem("Large Fixed Collection", this, typeof (LargeFixedViewModel)),
                    new MenuItem("Large Dynamic Collection", this, typeof (LargeDynamicViewModel)),
                    new MenuItem("Polymorphic Collection", this, typeof (PolymorphicListItemTypesViewModel)),
                    new MenuItem("Specific Positions Collection", this, typeof (SpecificPositionsViewModel)),
                };
        }

        public List<MenuItem> MenuItems { get; private set; }

        public class MenuItem
        {
            public MenuItem(string title, MainMenuViewModel parent, Type viewModelType)
            {
                Title = title;
                ViewModelType = viewModelType;
                ShowCommand = new MvxCommand(() => parent.ShowViewModel(ViewModelType));
            }

            public string Title { get; private set; }
            public Type ViewModelType { get; private set; }
            public ICommand ShowCommand { get; private set; }
        }
    }
}