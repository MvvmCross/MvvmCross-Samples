using Cirrious.MvvmCross.Plugins.Messenger;

namespace FractalGen.Core.Messages
{
    public class TickMessage : MvxMessage
    {
        public TickMessage(object sender)
            : base(sender)
        {
        }
    }
}