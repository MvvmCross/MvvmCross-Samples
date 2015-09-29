using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace ValueConversion.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        public HomeViewModel()
        {
            Items = new List<MenuItem>
                {
                    new MenuItem<StringsViewModel>(this),
                    new MenuItem<DatesViewModel>(this),
                    new MenuItem<ColorsViewModel>(this),
                    new MenuItem<VisibilityViewModel>(this),
                    new MenuItem<TwoWayViewModel>(this),
                };
        }

        public List<MenuItem> Items { get; private set; }

        private void Show(Type viewModelType)
        {
            ShowViewModel(viewModelType);
        }

        public class MenuItem
        {
            private readonly HomeViewModel _parent;

            public MenuItem(Type viewModelType, HomeViewModel parent)
            {
                Name = viewModelType.Name.Replace("ViewModel", "");
                ViewModelType = viewModelType;
                _parent = parent;
            }

            public string Name { get; private set; }
            public Type ViewModelType { get; private set; }

            public ICommand ShowCommand
            {
                get { return new MvxCommand(() => _parent.Show(ViewModelType)); }
            }
        }

        public class MenuItem<TViewModel> : MenuItem
        {
            public MenuItem(HomeViewModel parent)
                : base(typeof (TViewModel), parent)
            {
            }
        }
    }
}