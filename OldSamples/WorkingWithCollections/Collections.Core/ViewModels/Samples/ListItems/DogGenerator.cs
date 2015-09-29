using System;
using System.Collections.Generic;

namespace Collections.Core.ViewModels.Samples.ListItems
{
    public class DogGenerator
    {
        private readonly List<string> _names = new List<string>
            {
                "Buddy"
                ,
                "Toby"
                ,
                "Ace"
                ,
                "AJ"
                ,
                "Max"
                ,
                "Aztec"
                ,
                "Jake"
                ,
                "Byron"
                ,
                "Axel"
                ,
                "Bentley"
                ,
                "Cooper"
                ,
                "Fuzzy"
                ,
                "Bandit"
                ,
                "Bear"
                ,
                "Charlie"
                ,
                "Duke"
                ,
                "Marley"
                ,
                "Rocky"
                ,
                "Shadow"
                ,
                "Biscuit"
                ,
                "Blaze"
                ,
                "Rocky"
                ,
                "Buzz"
                ,
                "Oreo"
                ,
                "Benji"
            };

        private readonly Random _random = new Random();

        public Dog CreateNewDog()
        {
            return new Dog
                {
                    Name = _names[_random.Next(_names.Count)],
                    ImageUrl = string.Format("http://placedog.com/{0}/{0}", _random.Next(20) + 300)
                };
        }
    }
}