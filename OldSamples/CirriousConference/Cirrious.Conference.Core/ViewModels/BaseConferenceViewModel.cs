using Cirrious.Conference.Core.Interfaces;
using MvvmCross.Platform;
using MvvmCross.Plugins.Messenger;

namespace Cirrious.Conference.Core.ViewModels
{
    public class BaseConferenceViewModel
        : BaseViewModel

    {
        private MvxSubscriptionToken _mvxSubscription;

        public BaseConferenceViewModel()
        {
            _mvxSubscription = Subscribe<LoadingChangedMessage>(message => RepositoryOnLoadingChanged());
        }

        public IConferenceService Service
        {
            get { return Mvx.Resolve<IConferenceService>(); }
        }

        public bool IsLoading
        {
            get { return Service.IsLoading; }
        }

        protected virtual void RepositoryOnLoadingChanged()
        {
            RaisePropertyChanged(() => IsLoading);
        }
    }
}