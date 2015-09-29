using System;
using System.Threading;
using Cirrious.MvvmCross.Plugins.Messenger;

namespace InternetMinute.Core
{
    public class TickService : ITickService
    {
        private IMvxMessenger _messenger;
        private Timer _timer;

        public TickService(IMvxMessenger messenger)
        {
            _messenger = messenger;
            _timer = new Timer(TickCallback, null, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(1));
        }

        private void TickCallback(object state)
        {
            _messenger.Publish(new TickMessage(this));
        }
    }
}