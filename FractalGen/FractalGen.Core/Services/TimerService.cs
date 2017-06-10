using FractalGen.Core.Messages;
using MvvmCross.Plugins.Messenger;
using System.Threading.Tasks;

namespace FractalGen.Core.Services
{
    public class TimerService : ITimerService
    {
        private readonly IMvxMessenger _messenger;

        public TimerService(IMvxMessenger messenger)
        {
            _messenger = messenger;

            Task.Run(async () =>
                {
                    while (true)
                    {

                        await Task.Delay(2000);
                        OnTimerCallback();
                    }
                });
        }

        private void OnTimerCallback()
        {
            _messenger.Publish(new TickMessage(this));
        }
    }
}