using InternetMinute.Core.Services.Times;
using MvvmCross.Core.ViewModels;

namespace InternetMinute.Core.ViewModels
{
    public class DescriptionViewModel : MvxViewModel
    {
        private long _count;

        public DescriptionViewModel(Description description)
        {
            Description = description;
        }

        public Description Description { get; private set; }

        public long Count
        {
            get { return _count; }
            private set { _count = value; RaisePropertyChanged(() => Count); }
        }

        public void Update(double numMinutes)
        {
            Count = (long)(numMinutes * (double)Description.PerMinute);
        }
    }
}