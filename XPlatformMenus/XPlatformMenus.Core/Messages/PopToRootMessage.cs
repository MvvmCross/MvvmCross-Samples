using MvvmCross.Plugins.Messenger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPlatformMenus.Core.Messages
{
    public class PopToRootMessage : MvxMessage
    {
        public PopToRootMessage(object sender) : base(sender)
        {
        }
    }
}
