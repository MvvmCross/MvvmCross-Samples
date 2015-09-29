using System;
using Cirrious.MvvmCross.ViewModels;

namespace ValueConversion.Core.ViewModels
{
    public class DatesViewModel : MvxViewModel
    {
        private DateTime _oldDate;
        private DateTime _theDate;
        private DateTime _veryOldDate;

        public DatesViewModel()
        {
            _theDate = DateTime.UtcNow;
            _oldDate = DateTime.UtcNow.Add(-TimeSpan.FromMinutes(33.0));
            _veryOldDate = DateTime.UtcNow.Add(-TimeSpan.FromDays(4.0));
        }

        public DateTime TheDate
        {
            get { return _theDate; }
            set
            {
                _theDate = value;
                RaisePropertyChanged(() => TheDate);
            }
        }

        public DateTime OldDate
        {
            get { return _oldDate; }
            set
            {
                _oldDate = value;
                RaisePropertyChanged(() => OldDate);
            }
        }

        public DateTime VeryOldDate
        {
            get { return _veryOldDate; }
            set
            {
                _veryOldDate = value;
                RaisePropertyChanged(() => VeryOldDate);
            }
        }
    }
}