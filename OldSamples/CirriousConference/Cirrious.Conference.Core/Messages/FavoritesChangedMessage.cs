using MvvmCross.Plugins.Messenger;

namespace Cirrious.Conference.Core
{
    public class FavoritesChangedMessage : MvxMessage
    {
        public FavoritesChangedMessage(object sender)
            : base(sender)
        {
        }
    }
}