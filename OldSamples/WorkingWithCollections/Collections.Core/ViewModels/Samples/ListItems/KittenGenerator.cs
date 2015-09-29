using System;
using System.Collections.Generic;

namespace Collections.Core.ViewModels.Samples.ListItems
{
    public class KittenGenerator
    {
        private readonly List<string> _names = new List<string>
            {
                "Tiddles",
                "Amazon",
                "Pepsi",
                "Solomon",
                "Butler",
                "Snoopy",
                "Harry",
                "Holly",
                "Paws",
                "Polly",
                "Dixie",
                "Fern",
                "Cousteau",
                "Frankenstein",
                "Bazooka",
                "Casanova",
                "Fudge",
                "Comet"
            };

        private readonly Random _random = new Random();

        public Kitten CreateNewKitten()
        {
            return new Kitten
                {
                    Name = _names[_random.Next(_names.Count)],
                    ImageUrl = string.Format("http://placekitten.com/{0}/{0}", _random.Next(20) + 300)
                };
        }
    }
}