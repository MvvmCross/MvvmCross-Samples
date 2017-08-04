using MvvmCross.Core.ViewModels;

namespace DailyGarfield.Core.ViewModels
{
    public class DetailViewModel : MvxViewModel
    {
        public void Init(GarfieldItem item)
        {
            Item = item;
        }

        private GarfieldItem _GarfieldItem;

        public GarfieldItem Item
        {
            get { return _GarfieldItem; }
            set { _GarfieldItem = value; RaisePropertyChanged(() => Item); }
        }
    }
}