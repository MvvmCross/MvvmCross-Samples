using System;
using MvvmCross.Plugins.Messenger;
using StarWarsSample.Models;

namespace StarWarsSample.MvxMessages
{
    public class PlanetDestroyedMessage : MvxMessage
    {
        public PlanetDestroyedMessage(object sender, Planet planet) : base(sender)
        {
            Planet = planet;
        }

        public Planet Planet { get; set; }
    }
}
