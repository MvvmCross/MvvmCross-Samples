using System;
using System.Collections.Generic;
using System.Linq;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using InternetMinute.Core.Services.Times;

namespace InternetMinute.Core.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
        private MvxSubscriptionToken _token;
        private DateTime _createdAtUtc = DateTime.UtcNow;

        public HomeViewModel(IDescriptionService descriptionService, IMvxMessenger messenger)
        {
            _token = messenger.SubscribeOnMainThread<TickMessage>(OnTick);
            Descriptions = descriptionService.Descriptions
                                            .Select(x => new DescriptionViewModel(x))
                                            .ToList();
        }

        public class StateObject
        {
            public DateTime CreatedTimeUtc { get; set; }
        }

        public StateObject SaveState()
        {
            return new StateObject()
                {
                    CreatedTimeUtc = _createdAtUtc
                };
        }

        public void ReloadState(StateObject state)
        {
            _createdAtUtc = state.CreatedTimeUtc;
        }

        public override void Start()
        {
            Update();
            base.Start();
        }

        public List<DescriptionViewModel> Descriptions { get; private set; }
        private void OnTick(TickMessage message)
        {
            Update();
        }

        private void Update()
        {
            var minutes = (DateTime.UtcNow - _createdAtUtc).TotalMinutes;
            foreach (var descriptionViewModel in Descriptions)
            {
                descriptionViewModel.Update(minutes);
            }
        }
    }
}
