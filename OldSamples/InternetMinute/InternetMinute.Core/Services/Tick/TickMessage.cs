using Cirrious.MvvmCross.Plugins.Messenger;

namespace InternetMinute.Core
{
    public class TickMessage
        : MvxMessage
    {
        public TickMessage(object sender) : base(sender)
        {
        }
    }
}