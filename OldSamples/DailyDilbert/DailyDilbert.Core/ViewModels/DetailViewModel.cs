namespace DailyDilbert.Core.ViewModels
{
    public class DetailViewModel : Cirrious.MvvmCross.ViewModels.MvxViewModel
    {
        public void Init(DilbertItem item)
        {
            Item = item;
        }

        private DilbertItem _dilbertItem;
        public DilbertItem Item
        {
            get { return _dilbertItem; }
            set { _dilbertItem = value; RaisePropertyChanged(() => Item); }
        }        
    }
}