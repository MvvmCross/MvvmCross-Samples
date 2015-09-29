using System;
using System.Collections.Generic;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;

namespace DailyDilbert.Core.ViewModels
{
    public class ListViewModel : Cirrious.MvvmCross.ViewModels.MvxViewModel
    {
        private readonly IDilbertService _dilbertService;

        public ListViewModel(IDilbertService dilbertService)
        {
            _dilbertService = dilbertService;
        }

        public override void Start()
        {
            IsLoading = true;
            _dilbertService.GetFeedItems(OnDilbertItems, OnError);
        }

        private void OnDilbertItems(List<DilbertItem> list)
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

        private List<DilbertItem> _items;
        public List<DilbertItem> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }

        private Cirrious.MvvmCross.ViewModels.MvxCommand<DilbertItem> _itemSelectedCommand;
        public System.Windows.Input.ICommand ItemSelectedCommand
        {
            get
            {
                _itemSelectedCommand = _itemSelectedCommand ?? new Cirrious.MvvmCross.ViewModels.MvxCommand<DilbertItem>(DoSelectItem);
                return _itemSelectedCommand;
            }
        }

        private void DoSelectItem(DilbertItem item)
        {
            ShowViewModel<DetailViewModel>(item);
        }
    }
}
