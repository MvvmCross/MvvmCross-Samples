using MvvmCross.Plugins.Messenger;

namespace Cirrious.Conference.Core
{
    public class LoadingChangedMessage : MvxMessage
    {
        public LoadingChangedMessage(object sender)
            : base(sender)
        {
        }
    }
}