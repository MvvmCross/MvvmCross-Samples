using FractalGen.Core.Messages;
using System;
using MvvmCross.Plugins.Messenger;

namespace FractalGen.Core.Services
{
    public class TimerService : ITimerService
    {
        private readonly IMvxMessenger _messenger;
        //private readonly Timer _timer;

        public TimerService(IMvxMessenger messenger)
        {
            _messenger = messenger;
            //_timer = new Timer(OnTimerCallback, null, TimeSpan.FromSeconds(0.1), TimeSpan.FromSeconds(0.1));
        }

        private void OnTimerCallback(object state)
        {
            _messenger.Publish(new TickMessage(this));
        }
    }
}