using System;
using MvvmCross.Plugins.Messenger;
using StarWarsSample.Models;

namespace StarWarsSample.MvxMessages
{
    public class PersonDestroyedMessage : MvxMessage
    {
        public PersonDestroyedMessage(object sender, Person person) : base(sender)
        {
            Person = person;
        }

        public Person Person { get; set; }
    }
}
