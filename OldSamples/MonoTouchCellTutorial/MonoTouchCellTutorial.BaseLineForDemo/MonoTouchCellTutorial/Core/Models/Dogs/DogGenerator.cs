using System;
using System.Collections.Generic;

namespace MonoTouchCellTutorial.Core.Models.Dogs
{
	public class DogGenerator : AnimalGenerator
    {
        private readonly List<string> _names = new List<string>() { "Buddy"
            ,"Toby"
            ,"Ace"
            ,"AJ"
            ,"Max"
            ,"Aztec"
            ,"Jake"
            ,"Byron"
            ,"Axel"
            ,"Bentley"
            ,"Cooper"
            ,"Fuzzy"
            ,"Bandit"
            ,"Bear"
            ,"Charlie"
            ,"Duke"
            ,"Marley"
            ,"Rocky"
            ,"Shadow"
            ,"Biscuit"
            ,"Blaze"
            ,"Rocky"
            ,"Buzz"
            ,"Oreo"
            ,"Benji" };

        public Dog CreateNewDog()
        {
            return new Dog()
                {
                    Name = _names[Random(_names.Count)],
                    ImageUrl = string.Format("http://placedog.com/{0}/{0}", Random(20) + 300),
					GoodWithChildren = RandomBool (),
				};
        }
    }
}