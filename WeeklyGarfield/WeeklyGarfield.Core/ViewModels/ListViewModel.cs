using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;

namespace DailyGarfield.Core.ViewModels
{
    public class ListViewModel : MvxViewModel
    {
        private readonly IGarfieldService _GarfieldService;

        public ListViewModel(IGarfieldService GarfieldService)
        {
            _GarfieldService = GarfieldService;
        }

        public override void Start()
        {
            IsLoading = true;
            _GarfieldService.GetFeedItems(OnGarfieldItems, OnError);
        }

        private void OnGarfieldItems(List<GarfieldItem> list)
        {
            IsLoading = false;
            Items = list;
        }

        private void OnError(Exception error)
        {
            // not reported for now
            IsLoading = false;
        }

        private bool _isLoading;

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; RaisePropertyChanged(() => IsLoading); }
        }

        private List<GarfieldItem> _items;

        public List<GarfieldItem> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        private MvxCommand<GarfieldItem> _itemSelectedCommand;

        public System.Windows.Input.ICommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<GarfieldItem>(DoSelectItem);
                return _itemSelectedCommand;
            }
        }

        private void DoSelectItem(GarfieldItem item)
        {
            ShowViewModel<DetailViewModel>(item);
        }
    }
}