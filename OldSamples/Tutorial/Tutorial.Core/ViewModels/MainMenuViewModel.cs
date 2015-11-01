using Cirrious.MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Tutorial.Core.ViewModels
{
    public class MainMenuViewModel
        : MvxViewModel
    {
        public List<Type> Items { get; set; }

        public ICommand ShowItemCommand
        {
            get
            {
                return new MvxCommand<Type>((type) => DoShowItem(type));
            }
        }

        public void DoShowItem(Type itemType)
        {
            this.ShowViewModel(itemType);
        }

        public MainMenuViewModel()
        {
            Items = new List<Type>()
                        {
                            typeof(Lessons.SimpleTextPropertyViewModel),
                            typeof(Lessons.PullToRefreshViewModel),
                            typeof(Lessons.TipViewModel),
                            typeof(Lessons.CompositeViewModel),
                            typeof(Lessons.LocationViewModel)
                        };
        }
    }
}